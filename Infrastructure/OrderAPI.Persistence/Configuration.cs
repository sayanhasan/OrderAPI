using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAPI.Persistence
{
    public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager config = new();
                config.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OrderAPI.API"));
                string jsonFileName = string.Empty;
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
                if (env.ToLower() == "development") jsonFileName = "appsettings.Development.json";
                else jsonFileName = "appsettings.json";
                config.AddJsonFile(jsonFileName);
                return config.GetConnectionString("MsSQL");
            }
        }
    }
}
