using ABB.Developers.SDK.Services.Powers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Electrification.ABB.SDK.EnPI.Update
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //Put application keys in here
                //you will get this below appId,APIkey,subId from the application section of the sdk portal.
                Guid appId = new Guid("3c7eb1bf-e1db-4fa3-8199-e80bc5477711");
                string APIkey = "ABB hqpI9jQiKBYPlvJC07zGU88WdpJKFCE7Og==";
                string subId = "c15dc231099b40f89c5175106f4d5145";

                //Plant Id,parameter Name , value, date of the performance parameter
                var plantId = new Guid("a09fe0a1-b981-4e04-aeb5-2fa9ce3a9be1");
                string parameterName = "TestQA";
                string value = "70";
                string date = "2021-08-05T08:28:00.000Z";

                //Setup the headers
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Authorization", APIkey);
                headers.Add("Subscription-Key", subId);

                // Instantiate power service
                PowerService ps = new PowerService(headers);

                //update Performance Parameter value
                var result = await ps.UpdatePerformanceIndicatorParameterValue(appId, plantId, parameterName, value, date);

                //write result to console
                Console.WriteLine(result.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
