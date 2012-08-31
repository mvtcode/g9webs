using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using G9.Entity;
namespace G9.Service
{
    public interface IUser
    {
        int Insert(UserInfo info);
        int Update(UserInfo info);
        int Delete(int id);
        UserInfo GetUser(int id);
        UserInfo GetUser(string sUsername);
        UserInfo CheckLogin(string sUsername, string sPassword);
        int CheckExist(string sUsername);
        List<UserInfo> GetListUser(int pageIndex, int pageSize, out int totalrow);
        List<UserInfo> GetListUser();
        UserInfo GetUserByEmail(string sEmail);
        int ChangePass(int id, string sNewPass);
        List<UserInfo> GetNew(int iTop);
        int CountUser();
        bool CheckPass(int id, string sPassword);
    }
}
