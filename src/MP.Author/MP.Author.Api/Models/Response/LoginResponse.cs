﻿using MP.Author.Core.Dto;
using System.Collections.Generic;

namespace MP.Author.Api.Models.Response
{
    public class LoginResponse
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public List<RoleDto> Roles { get; set; }

        public LoginResponse(AccessToken accessToken, List<RoleDto> roles, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Roles = roles;
        }
    }
}
