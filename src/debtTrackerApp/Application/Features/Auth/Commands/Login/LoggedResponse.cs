using Core.Application.Responses;
using Core.Security.Enums;
using Core.Security.JWT;
using System.Text.Json.Serialization;

namespace Application.Features.Auth.Commands.Login;

public class LoggedResponse : IResponse
{

    public int UserId { get; set; }
    public AccessToken? AccessToken { get; set; }
    public Core.Security.Entities.RefreshToken? RefreshToken { get; set; }
    public AuthenticatorType? RequiredAuthenticatorType { get; set; }

   
    public LoggedHttpResponse ToHttpResponse() =>
        new()
        {
            AccessToken = AccessToken, RequiredAuthenticatorType = RequiredAuthenticatorType,
            UserId = UserId
        };
    
    
  
    public class LoggedHttpResponse
    {
        
        public AccessToken? AccessToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        public int UserId { get; set; }
    }
}
