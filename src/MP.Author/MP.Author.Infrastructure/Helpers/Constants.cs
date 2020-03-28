using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Infrastructure.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }       

        public enum EnumStatusCode
        {
            NOT_FOUND = 404,
            ERORR = 500,
            BAD_INPUT = 400
        }
    }

    
}
