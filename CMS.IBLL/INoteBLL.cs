using CMS.Common;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface INoteBLL:IBaseBLL
    {
        List<Note> GetList ( ref GridPager pager, bool IsPaging );
        bool Create ( Note model );
        bool Delete ( string id );
        bool Edit ( Note model );
        Note GetById ( string id );
        bool IsExist ( string id );
        List<Note> GetListByCat ( ref GridPager pager, string cat ); 
    }
}
