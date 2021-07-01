using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securtyKey)
        {
            return new SigningCredentials(securtyKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
