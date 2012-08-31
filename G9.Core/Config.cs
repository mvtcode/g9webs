using System.Configuration;

namespace G9.Core
{
    public class Config
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["LicvnDB03142012"]; }
        }

        public static string ImagePath
        {
            get { return ConfigurationManager.AppSettings["ImgPath"]; }
        }

        public static string PathAdmin
        {
            get { return ConfigurationManager.AppSettings["PathAdmin"]; }
        }

        public static string LoginAdmin
        {
            get { return ConfigurationManager.AppSettings["LoginAdmin"]; }
        }

        public static string PathNotRight
        {
            get { return ConfigurationManager.AppSettings["PathNotRight"]; }
        }

        public static string PathError
        {
            get { return ConfigurationManager.AppSettings["PathError"]; }
        }

        public static string RecordPerPage
        {
            get { return ConfigurationManager.AppSettings["PageSizeAdmin"]; }
        }

        public static string PathUpload
        {
            get { return ConfigurationManager.AppSettings["ImgPath"]; }
        }

        public static string PathImgThumbs
        {
            get { return ConfigurationManager.AppSettings["ImgThumbs"]; }
        }

        public static string GetPathImage
        {
            get { return "/" + PathUpload + "/"; }
        }

        public static string GetPathImageThumb
        {
            get { return PathUpload + "/" + PathImgThumbs + "/"; }
        }

        public static string UsernameSendMail
        {
            get { return ConfigurationManager.AppSettings["UsernameSendMail"]; }
        }

        public static string PassSendMail
        {
            get { return ConfigurationManager.AppSettings["PassSendMail"]; }
        }
        public static string PageSizeProduct
        {
            get { return ConfigurationManager.AppSettings["iPageSizeProduct"]; }
        }

        public static string PageSizeAdmin
        {
            get { return ConfigurationManager.AppSettings["PageSizeAdmin"]; }
        }
        public static string PathProduct
        {
            get { return ConfigurationManager.AppSettings["ProductPath"]; }
        }
        public static string PathProductShow
        {
            get { return ConfigurationManager.AppSettings["PathProductShow"]; }
        }
    }
}