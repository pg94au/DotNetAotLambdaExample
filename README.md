# DotNetAotLambdaExample
A very basic example of an AWS Lambda written in .net that utilizes AOT compilation.
(The instructions here are using bash for Windows.)

To build and deploy:

1. Install .NET Lambda AWS tool (if not installed):
   ```bash
   dotnet tool install -g Amazon.Lambda.Tools
   ```
2. Publish the AOT compiled project (requires Docker):
   ```bash
   cd SimpleAotLambdaFunction
   dotnet lambda package
   ```
3. Go to publish directory:
   ```bash
   cd bin/Release/net8.0/linux-x64/publish
   ```
4. Find the generated function archive (SimpleAotLambdaFunction.zip):
   ```bash
   cd bin/Release/net8.0
   ls -l
   ```
5. Create Lambda function in AWS (ie. named AotLambda).  Specify .NET 8 (C#/F#/PowerShell) runtime.  (Note AL2023 will not function correctly for all AOT applications.)
6. From Code tab, upload SimpleAotLambdaFunction.zip.
7. Under "Runtime settings" from the console for this lambda, set Handler to "SimpleAotLambdaFunction".
8. Invoke the lambda function from AWS CLI (specify region, profile, etc. as required):
   ```bash
   aws lambda invoke --function-name AotLambda response.json
   ```
   
