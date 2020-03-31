
using MP.Author.Core.Shared;
using System;

namespace MP.Author.Core.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string ReToken { get; set; }

        public RefreshToken(string token, DateTime expires, int userId, string remoteIpAddress, string reToken)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
            ReToken = reToken;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
    }
}
