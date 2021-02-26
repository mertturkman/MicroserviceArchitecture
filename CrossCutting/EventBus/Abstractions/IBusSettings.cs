namespace CrossCutting.EventBus.Abstractions {
    public interface IBusSettings
    {
        string[] Servers { get; }
        string UserName { get; }
        string Password { get; }
        string VirtualHost { get; }
    }
}