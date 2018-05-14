using Kfzteile24.SalesOrderEcpProvider.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kfzteile24.SalesOrderEcpProvider.Helper
{
    public interface IMapper
    {
        UniversalSalesOrder MapFomDedicated(EcpOrderDto dedicatedOrder);
    }
}
