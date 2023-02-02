using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
   public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
   {
        public List<Blog> GetListWithCategory()
        {
            using(var C = new Context())
            {
                 return C.Blogs.Include(x => x.Category).ToList();
            }

        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var C = new Context())
            {
                return C.Blogs.Include(x => x.Category).Where(x=>x.WriterId == id).ToList();
            }
        }
    }
}

