using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface ISupport
    {
        List<SupportInfo> getListSupportInfo();
        int Update(SupportInfo support);
        int Delete(int id);
        int Insert(SupportInfo support);
        SupportInfo GetInfo(int pk_ID);
        List<SupportInfo> getListTop(int topNum);
    }
}
