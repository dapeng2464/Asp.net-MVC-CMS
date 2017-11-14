using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface ISysSampleRepository:IBaseRepository<SysSample>
    {
        int Delete ( string id );
        SysSample GetById ( string id );
        bool IsExist ( string id );
    }
}
