using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.SystemTextJson;
using System.Text.Json.Serialization;
using SimpleAotLambdaFunction;

[assembly: LambdaSerializer(typeof(SourceGeneratorLambdaJsonSerializer<MyJsonSerializerContext>))]

namespace SimpleAotLambdaFunction;

[JsonSerializable(typeof(string))] // Add all types your Lambda serializes
[JsonSerializable(typeof(EmptyEvent))]
public partial class MyJsonSerializerContext : JsonSerializerContext;

// If we directly invoke this lambda with no input, this empty class matches that input.
public class EmptyEvent;

internal class Program
{
    static async Task Main()
    {
        Func<EmptyEvent, ILambdaContext, string> handler = (input, context) =>
        {
            context.Logger.LogLine($"Input received: {input}");
            return $"Hello from Native AOT! Input was '{input}'";
        };

        var serializer = new SourceGeneratorLambdaJsonSerializer<MyJsonSerializerContext>();

        using var bootstrap = LambdaBootstrapBuilder.Create(handler, serializer).Build();
        await bootstrap.RunAsync();
    }
}