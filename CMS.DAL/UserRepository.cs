using CMS.IDAL;
using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {


        public int Delete ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                User entity = db.User.SingleOrDefault ( a => a.Id == id );
                db.Set<User> ( ).Remove ( entity );
                return db.SaveChanges ( );
            }
        }

        public User GetById ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                return db.User.SingleOrDefault ( a => a.Id == id );
            }
        }

        public bool IsExist ( string id )
        {
            using(DBContainer db = new DBContainer ( ))
            {
                User entity = GetById ( id );
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