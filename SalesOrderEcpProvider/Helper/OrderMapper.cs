using System;
using System.Globalization;
using System.Collections.Generic;
using Kfzteile24.SalesOrderEcpProvider.Types;

namespace Kfzteile24.SalesOrderEcpProvider.Helper
{
    public class OrderMapper : IMapper
    {
        public UniversalSalesOrder MapFomDedicated(EcpOrderDto dedicatedOrder)
        {
            return new UniversalSalesOrder
            {
                OrderNumber = dedicatedOrder.order_header.order_number,
                OrderDateTime = DateTime.ParseExact(dedicatedOrder.order_header.order_datetime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                InvoiceFirstName = dedicatedOrder.order_header.billing_address.first_name,
                InvoiceLastName = dedicatedOrder.order_header.billing_address.last_name,
                OrderItems = MapItem(dedicatedOrder.order_rows)
            };
        }

        private List<UniversalSalesOrderItem> MapItem(List<OrderItem> dtoItems)
        {
            var items = new List<UniversalSalesOrderItem>();

            dtoItems.ForEach(item => items.Add(new UniversalSalesOrderItem
            {
                Description = item.sku
            }));

            return items;
        }
    }
}
