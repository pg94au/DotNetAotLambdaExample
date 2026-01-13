using System.Text.Json.Serialization;
using Amazon.Lambda.APIGatewayEvents;

namespace SimpleAotLambdaAnnotationsFunction;

[JsonSerializable(typeof(string))] // Add all types your Lambda serializes
[JsonSerializable(typeof(APIGatewayCustomAuthorizerRequest))]
[JsonSerializable(typeof(APIGatewayCustomAuthorizerResponse))]
[JsonSerializable(typeof(APIGatewayCustomAuthorizerRequest))]
[JsonSerializable(typeof(APIGatewayCustomAuthorizerResponse))]
public partial class CustomJsonSerializerContext : JsonSerializerContext;
