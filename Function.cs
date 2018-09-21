using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace EC2ONOFFUTILITY
{
    public class Function
    {

        public Function()
        {
          
        }

        public async Task FunctionHandler(ILambdaContext context)
        {
            var instanceIds = new List<string>() { "i-0dec4c2e3a9a3678b" };

            EC2Utility ec2 = new EC2Utility();

            OperationDetails operationDetails = await ec2.StartEC2InstancesByInstanceIds(instanceIds);
            LambdaLogger.Log(operationDetails.StatusMessage);

            LambdaLogger.Log($"Finished executing the { context.FunctionName } function.");
        }
    }
}



       
