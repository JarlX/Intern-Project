using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context()) 
            {
                return c.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}

