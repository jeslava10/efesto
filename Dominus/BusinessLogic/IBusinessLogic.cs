using Dominus.Database;

namespace Dominus.BusinessLogic
{
    public interface IBusinessLogic
	{

        string Tenant { get; set; }

        DataBaseSetting Settings { get; set; }

        DomainLogic<T> GetDomainLogic<T>() where T : BaseEntityCustom;
    }
}

