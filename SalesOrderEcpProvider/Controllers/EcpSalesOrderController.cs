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
using Microsoft.Extensions.Logging;

namespace Kfzteile24.SalesOrderEcpProvider.Controllers
{
    [Route("api/ecp-sales-orders")]
    public class EcpSalesOrderController : Controller
    {
        private readonly IMapper orderMapper;
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;
        private readonly ILogger<EcpSalesOrderController> appLogger;

        private string resultMessage;

        public EcpSalesOrderController(IMapper mapper, ILogger<EcpSalesOrderController> logger, IConfiguration config)
        {
            this.orderMapper = mapper;
            this.configuration = config;
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_URL"))
            };
            this.appLogger = logger;
        }

        // POST api/provide
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EcpSalesOrderDto orderData)
        {
            this.appLogger.LogInformation($"start processing sales order number: {orderData.order_header.order_number}");

            var order = this.orderMapper.MapFomDedicated(orderData);

            var stringContent = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

            var uri = Environment.GetEnvironmentVariable("SALES_ORDER_ECP_PROVIDER_SALES_ORDER_API_URL") + configuration["SalesOrderApiPostRoute"];

            var responseMessage = await httpClient.PostAsync(new Uri(uri), stringContent);

            if ((int)responseMessage.StatusCode < 400)
            {
                resultMessage = "successfully imported!";
                this.appLogger.LogInformation(resultMessage);
                return Ok(resultMessage);
            }

            resultMessage = $"error on importing!\n\n{responseMessage.Content.ReadAsStringAsync().Result}";
            this.appLogger.LogError(resultMessage);
            return BadRequest(resultMessage);
        }
    }
}
