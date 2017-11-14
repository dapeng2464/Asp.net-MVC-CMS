using CMS.Common;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface IFileBLL : IBaseBLL
    {
        List<File> GetList ( ref GridPager pager, bool IsPaging );
        bool Create ( File model );
        bool Delete ( string id );
        bool Edit ( File model );
        File GetById ( string id );
        List<File> GetListByCat ( ref GridPager pager, string cat ); 
        bool IsExist ( string id );
    }
}
