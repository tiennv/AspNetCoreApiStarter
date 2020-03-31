using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class RefreshTokens
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public int UserId { get; set; }
        public string RemoteIpAddress { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string ReToken { get; set; }

        public virtual Users User { get; set; }
    }
}
