using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);

        //void CommentDelete(Comment comment);

        //void CommentUpdate(Comment comment);

        List<Comment> GetList(int id);

        //Comment GetById(int id);
    }
}

