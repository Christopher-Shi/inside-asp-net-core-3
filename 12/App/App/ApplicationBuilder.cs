using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private readonly List<Func<RequestDelegate, RequestDelegate>> _middlewares = new List<Func<RequestDelegate, RequestDelegate>>();
        public RequestDelegate Build()
        {
            _middlewares.Reverse();

            return httpContext =>
            {
                RequestDelegate nextDelegate = _ =>
                {
                    _.Response.StatusCode = 404;
                    return Task.CompletedTask;
                };
                foreach (var middleware in _middlewares)
                {
                    nextDelegate = middleware(nextDelegate); //404 -> baz -> bar -> foo
                }
                return nextDelegate(httpContext);
            };
        }

        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
