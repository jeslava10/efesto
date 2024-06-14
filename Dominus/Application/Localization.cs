using System;

namespace Dominus.Application
{
    public static class Localization
    {
        private static Dictionary<string, Dictionary<string, string>> resources;

        static Localization()
        {
            resources = new Dictionary<string, Dictionary<string, string>>();

        }

        public static string DefaultLanguage { get; set; }

        public static void AddResource(string lan, string key, string value)
        {
            if (!resources.ContainsKey(lan))
                resources.Add(lan, new Dictionary<string, string>());
            if (resources[lan].ContainsKey(key))
                resources[lan][key] = value;
            else
                resources[lan].Add(key, value);
        }

        public static void AddResources(string lan, Dictionary<string, string> newResources)
        {
            if (resources == null)
                resources = new Dictionary<string, Dictionary<string, string>>();
            if (!resources.ContainsKey(lan))
                resources.Add(lan, newResources);
            else
                resources[lan] = newResources;
        }

        public static void AddResource(Dictionary<string, Dictionary<string, string>> recursos)
        {
            resources = recursos;
        }

        public static string GetResource(string key)
        {
            if (resources == null)
                resources = new Dictionary<string, Dictionary<string, string>>();
            string val = key;
            if (resources.ContainsKey(DefaultLanguage))
                if (resources[DefaultLanguage].ContainsKey(key))
                    val = resources[DefaultLanguage][key];
            return val;
        }

        public static string GetResource(string lan, string key)
        {
            if (resources == null)
                resources = new Dictionary<string, Dictionary<string, string>>();
            string val = key;
            if (resources.ContainsKey(lan))
                if (resources[lan].ContainsKey(key))
                    val = resources[lan][key];
            return val;
        }

        public static void SetResource(string key, string resource, string lan = null)
        {
            if (resources == null)
                resources = new Dictionary<string, Dictionary<string, string>>();
            if (resources.ContainsKey(lan))
                if (resources[lan].ContainsKey(key))
                    resources[lan][key] = resource;
                else
                    resources[lan].Add(key, resource);
        }

        public static Dictionary<string, Dictionary<string, string>> GetResources()
        {
            return resources;
        }

        public static void AddResources(Dictionary<string, Dictionary<string, string>> _resources)
        {
            resources = _resources;
        }
    }
}

