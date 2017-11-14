using CMS.IBLL;
using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;

namespace CMS.BLL
{
    public class AccountBLL : BaseBLL, IAccountBLL
    {
        [Dependency]
        public IAccountRepository accountRepository { get; set; }
        public User Login ( string username, string pwd )
        {
            return accountRepository.Login ( username, pwd );

        }
    }
}
