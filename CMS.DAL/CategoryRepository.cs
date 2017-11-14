using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {


        public int Delete ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                Category entity = db.Category.SingleOrDefault ( a => a.Id == id );
                db.Set<Category> ( ).Remove ( entity );
                return db.SaveChanges ( );
            }
        }

        public Category GetById ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                return db.Category.SingleOrDefault ( a => a.Id == id );
            }
        }

        public bool IsExist ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                Category entity = GetById ( id );
                if(entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose ( )
        {

        }
    }
}
