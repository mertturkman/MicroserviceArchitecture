namespace CrossCutting.EventBus.Settings
{
    public class ReceiverEndpoint
    {
        public string QueueName { get; set; }
        public string[] RoutingKeys { get; set; }
        public ushort PrefetchCount { get; set; }
        public int RetryCount { get; set; }
        public int RetryInterval { get; set; }
        public int ConcurrencyLimit { get; set; }
    }    
}



