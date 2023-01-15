using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace OurFirstApi.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _request;
    
    public  GlobalExceptionHandler(RequestDelegate request)
    {
        _request = request;
    }

  
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _request(httpContext);
        }
        catch (Exception e)
        {
            // NEDEN THROW E; YAPMADIK = EROROUN FORMATINI DÜZENLEDÝK - AKSÝ TAKTÝRDE KARMASIK
            // VE HER BÝLGÝNÝN BULUNDUÐU GÜVENLÝK AÇIÐI YARATABÝLECEK BÝR HATA MESAJI DÖNDÜRÜR
            await HandleOurException(httpContext, e);
        }
    }

    private async Task HandleOurException(HttpContext context, Exception exception)
    {
        //context.Response.ContentType = "application/json";
        //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync( JsonConvert.SerializeObject(new Error
        {
         StatusCode = context.Response.StatusCode,
         Message = exception.Message
        }));
    }
    
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

}