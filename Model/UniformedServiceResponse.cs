using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSignalR.Model
{
    public class UniformedServiceResponse
    {
        public int WebSystem { get; set; }
        public int IndoorSystem { get; set; }
        public int NetBalanceSystem { get; set; }
        public int WisdomControlSystem { get; set; }
        public int ScadaSystem { get; set; }

        public List<UniformedServicesInfo> ListInfo { get; set; }
    }
}
