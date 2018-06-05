using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.HealthChecks;

namespace Kfzteile24.SalesOrderEcpProvider.Helper
{
    public class DefaultSelfCheck : IHealthCheck
    {
        public ValueTask<IHealthCheckResult> CheckAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return new ValueTask<IHealthCheckResult>(HealthCheckResult.FromStatus(CheckStatus.Healthy, $"Status message: alive"));
        }
    }
}
