﻿
using MP.Author.Core.Shared;
using System;

namespace MP.Author.Core.Domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public int UserId { get; private set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }

        public RefreshToken(string token, DateTime expires, int userId, string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}
