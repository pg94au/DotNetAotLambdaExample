using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SimpleSnapStartLambdaFunction;

public class Function
{
    private Guid _constructorGuid;

    public Function()
    {
        SnapshotRestore.RegisterAfterRestore(() =>
        {
            Console.WriteLine("Snapshot restore lambda method registered to run after snapshot restore running now.");
            _constructorGuid = Guid.NewGuid();
            Console.WriteLine($"Constructor Guid: {_constructorGuid}");
            return ValueTask.CompletedTask;
        });
    }
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public string FunctionHandler(string input, ILambdaContext context)
    {
        context.Logger.LogInformation($"Constructor Guid: {_constructorGuid}");

        return input.ToUpper();
    }
}
