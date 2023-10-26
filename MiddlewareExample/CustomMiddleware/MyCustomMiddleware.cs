namespace MiddlewareExample.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsJsonAsync("My Custom middleware - starts\n");
            await next(context);
            await context.Response.WriteAsJsonAsync("My Custom middleware - end\n");
        }
    }
}