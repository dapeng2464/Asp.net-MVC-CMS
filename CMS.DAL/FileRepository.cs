using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class FileRepository : BaseRepository<File>, IFileRepository
    {


        public int Delete ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                File entity = db.File.SingleOrDefault ( a => a.Id == id );
                db.Set<File> ( ).Remove ( entity );
                return db.SaveChanges ( );
            }
        }

        public File GetById ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                return db.File.SingleOrDefault ( a => a.Id == id );
            }
        }
        public IQueryable<File> GetByCat ( DBContainer db,string cat )
        {
            string a = cat;
            
                IQueryable<File> result = ( from c in db.File
                                      where c.Category == cat 
                                      select c );
                return result;//db.File.Where<File> ( a => a.Category == cat ).Select ( c => new { } );
            
        }

        public bool IsExist ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                File entity = GetById ( id );
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