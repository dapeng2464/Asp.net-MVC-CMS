using CMS.Admin;
using CMS.BLL;
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
    public class SysSampleController : BaseController
    {
       // ISysSampleBLL m_BLL = new SysSampleBLL ( );
        //
        // GET: /SysSample/

        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        public ActionResult Index(GridPager pager)
        {

            List<SysSample> list = m_BLL.GetList ( ref pager ,false);
            return View ( list );
        }

        public ActionResult GridTable ( )
        {

            return View ();
        }

       

        [HttpPost]
        public JsonResult GetList ( GridPager pager )
        {
            List<SysSample> list = m_BLL.GetList ( ref pager ,true);
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
        public JsonResult Create ( SysSample model )
        {

            model.CreateTime = ResultHelper.NowTime;
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

            SysSample entity = m_BLL.GetById ( id );
            return View ( entity );
        }

        [HttpPost]

        public JsonResult Edit ( SysSample model )
        {


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
            SysSample entity = m_BLL.GetById ( id );
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
