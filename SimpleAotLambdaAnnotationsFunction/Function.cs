using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

namespace SimpleAotLambdaAnnotationsFunction;

public class Function
{
    public Function()
    {

    }

    [LambdaFunction]
    public async Task<APIGatewayCustomAuthorizerResponse> Authorize(
        APIGatewayCustomAuthorizerRequest request,
        ILambdaContext context)
    {
        Console.WriteLine("Authorize function invoked.");

        await Task.CompletedTask;

        return GenerateAuthorizedResponse(request);
    }

    private static APIGatewayCustomAuthorizerResponse GenerateAuthorizedResponse(APIGatewayCustomAuthorizerRequest request)
    {
        return new APIGatewayCustomAuthorizerResponse
        {
            PolicyDocument = new APIGatewayCustomAuthorizerPolicy
            {
                Statement =
                [
                    new APIGatewayCustomAuthorizerPolicy.IAMPolicyStatement
                    {
                        Action =
                        [
                            "execute-api:Invoke"
                        ],
                        Effect = "Allow",
                        Resource =
                        [
                            request.MethodArn
                        ]
                    }
                ]
            },
            Context = new APIGatewayCustomAuthorizerContextOutput
            {
                { "access_token", "foo" }
            }
        };
    }
}
