namespace Dominus.Web.HttpClient
{
    public class BaseProxy
    {
        public string Token { get; set; }
        //Production
        public string ServiceAddres { get; set; }

        public BaseProxy(string serviceAddres, string token)
        {
            this.ServiceAddres = serviceAddres;
            this.Token = token;
        }

        public BaseProxy()
        {
            
        }
    }

    public class DmsLogicProxy : BaseProxy
    {
        public DmsLogicProxy() : base()
        {
        }
        public DmsLogicProxy(string serviceAddres, string token) : base(serviceAddres, token)
        {
        }
    }
}
