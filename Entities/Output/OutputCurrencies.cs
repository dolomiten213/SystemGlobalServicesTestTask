using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemGlobalServicesTestTask.Input.Entities;

namespace SystemGlobalServicesTestTask.Entities.Output
{
    public class OutputCurrencies
    {
        public DateTime LastUpdate { get; init; }
        public Dictionary<string, double> Rates { get; init; }
    }
}
