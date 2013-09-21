namespace Hubs.UI.Web.Security
{
    using System.Text;
    using System.Web.Security;

    using Microsoft.IdentityModel.Web;

    public class MachineKeyCookieTransform : CookieTransform
    {
        private const string Purpose = "Authentication Token";

        public override byte[] Decode(byte[] encoded)
        {
            return MachineKey.Unprotect(encoded, Purpose);
        }

        public override byte[] Encode(byte[] value)
        {
            return MachineKey.Protect(value, Purpose);
        }
    }
}