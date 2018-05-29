using System;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    // this one needs to be extended in further iterations
    // to have at least the minimum properties of that
    // current used order file (*.csv)

    public class SalesOrderDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string ShippingType { get; set; }
        public SalesOrderOriginDto OrderOrigin { get; set; }
        public List<SalesOrderDiscountDto> Discounts { get; set; }
        public List<SalesOrderPaymentDto> Payments { get; set; }
        public SalesOrderTotalPriceDto TotalPrices { get; set; }
        public SalesOrderCustomerDto Customer { get; set; }
        public SalesOrderAddressDto BillingAddress { get; set; }
        public List<SalesOrderAddressDto> ShippingAddresses { get; set; }
        public List<SalesOrderItemDto> OrderItems { get; set; }
    }
}
