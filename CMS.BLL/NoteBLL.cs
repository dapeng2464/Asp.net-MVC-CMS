using CMS.Common;
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
    public class NoteBLL: BaseBLL,INoteBLL
    {
        [Dependency]
        public INoteRepository Rep { get; set; }

        public List<Note> GetList ( ref GridPager pager, bool IsPaging )
        {

            IQueryable<Note> queryData = null;

            queryData = Rep.GetList ( db );

            //排序
            if(pager.order == "desc")
            {
                switch(pager.sort)
                {
                    case "CreateTime":
                        queryData = queryData.OrderByDescending ( c => c.CreateTime );
                        break;
                    case "Title":
                        queryData = queryData.OrderByDescending ( c => c.Title );
                        break;
                    default:
                        queryData = queryData.OrderByDescending ( c => c.Id );
                        break;
                }
            }
            else
            {

                switch(pager.sort)
                {
                    case "CreateTime":
                        queryData = queryData.OrderBy ( c => c.CreateTime );
                        break;
                    case "Title":
                        queryData = queryData.OrderBy ( c => c.Title );
                        break;
                    default:
                        queryData = queryData.OrderBy ( c => c.Id );
                        break;
                }
            }
            if(IsPaging)
            {
                return CreateModelList ( ref pager, ref queryData );
            }
            else
            {
                List<Note> result = queryData.ToList ( );
                return result;
            }//
        }

        public List<Note> GetListByCat ( ref GridPager pager, string cat )
        {
            IQueryable<Note> queryData = null;
            queryData = Rep.GetByCat ( db, cat );
            queryData = queryData.OrderByDescending ( c => c.CreateTime );
            //List<Note> result = queryData.ToList ( );
            //return result;
            return CreateModelList ( ref pager, ref queryData );
        }

        private List<Note> CreateModelList ( ref GridPager pager, ref IQueryable<Note> queryData )
        {

            pager.totalRows = queryData.Count ( );
            if(pager.totalRows > 0)
            {
                if(pager.page <= 1)
                {
                    queryData = queryData.Take ( pager.rows );
                }
                else
                {
                    queryData = queryData.Skip ( ( pager.page - 1 ) * pager.rows ).Take ( pager.rows );
                }
            }
            List<Note> modelList = queryData.ToList ( );
            //( from r in queryData
            // select new SysSample
            // {
            //     Id = r.Id,
            //     Name = r.Name,
            //     Age = r.Age,
            //     Bir = r.Bir,
            //     Photo = r.Photo,
            //     Note = r.Note,
            //     CreateTime = r.CreateTime,

            // } ).ToList ( );

            return modelList;
        }

        public bool Create ( Note entity )
        {
            try
            {
                if(Rep.Create ( entity ) == 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch(Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete ( string id )
        {
            try
            {
                if(Rep.Delete ( id ) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Edit ( Note entity )
        {
            try
            {
                if(Rep.Edit ( entity ) == 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch(Exception ex)
            {

                //ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool IsExists ( string id )
        {
            if(db.Note.SingleOrDefault ( a => a.Id == id ) != null)
            {
                return true;
            }
            return false;
        }

        public Note GetById ( string id )
        {
            if(IsExist ( id ))
            {
                Note entity = Rep.GetById ( id );


                return entity;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist ( string id )
        {
            return Rep.IsExist ( id );
        }
    }
}
