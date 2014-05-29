using System;
using System.Configuration;


namespace Quintsys.EnviromentConfigurationManager
{
    // ReSharper disable UnusedMember.Global
    public interface IEnviromentConfigManager
    {
        string Get(string key);
    }

    public class EnviromentConfigManager : IEnviromentConfigManager
    {
        public string Get(string key)
        {
            string fromConfig = ConfigurationManager.AppSettings[key];

            return String.Equals(fromConfig, "{ENV}", StringComparison.InvariantCultureIgnoreCase)
                ? Environment.GetEnvironmentVariable(key)
                : fromConfig;
        }
    }
}