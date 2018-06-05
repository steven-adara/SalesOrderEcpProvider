using System;
using System.Collections.Generic;

namespace Kfzteile24.SalesOrderEcpProvider.Types
{
    public class SalesOrderPartIdentificationDto
    {
        public string CarTypeNumber { get; set; }
        public string ManufacturerNumber { get; set; }
        public string ModelCode { get; set; }
    }
}