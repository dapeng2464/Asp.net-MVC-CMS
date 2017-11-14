using CMS.Admin;
using CMS.IBLL;
using CMS.Model;
using CMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace WebApp.Controllers
{
     public class HomeController : BaseController
    {
         
         AccountModel account = new AccountModel();
       
        // GET: /Home/
        [Dependency]
        public IHomeBLL homeBLL { get; set; }
        

        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        /// 
         [HttpPost]
        public JsonResult GetTree(string id)
        {
            string a = id;
                List<SysModule> menus = homeBLL.GetMenuByPersonId(id);
                string v = id;
                var jsonData = (
                        from m in menus
                        select new
                        {
                            id = m.Id,
                            text = m.Name,
                            value = m.Url,
                            showcheck = false,
                            complete = false,
                            isexpand = false,
                            checkstate = 0,
                            hasChildren = m.IsLast ? false : true,
                            Icon = m.Iconic
                        }
                    ).ToArray();
                return Json(jsonData, JsonRequestBehavior.AllowGet);
          
        }

    }
}
