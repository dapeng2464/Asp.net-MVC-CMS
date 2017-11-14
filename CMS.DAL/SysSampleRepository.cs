using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CMS.DAL
{
   public class SysSampleRepository :BaseRepository<SysSample>, ISysSampleRepository, IDisposable
    {
       

        public int Delete ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                SysSample entity = db.SysSample.SingleOrDefault ( a => a.Id == id );
                db.Set<SysSample> ( ).Remove ( entity );
                return db.SaveChanges ( );
            }
        }
        
       public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }
        
       public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
