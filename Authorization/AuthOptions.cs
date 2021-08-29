using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authorization
{
    public class AuthOptions
    {
        public const string ISSUER = "KnowledgeTestingSystem_WebAPI_JWT_Server";
        public const string AUDIENCE = "KnowledgeTestingSystem_WebAPI_JWT_Client";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
