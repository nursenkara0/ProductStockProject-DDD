using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/Api");
#if RELEASE
path = Path.Combine(Directory.GetCurrentDirectory());
#endif
                configurationManager.SetBasePath(path);
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("MicrosoftSqlServer");
            }
        }
    }
}
