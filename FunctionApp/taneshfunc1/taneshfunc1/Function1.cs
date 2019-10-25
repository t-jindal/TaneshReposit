using System;

using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace taneshfunc1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //taking values from url query
            string firstnumber = (req.Query["firstnumber"]);
            string secondnumber = (req.Query["secondnumber"]);


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            //Query Pattern
            firstnumber = firstnumber ?? data?.firstnumber;
            secondnumber = secondnumber ?? data?.secondnumber;
            
            string result = null;
            //Converting the input string to integer type
            int a = Convert.ToInt32(firstnumber);
            int b = Convert.ToInt32(secondnumber);
           
            //to find out the even numbers in given range
            for (int i = a;i<=b;i++)
            {

                if (i % 2 == 0)
                {
                    result  += Convert.ToString(i)+ "   ";

                }

                    
                
            }

            //finally presenting the output to user screen
            return (firstnumber != null&&secondnumber!=null)
               ? (ActionResult)new OkObjectResult($"even number : {result}")
                : new BadRequestObjectResult("Please pass two numbers on the query string or in the request body");

        }
    }
}
