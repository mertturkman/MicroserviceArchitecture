namespace CrossCutting.EventBus.Settings {
    public class BusSettings
    {
        public string[] Servers { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ClusterName { get; set; }
        public string VirtualHost { get; set; }
    }
}