using System;
using System.Collections.Generic;

namespace MP.Author.Infrastructure.Models
{
    public partial class Users
    {
        public Users()
        {
            RefreshTokens = new HashSet<RefreshTokens>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<RefreshTokens> RefreshTokens { get; set; }
    }
}
