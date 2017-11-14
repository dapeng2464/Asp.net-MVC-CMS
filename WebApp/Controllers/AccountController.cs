using CMS.Admin;
using CMS.Common;
using CMS.IBLL;
using CMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace WebApp.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        [Dependency]
        public IAccountBLL accountBLL { get; set; }

        public override ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login ( string UserName, string Password ) 
        {
            
            CMS.Model.User user = accountBLL.Login ( UserName, ValueConvert.MD5 ( Password ) );
            if(user == null)
            {
                return Json ( JsonHandler.CreateMessage ( 0, "Username or password error" ), JsonRequestBehavior.AllowGet );
            }
            //else if(!Convert.ToBoolean ( user.Status ))//被禁用
            //{
            //    return Json ( JsonHandler.CreateMessage ( 0, "Account is closed" ), JsonRequestBehavior.AllowGet );
            //}

            AccountModel account = new AccountModel ( );
            account.Id = user.Id;
            account.UserName = user.FirstName + " " + user.LastName ;
            Session["Account"] = account;

            return Json ( JsonHandler.CreateMessage ( 1, "" ), JsonRequestBehavior.AllowGet );
        }

        public ActionResult Logout ( )
        {
            Session["Account"] = null;
            return RedirectToAction ( "Index", "Account" );
        }

    }
}
