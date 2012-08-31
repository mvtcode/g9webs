using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface IRole
    {
        int Insert(RoleInfo role);
        int Delete(int id);
        int Update(RoleInfo role);
        //List<RoleInfo> GetListRoles();
        RoleInfo GetRoleById(int id);
        List<RoleInfo> GetAll();
    }
}
