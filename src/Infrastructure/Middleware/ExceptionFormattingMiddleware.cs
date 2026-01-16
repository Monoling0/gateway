using Grpc.Core;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Middleware;

public class ExceptionFormattingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (RpcException ex)
        {
            await HandleGrpcException(context, ex);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleGrpcException(HttpContext context, RpcException rpcException)
    {
        context.Response.StatusCode = MapRpcCodeToHttpCode(rpcException.StatusCode);

        await context.Response.WriteAsJsonAsync(new { message = rpcException.Status.Detail });
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        await context.Response.WriteAsJsonAsync(new { message = exception.Message });
    }

    private int MapRpcCodeToHttpCode(StatusCode statusCode)
    {
        return statusCode switch
        {
            StatusCode.InvalidArgument => StatusCodes.Status400BadRequest,
            StatusCode.NotFound => StatusCodes.Status404NotFound,
            StatusCode.AlreadyExists
                or StatusCode.FailedPrecondition => StatusCodes.Status409Conflict,
            StatusCode.PermissionDenied => StatusCodes.Status403Forbidden,
            StatusCode.Unauthenticated => StatusCodes.Status401Unauthorized,
            StatusCode.ResourceExhausted => StatusCodes.Status429TooManyRequests,
            StatusCode.Unavailable => StatusCodes.Status503ServiceUnavailable,
            StatusCode.DeadlineExceeded => StatusCodes.Status504GatewayTimeout,
            StatusCode.OK => StatusCodes.Status200OK,
            StatusCode.Internal
                or StatusCode.Cancelled
                or StatusCode.Unknown
                or StatusCode.Aborted
                or StatusCode.OutOfRange
                or StatusCode.DataLoss
                => StatusCodes.Status500InternalServerError,
            StatusCode.Unimplemented => StatusCodes.Status501NotImplemented,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}