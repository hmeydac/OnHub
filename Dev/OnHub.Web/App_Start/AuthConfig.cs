namespace OnHub.Web.App_Start
{
    using Microsoft.Web.WebPages.OAuth;

    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            /* OAuthWebSecurity.RegisterMicrosoftClient(
               clientId: "",
               clientSecret: ""); */

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "lrwMTnlIV5pgK1GmaK4aA",
                consumerSecret: "bCuBgxvcFaHDYeo3e23u4qHvUeUoUjoyTfcFG2pw");

            /* OAuthWebSecurity.RegisterFacebookClient(
                appId: "",
                appSecret: "");

            OAuthWebSecurity.RegisterGoogleClient(); */
        }
    }
}
