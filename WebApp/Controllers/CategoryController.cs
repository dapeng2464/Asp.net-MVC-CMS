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
    public class CategoryController : BaseController
    {
        // ISysSampleBLL m_BLL = new SysSampleBLL ( );
        //
        // GET: /SysSample/

        [Dependency]
        public ICategoryBLL m_BLL { get; set; }



        public ActionResult GridTable ( )
        {

            return View ( );
        }

        public ActionResult CategoryDetails (string categoryName ) 
        {
            //Category model = new Category ( );
            //model.Name = categoryName;
            ViewData["CategoryName"] = categoryName;
            return View (  );
        }


        [HttpPost]
        public JsonResult GetList ( GridPager pager )
        {
            List<Category> list = m_BLL.GetList ( ref pager, true );
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
                //     Category = r.Category,
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
        public JsonResult Create ( Category model )
        {

            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = this.GetUserTrueName ( );
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

            Category entity = m_BLL.GetById ( id );
            return View ( entity );
        }

        [HttpPost]

        public JsonResult Edit ( Category model )
        {

            //Name is PK, so we delete old one and add a new record
            if(!m_BLL.Delete ( model.Id )) {
                return Json ( 2, JsonRequestBehavior.AllowGet );
            }
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

        #region 详细
        public ActionResult Details ( string id )
        {
            Category entity = m_BLL.GetById ( id );
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

        #region
        public void GenerateCategoryViewData ( ) 
        {
            ViewData["Category"] = GetTimeHourList ( );
        }

        private List<SelectListItem> GetTimeHourList ( )
        {
            List<SelectListItem> categoryList = new List<SelectListItem> ( );
             GridPager pager=new GridPager();

             List<Category> list = m_BLL.GetList ( ref pager, false );
             foreach(Category ct in list) {
                 categoryList.Add ( new SelectListItem { Text = ct.Name, Value=ct.Name } );
             }

             return categoryList;
        }
        #endregion

    }
}