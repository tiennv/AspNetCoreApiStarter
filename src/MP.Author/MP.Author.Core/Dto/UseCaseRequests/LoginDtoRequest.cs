﻿using MP.Author.Core.Dto.UseCaseResponses;
using MP.Author.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MP.Author.Core.Dto.UseCaseRequests
{
    public class LoginDtoRequest : IUseCaseRequest<LoginDtoResponse>
    {
        public string UserName { get; }
        public string Password { get; }
        public string RemoteIpAddress { get; }

        public LoginDtoRequest(string userName, string password, string remoteIpAddress)
        {
            UserName = userName;
            Password = password;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}