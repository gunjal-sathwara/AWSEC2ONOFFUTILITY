using System;
using System.Collections.Generic;
using Amazon.EC2;
using Amazon.EC2.Model;
using System.Threading.Tasks;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;

namespace EC2ONOFFUTILITY
    {
    public class EC2Utility
    {
        #region EC2 Operation Methods

        
        public async Task<OperationDetails> StartEC2InstancesByInstanceIds(List<string> instanceIds)
        {
            OperationDetails operationDetails = new OperationDetails();

            try
            {
                using (AmazonEC2Client ec2Client = new AmazonEC2Client())
                {
                    StartInstancesRequest startRequest = new StartInstancesRequest(instanceIds);

                    StartInstancesResponse startResponse = await ec2Client.StartInstancesAsync(startRequest);

                    operationDetails.StatusMessage = startResponse != null ? startResponse.HttpStatusCode.ToString(): "null response";
                }
            }
            catch (Exception ex)
            {
                operationDetails.StatusMessage = ex.Message;
            }

            return operationDetails;
        }

        public async Task<OperationDetails> StopEC2InstancesByInstanceIds(List<string> instanceIds)
        {
            OperationDetails operationDetails = new OperationDetails();
            try
            {
                using (AmazonEC2Client ec2Client = new AmazonEC2Client())
                {
                    StopInstancesRequest stopRequest = new StopInstancesRequest(instanceIds);

                    StopInstancesResponse stopResponse = await ec2Client.StopInstancesAsync(stopRequest);

                    operationDetails.StatusMessage = stopResponse != null ? stopResponse.HttpStatusCode.ToString() : "null response";
                }
            }
            catch (Exception ex)
            {
                operationDetails.StatusMessage = ex.Message;
            }

            return operationDetails;
        }

        #endregion EC2 Operation Methods
    }

    public class OperationDetails
    {
        #region Public Properties

        public string StatusMessage { get; set; }

        #endregion Public Properties
    }
}
