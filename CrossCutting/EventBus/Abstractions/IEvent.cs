namespace CrossCutting.EventBus.Abstractions {
    public interface IEvent
    {
    }
   
    public class UncommitedEvent
    {
        public UncommitedEvent(IEvent @event, int version)
        {
            Event = @event;
            Version = version;
        }
        public IEvent Event { get; protected set; }
        public int Version { get; protected set; }
    }
}