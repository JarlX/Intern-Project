using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageRepository :GenericRepository<Message>,IMessageDal
    {
       
    }
}

