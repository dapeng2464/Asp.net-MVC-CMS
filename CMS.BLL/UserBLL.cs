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
    public class UserBLL : BaseBLL, IUserBLL
    {
        [Dependency]
        public IUserRepository Rep { get; set; }

        public List<User> GetList ( ref GridPager pager, bool IsPaging )
        {

            IQueryable<User> queryData = null;

            queryData = Rep.GetList ( db );

            //排序
            if(pager.order == "desc")
            {
                switch(pager.sort)
                {
                    case "CreateTime":
                        queryData = queryData.OrderByDescending ( c => c.CreateTime );
                        break;
                    case "FirstName":
                        queryData = queryData.OrderByDescending ( c => c.FirstName );
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
                    case "FirstName":
                        queryData = queryData.OrderBy ( c => c.FirstName );
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
                List<User> result = queryData.ToList ( );
                return result;
            }//
        }
        private List<User> CreateModelList ( ref GridPager pager, ref IQueryable<User> queryData )
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
            List<User> modelList = queryData.ToList ( );
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

        public bool Create ( User entity )
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

        public bool Edit ( User entity )
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
            if(db.User.SingleOrDefault ( a => a.Id == id ) != null)
            {
                return true;
            }
            return false;
        }

        public User GetById ( string id )
        {
            if(IsExist ( id ))
            {
                User entity = Rep.GetById ( id );


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
