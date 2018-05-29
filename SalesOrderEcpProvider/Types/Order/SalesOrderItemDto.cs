using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class SalesOrderItemDto
    {
        public string StockKeepingUnit { get; set; }
        public double Quantity { get; set; }
        public SalesOrderPartIdentificationDto CarPartProperties { get; set; }
        public SalesOrderItemNumerDto ItemNumbers { get; set; }
        public SalesOrderItemInformationDto ItemInformation { get; set; }
        public SalesOrderItemCreatorDto Creator { get; set; }
        public SalesOrderItemSumValueDto SumValues { get; set; }
        public SalesOrderItemUnitValueDto UnitValues { get; set; }
    }
}
