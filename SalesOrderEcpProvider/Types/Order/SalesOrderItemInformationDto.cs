using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class SalesOrderItemInformationDto
    {
        public string PriceHammer { get; set; }
        public SalesOrderItemInformationOrderDto Order { get; set; }
    }

    public class SalesOrderItemInformationOrderDto
    {
        public string Name { get; set; }
    }
}
