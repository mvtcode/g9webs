using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Entity;

namespace G9.Service
{
    public interface ICustomer
    {
        int Insert(CustomerInfo info);
        int Update(CustomerInfo info);
        int Delete(int id);
        CustomerInfo GetInfo(int id);
        List<CustomerInfo> SelectTopCustomerNew(int numberTop);
        List<CustomerInfo> SelectTopCustomer(int numberTop);
        List<CustomerInfo> GetListCustomer(int pageIndex, int pageSize, out int totalrow);
        List<CustomerInfo> GetListCustomer();
    }
}
