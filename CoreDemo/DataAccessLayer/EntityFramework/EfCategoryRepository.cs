using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        Context d = new Context();
        public void CategoryStatus(int id)
        {
            var value = d.Categories.Find(id);

            if (value.CategoryStatus)
            {
                value.CategoryStatus = false;
            }
            else
            {
                value.CategoryStatus = true;
            }
            d.SaveChanges();
        }
    }
}
