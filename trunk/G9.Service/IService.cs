using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface IService
    {
        int Update(ServiceInfo service);
        int Delete(ServiceInfo service);
        int Insert(ServiceInfo service);
        List<ServiceInfo> GetList();
        ServiceInfo GetServiceByID(int id);
    }
}
