using System;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class SalesOrderTotalPriceDto
    {
        public double? ShippingStandardGross { get; set; }
        public double? ShippingExpressGross { get; set; }
        public double? ShippingBulkyGoodsGross { get; set; }
        public double? ShippingDangerousGoodsGross { get; set; }
        public SalesOrderPaymentExpensesGrossDto PaymentExpensesGrossPrices { get; set; }
        public double? TotalDiscountGrossPrice { get; set; }
    }

    public class SalesOrderPaymentExpensesGrossDto
    {
        public double? CashOnDelivery { get; set; }
    }
}