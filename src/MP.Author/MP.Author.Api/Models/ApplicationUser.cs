using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MP.Author.Api.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FullName { get; set; }
	}
}
