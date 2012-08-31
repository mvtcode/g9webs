using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using G9.Core;
using G9.Entity;
using G9.Service;
using Sercurity;

namespace G9.Impl
{
    public class LoginAdmin
    {
        public static AdminInfo fLoginAdmin(string username, string password)
        {
            try
            {
                var obj = new AdminImpl();

                DataTable dt = obj.CheckLogin(username, password);
                List<AdminInfo> list = obj.GetAdmin(dt);
                if (list.Count > 0)
                    return list[0];
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void IsLoginAdmin()
        {
            if (HttpContext.Current.Session[Constant.SessionNameAccountAdmin] == null ||
                HttpContext.Current.Session[Constant.SessionNameAccountAdmin].ToString() == string.Empty)
            {
                HttpContext.Current.Response.Redirect(Utility.UrlRoot + Config.LoginAdmin + "?URL=" + HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.AbsoluteUri.Replace("http://", "")), true);
            }
        }
    }


    public class AdminImpl : IAdmin
    {
        private const string STORE_INSERT = "sp_Admin_Insert";
        private const string STORE_UPDATE = "sp_Admin_Update";
        private const string STORE_DELETE = "sp_Admin_Delete";
        private const string STORE_SELECTONE = "sp_Admin_SelectOne";
        private const string STORE_SELECTALL = "sp_Admin_SelectAll";
        private const string STORE_LOG = "SP_ViewLogSearch";

        private const string STORE_INSERT_LOG = "sp_LogAdmin_Insert";

        private const string STORE_CHECK_LOGIN = "sp_CheckAdminLogin";

        #region IAdmin Members

        public DataTable SelectOne(int id)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ID", id);

            try
            {
                return DataHelper.ExecuteQueryToDataSet(STORE_SELECTONE, prm, CommandType.StoredProcedure).Tables[0];
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable CheckLogin(string username, string pass)
        {
            var prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@Username", username);
            prm[1] = new SqlParameter("@Pass", Encrypt.MD5Admin(pass));

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_CHECK_LOGIN, prm, CommandType.StoredProcedure).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.", ex);
            }
        }

        public DataTable SelectAll()
        {
            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_SELECTALL, null, CommandType.StoredProcedure).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }


        public AdminInfo Insert(AdminInfo admin)
        {
            #region Parameter

            var prm = new SqlParameter[6];

            prm[0] = new SqlParameter("@ID", admin.ID){Direction = ParameterDirection.Output};
            prm[1] = new SqlParameter("@Username", admin.Username);
            prm[2] = new SqlParameter("@Password", Encrypt.MD5Admin(admin.Password));
            prm[3] = new SqlParameter("@FullName", admin.FullName);
            prm[4] = new SqlParameter("@Status", admin.Status);
            prm[5] = new SqlParameter("@IsLogin", admin.IsLogin);

            #endregion

            #region Execute

            try
            {
                DataHelper.ExecuteNonQuery(STORE_INSERT, prm);

                //AdminInfo admin2 = (AdminInfo)System.Web.HttpContext.Current.Session[Constant.SessionNameAccountAdmin];
                //if (admin2 != null)
                //{
                //    LogAdminInfo log = new LogAdminInfo();

                //    log.AdminName = admin.Username;
                //    log.CreateLog = DateTime.Now;
                //    log.Action = 2;
                //    log.Description = "Thêm mới quản trị viên hệ thống : " + admin2.Username;

                //    insertLog(log);
                //}
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
            admin.ID = (int)prm[0].Value;

            #endregion

            return admin;
        }

        public AdminInfo Update(AdminInfo admin)
        {
            var prm = new SqlParameter[6];

            prm[0] = new SqlParameter("@ID", admin.ID);
            prm[1] = new SqlParameter("@Username", admin.Username);
            prm[2] = new SqlParameter("@Password", Encrypt.MD5Admin(admin.Password));
            prm[3] = new SqlParameter("@FullName", admin.FullName);
            prm[4] = new SqlParameter("@Status", admin.Status);
            prm[5] = new SqlParameter("@IsLogin", admin.IsLogin);

            try
            {
                DataHelper.ExecuteNonQuery(STORE_UPDATE, prm);

                //AdminInfo admin2 = (AdminInfo)System.Web.HttpContext.Current.Session[Constant.SessionNameAccountAdmin];
                //if (admin2 != null)
                //{
                //    LogAdminInfo log = new LogAdminInfo();

                //    log.AdminName = admin2.Username;
                //    log.CreateLog = DateTime.Now;
                //    log.Action = 2;
                //    log.Description = "Cập nhật quản trị viên hệ thống : " + admin2.Username;

                //    insertLog(log);
                //}
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đang bận, xin vui lòng truy vấn lại sau.");
            }
            return admin;
        }

        public void Delete(int id)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ID", id);

            try
            {
                DataHelper.ExecuteNonQuery(STORE_DELETE, prm);

                //AdminInfo admin2 = (AdminInfo)System.Web.HttpContext.Current.Session[Constant.SessionNameAccountAdmin];
                //if (admin2 != null)
                //{
                //    //LogAdminInfo log = new LogAdminInfo();

                //    //log.AdminName = admin2.Username;
                //    //log.CreateLog = DateTime.Now;
                //    //log.Action = 2;
                //    //log.Description = "Xóa quản trị viên hệ thống : " + id;
                //    //insertLog(log);
                //}
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public List<AdminInfo> GetAdmin(DataTable dt)
        {
            var list = new List<AdminInfo>();

            #region BindData to Entity

            if (dt != null && dt.Rows.Count > 0)
            {
                var admin = new AdminInfo();
                DataRow dr = dt.Rows[0];
                //ID
                if (dr[FieldNames.Admin.ID] != null && dr[FieldNames.Admin.ID].ToString() != "")
                    admin.ID = (int)dr[FieldNames.Admin.ID];

                //Username
                if (dr[FieldNames.Admin.Username] != null && dr[FieldNames.Admin.Username].ToString() != "")
                    admin.Username = (string)dr[FieldNames.Admin.Username];

                //Password
                if (dr[FieldNames.Admin.Password] != null && dr[FieldNames.Admin.Password].ToString() != "")
                    admin.Password = (string)dr[FieldNames.Admin.Password];

                //FullName
                if (dr[FieldNames.Admin.FullName] != null && dr[FieldNames.Admin.FullName].ToString() != "")
                    admin.FullName = (string)dr[FieldNames.Admin.FullName];

                //Status
                if (dr[FieldNames.Admin.Status] != null && dr[FieldNames.Admin.Status].ToString() != "")
                    admin.Status = Convert.ToInt16(dr[FieldNames.Admin.Status]);

                //IsLogin
                if (dr[FieldNames.Admin.IsLogin] != null && dr[FieldNames.Admin.IsLogin].ToString() != "")
                    admin.IsLogin = Convert.ToInt16(dr[FieldNames.Admin.IsLogin]);
                list.Add(admin);
            }

            #endregion

            return list;
        }

        #endregion

        public DataTable Test()
        {
            var param = new[]
                            {
                                new SqlParameter("@pageIndex", SqlDbType.Int) {Value = 1},
                                new SqlParameter("@pageSize", SqlDbType.Int) {Value = 2},
                                new SqlParameter("@RowCount", SqlDbType.Int) {Direction = ParameterDirection.Output},
                            };

            IDataReader aa = DataHelper.ExecuteReader("SERVER=LICLOCAL;UID=uLic_System;PWD=123;database=Lic_Logictics",
                                                      "usp_News_ListNew", param);
            object obj = param[2].Value;
            return null;
        }
    }

    public class MenuImpl : IMenu
    {
        private const string STORE_GET_ALL = "sp_Factory_SelectAll";

        private const string STORE_GET_ONE = "sp_Menu_SelectOne";

        #region IMenu Members

        public DataTable GetOneMenu(int id)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ID", id);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_ONE, prm, CommandType.StoredProcedure).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        #endregion
    }

    public class UserRightImpl : IUserRight
    {
        private const string STORE_GET_ALL_QUYEN_BY_ADMINID = "spGetQuyenByMenuParent";

        private const string STORE_GET_PARENT_MENU_BY_ADMINID = "spGetParentMenuByAdminID";

        private const string STORE_GET_MENU_BY_ADMINID_AND_PARENTID = "spGetMenuByAdminID";

        private const string STORE_GET_FULL_PARENT_MENU = "spGetFullParentMenu";

        private const string STORE_GET_FULL_MENU_BY_PARENTID = "spGetFullMenuByParentID";

        private const string STORE_GET_PARENT_MENU_BY_ID = "spGetParentMenuByID";

        private const string STORE_GET_RIGHT_BY_MENUID = "spGetRightByMenuID";

        private const string STORE_GET_RIGHT_BY_MENUID_ADMINID = "spGetRightByMenuIDAndAdminID";

        protected const string STORE_INSERT = "sp_UserRight_Insert";

        protected const string STORE_UPDATE = "sp_UserRight_Update";
        protected const string STORE_GET_PARENT_ID = "spGetParentID";

        #region IUserRight Members

        public UserRightInfo Insert(UserRightInfo userRight)
        {
            #region Parameter

            var prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            prm[0].Direction = ParameterDirection.Output;
            prm[1] = new SqlParameter("@MenuID", userRight.MenuID);
            prm[2] = new SqlParameter("@AdminID", userRight.AdminID);
            prm[3] = new SqlParameter("@UserRead", userRight.UserRead);
            prm[4] = new SqlParameter("@UserEdit", userRight.UserEdit);
            prm[5] = new SqlParameter("@UserDelete", userRight.UserDelete);

            #endregion

            #region Execute

            try
            {
                DataHelper.ExecuteNonQuery(STORE_INSERT, prm);
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
            userRight.ID = (int)prm[0].Value;

            #endregion

            return userRight;
        }

        public UserRightInfo Update(UserRightInfo userRight)
        {
            #region Parameter

            var prm = new SqlParameter[6];
            prm[0] = new SqlParameter("@ID", userRight.ID);
            prm[1] = new SqlParameter("@MenuID", userRight.MenuID);
            prm[2] = new SqlParameter("@AdminID", userRight.AdminID);
            prm[3] = new SqlParameter("@UserRead", userRight.UserRead);
            prm[4] = new SqlParameter("@UserEdit", userRight.UserEdit);
            prm[5] = new SqlParameter("@UserDelete", userRight.UserDelete);

            #endregion

            #region Execute

            try
            {
                DataHelper.ExecuteNonQuery(STORE_UPDATE, prm);
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }

            #endregion

            return userRight;
        }

        public UserRightInfo GetRightByMenuAndAdmin(int menuID, int adminID)
        {
            var prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@MenuID", menuID);
            prm[1] = new SqlParameter("@AdminID", adminID);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_RIGHT_BY_MENUID_ADMINID, prm, CommandType.StoredProcedure)
                        .Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                    return null;
                List<UserRightInfo> list = GetRight(dt);
                if (list != null && list.Count > 0)
                    return list[0];
                return null;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetFullParentMenu()
        {
            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_FULL_PARENT_MENU, null, CommandType.StoredProcedure).
                        Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetFullMenuByParentID(int parentID)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ParentID", parentID);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_FULL_MENU_BY_PARENTID, prm, CommandType.StoredProcedure).
                        Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetParentMenuByID(int ID)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ID", ID);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_PARENT_MENU_BY_ID, prm, CommandType.StoredProcedure).
                        Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetQuyenByAdminID(int adminID, int type)
        {
            var prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@ID", adminID);
            prm[1] = new SqlParameter("@Type", type);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_ALL_QUYEN_BY_ADMINID, prm, CommandType.StoredProcedure).
                        Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetParentMenuByAdminID(int adminID)
        {
            var prm = new SqlParameter[1];

            prm[0] = new SqlParameter("@ID", adminID);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_PARENT_MENU_BY_ADMINID, prm, CommandType.StoredProcedure)
                        .Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public DataTable GetMenuByAdminIDAndParentID(int adminID, int parrentID)
        {
            var prm = new SqlParameter[2];

            prm[0] = new SqlParameter("@ID", adminID);
            prm[1] = new SqlParameter("@ParentID", parrentID);

            try
            {
                DataTable dt =
                    DataHelper.ExecuteQueryToDataSet(STORE_GET_MENU_BY_ADMINID_AND_PARENTID, prm,
                                                     CommandType.StoredProcedure).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("Hiện tại server đạng bận, xin vui lòng truy vấn lại sau.");
            }
        }

        public UserRightInfo CheckRightAdmin()
        {
            var right = new UserRightInfo();
            if (HttpContext.Current.Session[Constant.SessionNameAccountAdmin] != null &&
                HttpContext.Current.Session[Constant.SessionNameAccountAdmin].ToString() != string.Empty)
            {
                string sCurr = HttpContext.Current.Request.Url.AbsoluteUri;

                string linkCur = sCurr.Substring(sCurr.LastIndexOf("/") + 1);

                linkCur = linkCur.Substring(0, linkCur.IndexOf(".aspx") + 5);

                var objAdmin = (AdminInfo)HttpContext.Current.Session[Constant.SessionNameAccountAdmin];

                if (objAdmin.Status == 2)
                {
                    right.UserEdit = true;
                    right.UserRead = true;
                    right.UserDelete = true;
                }
                else
                {
                    var prm = new SqlParameter[2];

                    prm[0] = new SqlParameter("@AdminID", objAdmin.ID);
                    prm[1] = new SqlParameter("@Link", linkCur);

                    DataTable dt =
                        DataHelper.ExecuteQueryToDataSet(STORE_GET_RIGHT_BY_MENUID, prm, CommandType.StoredProcedure).
                            Tables[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        right.UserRead = (bool)dt.Rows[0]["UserRead"];
                        right.UserEdit = (bool)dt.Rows[0]["UserEdit"];
                        right.UserDelete = (bool)dt.Rows[0]["UserDelete"];
                    }
                    else
                    {
                        right.UserRead = false;
                        right.UserEdit = false;
                        right.UserDelete = false;
                    }
                }

                if (!right.UserRead)
                    HttpContext.Current.Response.Redirect(Utility.UrlRoot + Config.PathNotRight, true);
            }
            else
            {
                HttpContext.Current.Response.Redirect(Utility.UrlRoot + Config.LoginAdmin, true);
            }


            return right;
        }

        public List<UserRightInfo> GetRight(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                var listUserRight = new List<UserRightInfo>();
                foreach (DataRow dr in dt.Rows)
                {
                    var userRight = new UserRightInfo();
                    //ID
                    if (dr[FieldNames.UserRight.ID] != null && dr[FieldNames.UserRight.ID].ToString() != "")
                        userRight.ID = (int)dr[FieldNames.UserRight.ID];

                    //MenuID
                    if (dr[FieldNames.UserRight.MenuID] != null && dr[FieldNames.UserRight.MenuID].ToString() != "")
                        userRight.MenuID = (int)dr[FieldNames.UserRight.MenuID];

                    //AdminID
                    if (dr[FieldNames.UserRight.AdminID] != null && dr[FieldNames.UserRight.AdminID].ToString() != "")
                        userRight.AdminID = (int)dr[FieldNames.UserRight.AdminID];

                    //UserRead
                    if (dr[FieldNames.UserRight.UserRead] != null && dr[FieldNames.UserRight.UserRead].ToString() != "")
                        userRight.UserRead = (bool)dr[FieldNames.UserRight.UserRead];

                    //UserEdit
                    if (dr[FieldNames.UserRight.UserEdit] != null && dr[FieldNames.UserRight.UserEdit].ToString() != "")
                        userRight.UserEdit = (bool)dr[FieldNames.UserRight.UserEdit];

                    //UserDelete
                    if (dr[FieldNames.UserRight.UserDelete] != null &&
                        dr[FieldNames.UserRight.UserDelete].ToString() != "")
                        userRight.UserDelete = (bool)dr[FieldNames.UserRight.UserDelete];

                    listUserRight.Add(userRight);
                }
                return listUserRight;
            }
            return null;
        }

        #endregion

        public static UserRightInfo CheckRightAdminnistrator()
        {
            return new UserRightImpl().CheckRightAdmin();
        }

        public static int GetParentID(string link)
        {
            DataTable dt = null;

            #region Parameter

            var prm = new SqlParameter[1];
            prm[0] = new SqlParameter("@Link", link);

            #endregion

            #region Execute

            try
            {
                dt = DataHelper.ExecuteQueryToDataSet(STORE_GET_PARENT_ID, prm, CommandType.StoredProcedure).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    int SoLonNhat = Convert.ToInt32(dt.Rows[0]["ID"]);

                    return SoLonNhat;
                }
            }
            catch (Exception ex)
            {
                Utility.LogEvent(ex);
                throw new Exception("GetData::GetParentID::Error", ex);
            }

            #endregion

            return 0;
        }
    }
}