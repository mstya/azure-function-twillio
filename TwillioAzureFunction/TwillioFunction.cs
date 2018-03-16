using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwillioAzureFunction
{
    public static class TwillioFunction
    {
        [FunctionName("TwillioFunction")]
        public static async Task Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            var accountSid = "";
            var authToken = "";

            TwilioClient.Init(accountSid, authToken);
            try
            {
                await MessageResource.CreateAsync(
                    to: new PhoneNumber(""),
                    from: new PhoneNumber(""),
                    body: "Test");

                log.Info($"Ok at: {DateTime.Now}");
            }
            catch (ApiException)
            {
                log.Info($"Exception at: {DateTime.Now}");
            }
        }
    }
}