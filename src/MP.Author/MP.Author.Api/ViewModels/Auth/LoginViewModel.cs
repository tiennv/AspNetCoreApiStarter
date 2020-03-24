﻿using System.ComponentModel.DataAnnotations;

namespace MP.Author.Api.ViewModels.Auth
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
