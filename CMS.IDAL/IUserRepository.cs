using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface IUserRepository:IBaseRepository<User>
    {
        int Delete ( string id );
        User GetById ( string id );
        bool IsExist ( string id );
    }
}
