namespace Hubs.UI.Web.Controllers
{
    using System;
    using System.Configuration;
    using System.Security.Principal;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    using Microsoft.IdentityModel.Claims;
    using Microsoft.IdentityModel.Protocols.WSFederation;
    using Microsoft.IdentityModel.Web;

    [ValidateInput(false)]
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class AccountController : Controller
    {
        public static string GetAppUrl(HttpContextBase httpContext)
        {
            var reqUrl = httpContext.Request.Url;
            var appUrl = new StringBuilder();

            appUrl.Append(reqUrl.Scheme);
            appUrl.Append("://");
            appUrl.Append(httpContext.Request.Headers["Host"] ?? reqUrl.Authority);
            appUrl.Append(httpContext.Request.ApplicationPath);

            if (httpContext.Request.ApplicationPath != null && !httpContext.Request.ApplicationPath.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                appUrl.Append("/");
            }

            return appUrl.ToString();
        }

        [HttpGet]
        public ActionResult LogOn(string returnUrl)
        {
            return this.LogOnCommon(returnUrl);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult LogOn()
        {
            return this.LogOnCommon(null);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            try
            {
                FormsAuthentication.SignOut();
            }
            finally
            {
                FederatedAuthentication.WSFederationAuthenticationModule.SignOut(true);
            }

            // TODO: improve
            var signOutUrl = ConfigurationManager.AppSettings["AdfsSignOutUrl"];
            return this.Redirect(signOutUrl ?? "~/");
        }

        private static void MockUserPrincipal(HttpContextBase httpContext, string userName)
        {
            var claimsIdentity = new ClaimsIdentity(AuthenticationTypes.Federation, ClaimTypes.Name, ClaimTypes.Role);
            claimsIdentity.Claims.Add(new Claim(ClaimTypes.Name, userName));

            var claimsPrincipal = new ClaimsPrincipal(new[] { claimsIdentity });
            httpContext.User = (IPrincipal)claimsPrincipal;

            FormsAuthentication.SetAuthCookie(userName, true);
        }

        private ActionResult LogOnCommon(string returnUrl)
        {
            // If the request is unauthenticated...
            if (!this.Request.IsAuthenticated)
            {
                var redirectUrl = string.Empty;

                if (this.Request.IsLocal)
                {
                    // Mock user principal
                    MockUserPrincipal(this.HttpContext, "jdoe");
                    redirectUrl = string.Concat("~", returnUrl);
                }
                else
                {
                    // Redirect to ACS
                    string federatedSignInRedirectUrl = this.GetFederatedSignInRedirectUrl(returnUrl);
                    redirectUrl = federatedSignInRedirectUrl;
                }

                return this.Redirect(redirectUrl);
            }

            // Request is already authenticated.
            // Redirect to the URL the user was trying to access before being authenticated.
            string effectiveReturnUrl = returnUrl;

            // If no return URL was specified, try to get it from the Request context.
            if (string.IsNullOrWhiteSpace(effectiveReturnUrl))
            {
                effectiveReturnUrl = this.GetContextFromRequest();
            }

            // If there is a return URL, Redirect to it. Otherwise, Redirect to Home.
            if (!string.IsNullOrWhiteSpace(effectiveReturnUrl))
            {
                return this.Redirect(string.Concat("~", effectiveReturnUrl));
            }
            else
            {
                return this.RedirectToAction("Index", "Home");
            }
        }

        private string GetContextFromRequest()
        {
            Uri requestBaseUrl = WSFederationMessage.GetBaseUrl(this.Request.Url);
            WSFederationMessage message = WSFederationMessage.CreateFromNameValueCollection(requestBaseUrl, this.Request.Form);
            return message != null && message.Context != null ? Uri.UnescapeDataString(message.Context) : string.Empty;
        }

        private string GetFederatedSignInRedirectUrl(string returnUrl)
        {
            WSFederationAuthenticationModule fam = FederatedAuthentication.WSFederationAuthenticationModule;

            var appUrl = GetAppUrl(this.HttpContext);
            var signInRequest = new SignInRequestMessage(new Uri(fam.Issuer), appUrl)
            {
                Context = Uri.EscapeDataString(returnUrl),
                Reply = string.Concat(appUrl, "Account/LogOn/")
            };

            return signInRequest.WriteQueryString();
        }
    }
}