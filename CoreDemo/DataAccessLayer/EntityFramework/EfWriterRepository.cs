using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
    {
        IWriterDal writerDal;
        public Writer GetFilter(Expression<Func<Writer, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Writers.FirstOrDefault(filter);
            }
        }
    }
}
