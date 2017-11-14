using CMS.Admin;
using CMS.Common;
using CMS.IBLL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace WebApp.Controllers
{
    public class UserController : BaseController
    {
        private static string editPSW = null;
        [Dependency]
        public IUserBLL m_BLL { get; set; }

        

        public ActionResult GridTable ( )
        {

            return View ( );
        }



        [HttpPost]
        public JsonResult GetList ( GridPager pager )
        {
            List<User> list = m_BLL.GetList ( ref pager, true );
            var json = new
            {
                total = pager.totalRows,
                rows = list
                //( from r in list
                // select new SysSample ( )
                // {

                //     Id = r.Id,
                //     Name = r.Name,
                //     Age = r.Age,
                //     Bir = r.Bir,
                //     Photo = r.Photo,
                //     Note = r.Note,
                //     CreateTime = r.CreateTime,

                // } ).ToArray ( )

            };

            return Json ( json, JsonRequestBehavior.AllowGet );
        }

        #region 创建
        public ActionResult Create ( )
        {
            return View ( );
        }

        [HttpPost]
        public JsonResult Create ( User model )
        {

            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.Password = ValueConvert.MD5 ( model.Password );
            model.CreatePerson = this.GetUserTrueName();
            if(m_BLL.Create ( model ))
            {
                return Json ( 1, JsonRequestBehavior.AllowGet );
            }
            else
            {
                return Json ( 0, JsonRequestBehavior.AllowGet );
            }

        }
        #endregion

        #region 修改

        public ActionResult Edit ( string id )
        {

            User entity = m_BLL.GetById ( id );
            editPSW = entity.Password;
            entity.Password = "******";
            return View ( entity );
        }

        [HttpPost]

        public JsonResult Edit ( User model )
        {
            if(model.Password == "******") 
            {
                model.Password =editPSW ;
            }
            else
            {
                model.Password = ValueConvert.MD5 ( model.Password );
            }
            if(m_BLL.Edit ( model ))
            {
                return Json ( 1, JsonRequestBehavior.AllowGet );
            }
            else
            {
                return Json ( 0, JsonRequestBehavior.AllowGet );
            }

        }
        #endregion

        #region 详细
        public ActionResult Details ( string id )
        {
            User entity = m_BLL.GetById ( id );
            return View ( entity );
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete ( string id )
        {
            if(!string.IsNullOrWhiteSpace ( id ))
            {
                if(m_BLL.Delete ( id ))
                {
                    return Json ( 1, JsonRequestBehavior.AllowGet );
                }
                else
                {

                    return Json ( 0, JsonRequestBehavior.AllowGet );
                }
            }
            else
            {
                return Json ( 0, JsonRequestBehavior.AllowGet );
            }


        }
        #endregion

    }
}
