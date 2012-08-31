using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using G9.Core;
using G9.Entity;
using G9.Service;

namespace G9.Impl
{
    public class ContactImpl : IContact
    {
        public int Insert(ContactInfo contact)
        {
            var param = new[]
                            {
                                new SqlParameter("@s_Name", contact.s_Name),
                                new SqlParameter("@s_Title",contact.s_Title),
                                new SqlParameter("@s_Content",contact.s_Content),
                                new SqlParameter("@s_Company",contact.s_Company),
                                new SqlParameter("@s_Phone",contact.s_Phone),
                                new SqlParameter("@s_Email",contact.s_Email),
                                new SqlParameter("@s_Address",contact.s_Address),
                                new SqlParameter("@s_Fax",contact.s_Fax)
                            };
            var x = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Contact_INSERT", param);
            return x;
        }

        public int Delete(int id)
        {
            var param = new[] {new SqlParameter("@pk_ID", id)};
            var x = DataHelper.ExecuteNonQuery(Config.ConnectionString, "usp_Contact_DELETE", param);
            return x;
        }

        public int Update(ContactInfo contact)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID",contact.pk_ID),
                                new SqlParameter("@s_Name", contact.s_Name),
                                new SqlParameter("@s_Title",contact.s_Title),
                                new SqlParameter("@s_Content",contact.s_Content),
                                new SqlParameter("@s_Company",contact.s_Company),
                                new SqlParameter("@s_Phone",contact.s_Phone),
                                new SqlParameter("@s_Email",contact.s_Email),
                                new SqlParameter("@s_Address",contact.s_Address),
                                new SqlParameter("@s_Fax",contact.s_Fax)
                            };
           // var x = DataHelper.ExecuteNonQuery(Config.ConnectionString,,param)
            return -1;
        }

        public ContactInfo GetContactByID(int id)
        {
            var param = new[]
                            {
                                new SqlParameter("@pk_ID", id)
                            };
            var data = DataHelper.ExecuteReader(Config.ConnectionString, "usp_Contact_LoadDetail", param);
            var contactinfo = new ContactInfo();
            while (data.Read())
            {
                contactinfo.pk_ID = Convert.ToInt32(data["pk_ID"]);
                contactinfo.s_Address = data["s_Address"].ToString();
                contactinfo.s_Email = data["s_Email"].ToString();
                contactinfo.s_Name = data["s_Name"].ToString();
                contactinfo.s_Content = data["s_Content"].ToString();
                contactinfo.s_Title = data["s_Title"].ToString();
                contactinfo.s_Phone = data["s_Phone"].ToString();
                contactinfo.s_Company = data["s_Company"].ToString();
                contactinfo.s_Fax = data["s_Fax"].ToString();
                contactinfo.d_Create = Convert.ToDateTime(data["d_Create"]);
            }
            return contactinfo;
        }

        public DataTable GetListContactToDataTable()
        {
            return DataHelper.ExecuteQueryToDataSet("Select * from tbl_Contact", null, CommandType.Text).Tables[0];
        }

        public List<ContactInfo> GetListContact()
        {
            throw new NotImplementedException();
        }
    }
}
