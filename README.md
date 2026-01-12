# DotNetAotLambdaExample
A very basic example of an AWS Lambda written in .net that utilizes AOT compilation.

To build and deploy:

1. Publish the AOT compiled project (from WSL2 if using Windows):
   ```bash
   dotnet publish -c Release -r linux-x64
   ```
2. Go to publish directory:
   ```bash
   cd bin/Release/net8.0/linux-x64/publish
   ```
3. Create zip archive:
   ```bash
   cp SimpleAotLambdaFunction bootstrap
   zip function.zip bootstrap
   ```
4. Create Lambda function in AWS (ie. named AotLambda).  Specify .NET 8 (C#/F#/PowerShell) runtime.  (Note AL2023 will not function correctly for all AOT applications.)
5. From Code tab, upload function.zip.
6. Invoke the lambda function from AWS CLI:
   ```bash
   aws lambda invoke --function-name AotLambda response.json
   ```

You can also host this function locally in Docker to test it:

1. Navigate to directory containing function.zip (created in previous section).
2. Start running function in AWS Lambda container:
   ```bash
   cd <directory containing function.zip>
   docker run --rm -p 9000:8080 --platform=linux/amd64 -v .:/var/runtime public.ecr.aws/lambda/provided:al2023 ./bootstrap
   ```
3. Invoke the lambda from another shell:
   ```bash
   curl -XPOST http://localhost:9000/2015-03-31/functions/function/invocations -d '{}'
   ```
