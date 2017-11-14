using CMS.Model;
using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface ISysSampleBLL:IBaseBLL
    {
        List<SysSample> GetList(ref GridPager pager,bool IsPaging);
        bool Create( SysSample model);
        bool Delete( string id);
        bool Edit( SysSample model);
        SysSample GetById(string id);
        bool IsExist(string id);
    }
}

