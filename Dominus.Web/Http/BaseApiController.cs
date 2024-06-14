using Microsoft.AspNetCore.Mvc;

namespace Dominus.Web.Http
{
    public abstract class BaseApiController : Controller
    {
        public IHttpContextAccessor HttpContextAccessor { get; set; }

        public IConfiguration Config { get; set; }


        public BaseApiController(IHttpContextAccessor httpContextAccessor, IConfiguration config)
        {
            HttpContextAccessor = httpContextAccessor;
            Config = config;    
        }

    }
}
