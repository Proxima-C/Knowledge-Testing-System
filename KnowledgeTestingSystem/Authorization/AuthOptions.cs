using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Authorization
{
    public class AuthOptions
    {
        public const string Issuer = "KnowledgeTestingSystem_WebAPI_JWT_Server";
        public const string Audience = "KnowledgeTestingSystem_WebAPI_JWT_Client";
        const string Key = "mysupersecret_secretkey!123";
        public const int LifeTimeInMinutes = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
