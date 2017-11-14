using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface IAccountRepository
    {
        User Login ( string username, string pwd );
    }
}
