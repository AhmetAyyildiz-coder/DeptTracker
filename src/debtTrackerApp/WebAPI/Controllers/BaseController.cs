using Application.Common.DTOs;
using Core.Security.Extensions;
using Core.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class BaseController : ControllerBase
{
    protected IMediator Mediator =>
        _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

    private IMediator? _mediator;

    protected string getIpAddress()
    {
        string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"].ToString()
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }

    protected int getUserIdFromRequest() //todo authentication behavior?
    {
        int userId = HttpContext.User.GetUserId();
        return userId;
    }
    
    // get getList, getById vb islemler - genellikle HttpGet- sonrası dönen response
    protected static ObjectResult ApiSuccessWithData<T>(T data, int statusCode = 200)
    {
        return new ObjectResult(ApiResponseDto<T>.Success(statusCode, data));
    }

    // add - update islemleri sonrası dönen response.
    protected static ObjectResult ApiSuccessWithStatusCode(int statusCode)
    {
        return new ObjectResult(ApiResponseDto<NotFoundDto>.Success(statusCode));
    }

    protected ObjectResult ApiError<T>(string error, int statusCode)
    {
        return new ObjectResult(ApiResponseDto<T>.Fail(statusCode, error));
    }
}
