using CMS.Common;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface IUserBLL : IBaseBLL
    {
        List<User> GetList ( ref GridPager pager, bool IsPaging );
        bool Create ( User model );
        bool Delete ( string id );
        bool Edit ( User model );
        User GetById ( string id );
        bool IsExist ( string id );
    }
}
