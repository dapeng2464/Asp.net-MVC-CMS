using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IBLL
{
    public interface IAccountBLL
    {
       User Login ( string username, string pwd );
    }
}
