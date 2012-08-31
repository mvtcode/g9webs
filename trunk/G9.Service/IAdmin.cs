using System.Collections.Generic;
using G9.Entity;
using System.Data;

namespace G9.Service
{
    public interface IAdmin
    {
        DataTable SelectOne(int id);

        DataTable CheckLogin(string username, string pass);

        DataTable SelectAll();

        AdminInfo Insert(AdminInfo admin);

        //LogAdminInfo insertLog(LogAdminInfo logAdmin);

        //DataTable searchLog(string key, string user, int action, string tu, string den);

        AdminInfo Update(AdminInfo admin);

        void Delete(int id);

        List<AdminInfo> GetAdmin(DataTable dt);
    }

    public interface IMenu
    {
        DataTable GetOneMenu(int id);
    }

    public interface IUserRight
    {
        UserRightInfo Insert(UserRightInfo userRight);

        UserRightInfo Update(UserRightInfo userRight);

        UserRightInfo GetRightByMenuAndAdmin(int menuID, int adminID);

        DataTable GetFullParentMenu();

        DataTable GetFullMenuByParentID(int parentID);

        DataTable GetParentMenuByID(int ID);

        DataTable GetQuyenByAdminID(int adminID, int type);

        DataTable GetParentMenuByAdminID(int adminID);

        DataTable GetMenuByAdminIDAndParentID(int adminID, int parrentID);

        UserRightInfo CheckRightAdmin();

        List<UserRightInfo> GetRight(DataTable dt);
    }
}
