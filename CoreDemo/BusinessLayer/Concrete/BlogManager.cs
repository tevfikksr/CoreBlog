using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetBlogListWCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogListCategoryByWriter(int id)
        {
            return _blogDal.GetListCategoryWriter(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetLast()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
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

        public Blog GetById(int id)
        {
            return _blogDal.TGetByID(id);
        }

    }
}
