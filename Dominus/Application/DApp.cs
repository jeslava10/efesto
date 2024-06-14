using Dominus.Database;

namespace Dominus.Application
{
    public static class DApp
	{
        static DApp()
		{
            RegisterModules = new List<Type>();
            Menus = new List<DMenu>();
            EncripKey = "Enigma";
        }

        public static List<Type> RegisterModules { get; set; }

        public static List<Tenant> Tenants { get; set; }

        public static void LoadTenants(List<Tenant> tenants)
        {
            DApp.Tenants = tenants;
        }

        public static DataBaseSetting GetTenantConnection(string host)
        {
            return Tenants.FirstOrDefault(x => x.Name.Contains(host)).DataBaseSetting;
        }

        public static string GetTenantService(string host, string service)
        {
            return Tenants.FirstOrDefault(x => x.Name.Contains(host)).Services[service];
        }

        public static string EncripKey { get; set; }

        public static List<DMenu> Menus { get; set; }

        public static string ServiceUrl { get; set; }


    }
}

