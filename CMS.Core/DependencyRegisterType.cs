using CMS.BLL;
using CMS.DAL;
using CMS.IBLL;
using CMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CMS.Core
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys ( ref UnityContainer container )
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL> ( );//样例
            container.RegisterType<ISysSampleRepository, SysSampleRepository> ( );

            container.RegisterType<INoteBLL, NoteBLL> ( );//Note
            container.RegisterType<INoteRepository, NoteRepository> ( );

            container.RegisterType<IUserBLL, UserBLL> ( );//user
            container.RegisterType<IUserRepository, UserRepository> ( );

            container.RegisterType<IFileBLL, FileBLL> ( );//File
            container.RegisterType<IFileRepository, FileRepository> ( );

            container.RegisterType<IAccountBLL, AccountBLL> ( );//Account
            container.RegisterType<IAccountRepository, AccountRepository> ( );

            container.RegisterType<ICategoryBLL, CategoryBLL> ( );//Category
            container.RegisterType<ICategoryRepository, CategoryRepository> ( );

            container.RegisterType<IHomeBLL, HomeBLL> ( );
            container.RegisterType<IHomeRepository, HomeRepository> ( );
        }
    }
}

