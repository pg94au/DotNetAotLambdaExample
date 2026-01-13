using Amazon.Lambda.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleAotLambdaAnnotationsFunction;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        Console.WriteLine("We are in ConfigureServices");
    }
}
