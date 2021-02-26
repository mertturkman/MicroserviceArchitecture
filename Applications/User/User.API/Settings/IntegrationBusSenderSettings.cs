using CrossCutting.EventBus.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Settings
{
    public class IntegrationBusSenderSettings: IntegrationBusSettings
    {
        public string RegisterRoutingKey { set; get; }
    }
}
