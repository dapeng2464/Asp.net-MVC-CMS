using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        public User Login ( string username, string pwd )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                User user = db.User.SingleOrDefault ( a => a.UserName == username && a.Password == pwd );
                return user;
            }
        }
        public void Dispose ( )
        {

        }
    }
}
