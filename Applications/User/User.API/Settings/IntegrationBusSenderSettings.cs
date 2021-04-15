using CrossCutting.EventBus.Settings;

namespace User.API.Settings
{
    public class IntegrationBusSenderSettings: IntegrationBusSettings
    {
        public string RegisterRoutingKey { set; get; }
        public string ForgetPasswordRoutingKey { get; set; }
    }
}
