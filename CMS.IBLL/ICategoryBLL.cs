using CMS.Common;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface ICategoryBLL : IBaseBLL
    {
        List<Category> GetList ( ref GridPager pager, bool IsPaging );
        bool Create ( Category model );
        bool Delete ( string id );
        bool Edit ( Category model );
        Category GetById ( string id );
        bool IsExist ( string id );
    }
}
