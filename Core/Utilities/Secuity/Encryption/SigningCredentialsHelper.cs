using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Secuity.Encryption
{
    public partial class SecuityKeyHelper
    {
        public class SigningCredentialsHelper
        {
            public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
            {
                return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            }
        }
    }
}
