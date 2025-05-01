using Amazon.Lambda.Core;
using Amazon.S3;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambda.NetCore;

public class Function
{
    public async Task<IEnumerable<string>> FunctionHandler(string input, ILambdaContext context)
    {
        var s3Client = new AmazonS3Client();
        var data = await s3Client.ListBucketsAsync();
        var buckets = data.Buckets.Select(s => s.BucketName);
        return buckets;
    }
}
