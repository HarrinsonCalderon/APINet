using Microsoft.AspNetCore.Builder;

namespace WebApi.Middlewars
{
    public class TimeMiddlewar
    {
        //para usar la secuencua de los middlewars
        public readonly RequestDelegate next;

        public TimeMiddlewar(RequestDelegate nextRequest)
        {
            next= nextRequest;
        }
        public async Task invoke(Microsoft.AspNetCore.Http.HttpContext context)
        {
            await next(context);
            if (context.Request.Query.Any(p => p.Key == "Time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }
        }
        //clase para agregarlo al using
        
        }
        public  static class TimeMiddlewareExtension{
             public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddlewar>(); 
        }
    }
}
