using CrossCutting.EventBus.Settings;

namespace MailNotification.Consumers.Settings
{
    public class IntegrationBusReceiverSettings: IntegrationBusSettings {
        public ReceiverEndpoint RegisterReceiverEndpoint { get; set; }
        public ReceiverEndpoint ForgetPasswordReceiverEndpoint { get; set; }
    }  
}



