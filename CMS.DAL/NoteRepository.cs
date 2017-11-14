using CMS.Model;
using CMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class NoteRepository:BaseRepository<Note>,INoteRepository
    {


        public int Delete ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                Note entity = db.Note.SingleOrDefault ( a => a.Id == id );
                db.Set<Note> ( ).Remove ( entity );
                return db.SaveChanges ( );
            }
        }

        public Note GetById ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                return db.Note.SingleOrDefault ( a => a.Id == id );
            }
        }

        public IQueryable<Note> GetByCat ( DBContainer db, string cat )
        {
            string a = cat;

            IQueryable<Note> result = ( from c in db.Note
                                        where c.Category == cat
                                        select c );
            return result;//db.File.Where<File> ( a => a.Category == cat ).Select ( c => new { } );

        }

        public bool IsExist ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                Note entity = GetById ( id );
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
