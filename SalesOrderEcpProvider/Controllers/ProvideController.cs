using System;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Kfzteile24.SalesOrderEcpProvider.Types;
using Kfzteile24.SalesOrderEcpProvider.Helper;
using System.Threading.Tasks;
using Microsoft.Extensions.HealthChecks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Controllers
{
    [Route("api/provide")]
    public class ProvideController : Controller
    {
        private readonly IMapper orderMapper;
        private readonly IHealthCheckService healthCheckService;
        private readonly IConfiguration configuration;

        public ProvideController(IMapper mapper, IConfiguration config, IHealthCheckService healthCheck)
        {
            this.orderMapper = mapper;
            this.healthCheckService = healthCheck;
            this.configuration = config;
        }

        // POST api/provide
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EcpOrderDto orderData)
        {
            var healthChecksResult = RunHealthChecks().Result;

            if (healthChecksResult.StatusCode != StatusCodes.Status200OK)
                return BadRequest(healthChecksResult.Value);

            var order = this.orderMapper.MapFomDedicated(orderData);

            var httpClient = new HttpClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

            //var uri = this.configuration["SOP_API_URL"];
            //var uri = this.configuration.GetValue<string>("SOP_API_URL");
            var uri = Environment.GetEnvironmentVariable("SOP_API_URL");

            if (uri == null)
                return new ObjectResult("uri not created");

            var responseMessage = await httpClient.PostAsync(new Uri(uri), stringContent);

            if ((int)responseMessage.StatusCode < 400)
            {
                return new ObjectResult("Done!");
            }

            return BadRequest(responseMessage.ReasonPhrase);
        }       

        private async Task<ObjectResult> RunHealthChecks()
        {
            var statusCode = StatusCodes.Status200OK;
            var errors = new List<string>();

            CompositeHealthCheckResult healthCheckResult = await healthCheckService.CheckHealthAsync();

            // results includes both the good and bad descriptions - filter good ones out
            var failureNotes = healthCheckResult.Results.Where(r => r.Value.CheckStatus != CheckStatus.Healthy);

            if (failureNotes.Any())
            {
                var failedHealthCheckDescriptions = failureNotes.Select(fn => $"{fn.Key} -> {fn.Value.Description}" ).ToList();

                // return a 500 with object result containing the error descriptions of the health check(s)
                statusCode = StatusCodes.Status500InternalServerError;
                errors = failedHealthCheckDescriptions;
            }

            return new ObjectResult(new { HealthCheckErrors = errors })
            {
                StatusCode = statusCode
            };
        }
    }
}
