using CMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.IDAL;

namespace CMS.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class,new ( ) 
    {
        public IQueryable<T> GetList ( DBContainer db )
        {
            IQueryable<T>
                list = db.Set<T>().AsQueryable ( );
            return list;
        }

        public int Create ( T entity )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                db.Set<T> ( ).Add ( entity );
                return db.SaveChanges ( );
            }
        }



        public int Edit ( T entity )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                db.Set<T> ( ).Attach ( entity );
                db.Entry<T> ( entity ).State = EntityState.Modified;
                return db.SaveChanges ( );
            }
        }
    }
}
