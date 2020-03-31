using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using MP.Author.Api.Models.Settings;
using MP.Author.Api.Presenters;
using MP.Author.Api.Serialization;
using MP.Author.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MP.Author.Api.Middleware
{
    public class SecurityFilter : IAuthorizationFilter
    {
        private readonly IJwtFactory _jwtFactory;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly AuthSettings _authSettings;
        public SecurityFilter(IJwtFactory jwtFactory, IJwtTokenValidator jwtTokenValidator, IOptions<AuthSettings> authSettings)
        {
            _jwtFactory = jwtFactory;
            _jwtTokenValidator = jwtTokenValidator;
            _authSettings = authSettings.Value;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext != null)
            {
                Microsoft.Extensions.Primitives.StringValues authTokens;
                filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out authTokens);

                var _token = authTokens.FirstOrDefault();
                var authorPresenter = new AuthorizePresenter();
                if (_token != null)
                {
                    string authToken = _token;
                    if (authToken != null)
                    {
                        if (IsValidToken(authToken))                        
                        {
                            filterContext.HttpContext.Response.Headers.Add("Authorization", authToken);
                            filterContext.HttpContext.Response.Headers.Add("AuthStatus", "Authorized");                            
                            return;
                        }
                        else
                        {
                            filterContext.HttpContext.Response.Headers.Add("authToken", authToken);
                            filterContext.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

                            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            filterContext.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                            filterContext.HttpContext.Response.ContentType = "application/json";
                            var obj = authorPresenter.HandleResponse("Not Authorized", (int)HttpStatusCode.Forbidden);
                            filterContext.Result = new JsonResult("Not Authorized")
                            {
                                Value = obj
                            };
                        }

                    }

                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                    filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide authToken";                    
                    var obj = authorPresenter.HandleResponse("Please Provide authToken", (int)HttpStatusCode.ExpectationFailed);
                    filterContext.Result = new JsonResult("Please Provide authToken")
                    {
                        Value = obj
                    };
                }
            }
        }
        public bool IsValidToken(string authToken)
        {
            if (authToken.StartsWith(JwtBearerDefaults.AuthenticationScheme))
            {
                authToken = authToken.Replace(JwtBearerDefaults.AuthenticationScheme.ToString(),"").Trim();
                var validation = _jwtTokenValidator.GetPrincipalFromToken(authToken, _authSettings.SecretKey);
                if (validation != null)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
