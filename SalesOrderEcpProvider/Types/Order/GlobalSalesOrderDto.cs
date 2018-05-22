using System;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    // this one needs to be extended in further iterations
    // to have at least the minimum properties of that
    // current used order file (*.csv)
    public class GlobalSalesOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string InvoiceFirstName { get; set; }
        public string InvoiceLastName { get; set; }
        public List<GlobalSalesOrderItemDto> OrderItems { get; set; }
    }
}
