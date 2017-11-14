using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.IDAL
{
    public interface IFileRepository:IBaseRepository<File>
    {
        int Delete ( string id );
        File GetById ( string id );
        bool IsExist ( string id );
        IQueryable<File> GetByCat ( DBContainer db,string cat );
    }
}
