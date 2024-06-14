using Dominus.Application;
using Dominus.Database;

namespace Dominus.Web.Http
{
    public static class IHttpContextAccessorExtension
    {

        public static DataBaseSetting CurrentConnection(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext.User.FindFirst("TenantId") != null && !string.IsNullOrWhiteSpace(httpContextAccessor.HttpContext.User.FindFirst("TenantId").Value))
            {
                return DApp.GetTenantConnection(httpContextAccessor.HttpContext.User.FindFirst("TenantId")?.Value);
            }
            else 
                return null;
        }

        public static string GetTenant(this IHttpContextAccessor httpContextAccessor)
        {
           return  httpContextAccessor.HttpContext.User.FindFirst("TenantId")?.Value;
        }

    }
}
