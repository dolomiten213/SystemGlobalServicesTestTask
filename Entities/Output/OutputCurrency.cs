using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemGlobalServicesTestTask.Entities.Output
{
    public class OutputCurrency
    {
        public DateTime LastUpdate { get; set; }
        public string Name { get; set; }
        public double Rate{ get; set; }
    }
}
