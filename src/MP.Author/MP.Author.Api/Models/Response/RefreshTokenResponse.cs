using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Api.Models.Response
{
    public class RefreshTokenResponse
    {
        public string refresh_token { get; }
        public string token { get; }
        public string ttl { get; }

        public RefreshTokenResponse(string refreshToken, string token, string ttl)
        {
            this.refresh_token = refreshToken;
            this.token = token;
            this.ttl = ttl;
        }
    }
}
