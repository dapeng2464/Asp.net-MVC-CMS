using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        int Delete ( string id );
        Category GetById ( string id );
        bool IsExist ( string id );
    }
}