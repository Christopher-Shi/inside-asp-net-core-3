using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ServiceCollection()
            //    .AddTransient<IFoo, Foo>()
            //    .AddTransient<IBar, Bar>()
            //    .AddTransient<IBaz, Baz>()
            //    .AddTransient<IQux, Qux>()
            //    .BuildServiceProvider()
            //    .GetServices<IQux>();

            var root = new ServiceCollection().AddTransient<IFoo, Foo>().BuildServiceProvider();

            var child = root.CreateScope().ServiceProvider;

            var instance = child.GetService<IFoo>();

            Debug.Assert(instance is Foo);
        }
    }
}
