
namespace QArte.Persistance.PersistanceConfigurations
{
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class ConnectionStrings
    {
        public string ConnectionString { get; set; }
    }

    public class Stripe
    {
        public string PubKey { get; set; }
        public string SecretKey { get; set; }
    }

    public class stripeconfig
    {
        public Logging Logging { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public string AllowedHosts { get; set; }
        public Stripe Stripe { get; set; }
    }
}