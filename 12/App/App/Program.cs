using Microsoft.Extensions.Hosting;

namespace App
{
    class Program
    {
        static void Main()
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHost(builder => builder
                    .UseHttpListenerServer()
                    .Configure(app => app
                        .Use(FooMiddleware)
                        .Use(BarMiddleware)
                        .Use(BazMiddleware)))
                .Build()
                .Run();
        }

        public static RequestDelegate FooMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                await context.Response.WriteAsync("Foo=>");
                await next(context);
            };
        }

        public static RequestDelegate BarMiddleware(RequestDelegate next)
        {
            return async context =>
            {
                await context.Response.WriteAsync("Bar=>");
                await next(context);
            };
        }

        public static RequestDelegate BazMiddleware(RequestDelegate next)
        {
            return context => context.Response.WriteAsync("Baz");
        }
    }
}
