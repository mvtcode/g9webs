using System.Collections.Generic;
using LicSystem.Entity;

namespace LicSystem.Service
{
    public interface IComment
    {
        int Update(CommentInfo oComment);
        int Insert(CommentInfo oComment);
        int Delete(int id);
        CommentInfo GetInfo(int id);
        List<CommentInfo> getListTop(int numbetTop);
        List<CommentInfo> getList(int pageIndex, int pageSize,out int totalrow);
    }
}
