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
    public class NoteController : BaseController
    {
        // ISysSampleBLL m_BLL = new SysSampleBLL ( );
        //
        // GET: /SysSample/
        private static string editCat=null;
        [Dependency]
        public INoteBLL m_BLL { get; set; }
        [Dependency]
        public ICategoryBLL c_BLL { get; set; }

        

        public ActionResult GridTable ( )
        {

            return View ( );
        }



        [HttpPost]
        public JsonResult GetList ( GridPager pager )
        {
            List<Note> list = m_BLL.GetList ( ref pager, true );
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

        [HttpPost]
        public JsonResult GetListByCat ( GridPager pager, string categoryName )
        {
            List<Note> list = m_BLL.GetListByCat ( ref pager, categoryName );//.GetList ( ref pager, true );
            var json = new
            {
                total = pager.totalRows,
                rows = list


            };

            return Json ( json, JsonRequestBehavior.AllowGet );
        }

        #region 创建
        public ActionResult Create ( )
        {
            GenerateCategoryViewData ( );
            return View ( );
        }

        [HttpPost]
        public JsonResult Create ( Note model )
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
            GenerateCategoryViewData ( );
            Note entity = m_BLL.GetById ( id );
            editCat = entity.Category;
            return View ( entity );
        }

        [HttpPost]

        public JsonResult Edit ( Note model )
        {

            model.LastViewedPerson = this.GetUserTrueName();
            model.LastViewedTime = ResultHelper.NowTime;
            if(model.Category == null)
                model.Category = editCat;
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
            Note entity = m_BLL.GetById ( id );
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
            GridPager pager = new GridPager ( );

            List<Category> list = c_BLL.GetList ( ref pager, false );
            foreach(Category ct in list)
            {
                categoryList.Add ( new SelectListItem { Text = ct.Name, Value = ct.Name } );
            }

            return categoryList;
        }
        #endregion

    }
}