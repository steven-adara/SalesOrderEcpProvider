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
    [Route("api/ecp-sales-orders")]
    public class EcpSalesOrderController : Controller
    {
        private readonly IMapper orderMapper;
        private readonly IConfiguration configuration;

        public EcpSalesOrderController(IMapper mapper, IConfiguration config)
        {
            this.orderMapper = mapper;
            this.configuration = config;
        }

        // POST api/provide
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EcpOrderDto orderData)
        {
            var order = this.orderMapper.MapFomDedicated(orderData);

            var httpClient = new HttpClient();

            var stringContent = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

            var uri = Environment.GetEnvironmentVariable("SOP_API_URL");

            var responseMessage = await httpClient.PostAsync(new Uri(uri), stringContent);

            if ((int)responseMessage.StatusCode < 400)
            {
                return new ObjectResult("Done!");
            }

            return BadRequest(responseMessage.ReasonPhrase);
        }
    }
}
