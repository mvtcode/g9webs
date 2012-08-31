using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace Website
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["CurrentUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurrentUsers"] = System.Convert.ToInt32(Application["CurrentUsers"]) + 1;
            Application.UnLock();

            int count_visit = 0;
            //Kiểm tra file count_visit.txt nếu không tồn  tại thì
            if (System.IO.File.Exists(Server.MapPath("/count_visit.txt")) == false)
            {
                count_visit = 1;
            }
            // Ngược lại thì
            else
            {
                // Đọc dử liều từ file count_visit.txt
                System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("/count_visit.txt"));
                count_visit = int.Parse(read.ReadLine());
                read.Close();
                // Tăng biến count_visit thêm 1
                count_visit++;
            }
            // khóa m
            Application.Lock();

            // gán biến Application count_visit
            Application["count_visit"] = count_visit;

            // Mở khóa website
            Application.UnLock();

            // Lưu dử liệu vào file  count_visit.txt
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("/count_visit.txt"));
            writer.WriteLine(count_visit);
            writer.Close();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["CurrentUsers"] = System.Convert.ToInt32(Application["CurrentUsers"]) - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}