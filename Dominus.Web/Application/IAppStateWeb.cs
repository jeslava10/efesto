using Dominus.Web.HttpClient;

namespace Dominus.Web.Application
{
    public interface IAppStateWeb
	{
		public DmsLogicProxy DmsLogic { get; set; }

        public string Tenant { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }


    }
}

