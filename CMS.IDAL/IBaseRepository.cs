using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface IBaseRepository<T> where T:class,new()
    {
        IQueryable<T> GetList ( DBContainer db );
        int Create ( T entity );
        int Edit ( T entity );
        
    }
}
