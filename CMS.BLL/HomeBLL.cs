using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.IBLL;
using CMS.Model;
using Unity.Attributes;
using CMS.IDAL;

namespace CMS.BLL
{
    public class HomeBLL : IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }
        public List<SysModule> GetMenuByPersonId ( string moduleId )
        {
            return HomeRepository.GetMenuByPersonId ( moduleId );
        }
    }
}
