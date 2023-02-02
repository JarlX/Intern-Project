using System;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
   
        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }




        //public void BlogAdd(Category blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogDelete(Category blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public void BlogUpdate(Category blog)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Blog> GetBlogListWithCategory()
        //{
        //    return _blogDal.GetListWithCategory();
        //}

        //public Blog GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Blog> GetBlogById(int id)
        //{
        //    return _blogDal.GetListAll(x => x.BlogId == id);
        //}

        //public List<Blog> GetList()
        //{
        //    return _blogDal.GetListAll();
        //}

        //public List<Blog> GetLast3Blog()
        //{
        //    return _blogDal.GetListAll().Take(3).ToList();
        //}
        //public List<Blog> GetBlogListByWriter(int id)
        //{
        //    return _blogDal.GetListAll(x => x.WriterId == id);
        //}
    }
}

