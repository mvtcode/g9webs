using NLog;

namespace LicSystem.Core
{
    public class Logger
    {
        public static NLog.Logger Instance
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }
        public const string ErrSelectDb = "Lỗi truy vấn dữ liệu!";
        public const string ErrInsertDb = "Lỗi thêm mới dữ liệu!";
        public const string ErrUpdateDb = "Lỗi cập nhật dữ liệu!";
        public const string ErrDeleteDb = "Lỗi Xóa dữ liệu!";
        public const string ErrPagingDb = "Lỗi phân trang!";
        public const string ErrSystem = "Lỗi hệ thống!";
        public const string ErrConnect = "Lỗi kết nối Database!";
    }
}