using System.Collections.Generic;
using G9.Entity;

namespace G9.Service
{
    public interface ICusComment
    {
        int Update(CommentInfo oComment);
        int Insert(CommentInfo oComment);
        int Delete(int id);
        CommentInfo GetInfo(int id);
        List<CommentInfo> getListTop(int numbetTop);
        List<CommentInfo> getList(int pageIndex, int pageSize,out int totalrow);
    }
}
