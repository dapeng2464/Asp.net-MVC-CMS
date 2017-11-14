using CMS.Admin;
using CMS.Common;
using CMS.IBLL;
using CMS.Model;
using CMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace WebApp.Controllers
{
    public class FileController : BaseController
    {
        [Dependency]
        public IFileBLL m_BLL { get; set; }
        [Dependency]
        public ICategoryBLL c_BLL { get; set; }

        

        public ActionResult GridTable ( )
        {

            return View ( );
        }



        [HttpPost]
        public JsonResult GetList ( GridPager pager )
        {
            List<CMS.Model.File> list = m_BLL.GetList ( ref pager, true );
            var json = new
            {
                total = pager.totalRows,
                rows = list
                

            };

            return Json ( json, JsonRequestBehavior.AllowGet );
        }

        [HttpPost]
        public JsonResult GetListByCat ( GridPager pager,string categoryName )
        {
            List<CMS.Model.File> list = m_BLL.GetListByCat ( ref pager,categoryName);//.GetList ( ref pager, true );
            var json = new
            {
                total = pager.totalRows,
                rows = list


            };

            return Json ( json, JsonRequestBehavior.AllowGet );
        }

        #region Upload
        public ActionResult Upload ( )
        {
            GenerateCategoryViewData ( );
            return View ( );
        }

        [HttpPost]
        public ActionResult Upload ( FileModel Fmodel )
        {
            CMS.Model.File model = new CMS.Model.File ( );
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            model.CreatePerson = this.GetUserTrueName();
            model.Category = Fmodel.Category;
            model.Description = Fmodel.Description;

            if(ModelState.IsValid)
            {
                var fileName = Fmodel.Files.FileName;
                var filePath = Server.MapPath ( string.Format ( "~/{0}", "File" ) );
                model.FileName = fileName;
                model.FileAddress = filePath;
                Fmodel.Files.SaveAs ( Path.Combine ( filePath, fileName ) );
                ModelState.Clear ( );
            }
            else 
            {
                return Json ( "File upload failed", JsonRequestBehavior.AllowGet );
            }       
            
            if(m_BLL.Create ( model ))
            {
                return Json ( "File upload success", JsonRequestBehavior.AllowGet );
            }
            else
            {
                return Json ( "File upload failed", JsonRequestBehavior.AllowGet );
            }

        }
        #endregion

        #region Download
        [HttpGet]
        public ActionResult Download(string FileName) 
        {
            var filePath = Server.MapPath ( string.Format ( "~/{0}", "File" ) );
            string url = filePath + "\\"+FileName ;
            if(System.IO.File.Exists ( url))
            {
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader ( "Content-Disposition", "attachment; filename=\"" + Server.HtmlEncode ( FileName ) + "\"" );
                Response.TransmitFile (url );
                Response.End ( );
            }
            else
                Response.Redirect ( "404.aspx" );
            return View ( );
        }
        #endregion

        #region 修改

        public ActionResult Edit ( string id )
        {

            CMS.Model.File entity = m_BLL.GetById ( id );
            return View ( entity );
        }

        [HttpPost]

        public JsonResult Edit ( CMS.Model.File model )
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
            CMS.Model.File entity = m_BLL.GetById ( id );
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