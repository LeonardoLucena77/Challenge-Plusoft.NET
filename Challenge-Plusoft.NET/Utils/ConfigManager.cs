using Microsoft.Extensions.Configuration;
using System;

namespace PlusoftRecommender.Utils
{
    public class ConfigManager
    {
        private readonly IConfiguration _configuration;

        public ConfigManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }

        public string GetValue(string key)
        {
            return _configuration[key];
        }

        public T GetSection<T>(string sectionName) where T : class, new()
        {
            var section = _configuration.GetSection(sectionName);
            if (section.Exists())
            {
                return section.Get<T>();
            }
            return new T();
        }
    }
}
