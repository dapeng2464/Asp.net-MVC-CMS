using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface INoteRepository:IBaseRepository<Note>
    {
        int Delete ( string id );
        Note GetById ( string id );
        bool IsExist ( string id );
        IQueryable<Note> GetByCat ( DBContainer db, string cat );
    }
}
