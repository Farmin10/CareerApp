using Autofac;
using Autofac.Extras.DynamicProxy;
using career.BLL.Abstract;
using career.BLL.Concrete;
using career.DAL.Abstract;
using career.DAL.Concrete.EntityFramework;
using career.DAL.DataAccess;
using career.DAL.DataAccess.EntityFramework;
using career.DAL.Utilities.Interceptors;
using career.DAL.Utilities.Security.JWT;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace career.BLL.DependencyResolvers
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType< VacancyTypeManager  >().As<IVacancyTypeService>();
            builder.RegisterType<EfVacancyTypeDal>().As< IVacancyTypeDal  >();

            builder.RegisterType<DepartmantManager>().As< IDepartmantService  >();
            builder.RegisterType<EfDepartmantDal>().As< IDepartmantDal > ();

            builder.RegisterType<CountManager>().As< ICountService > ();

            builder.RegisterType<PositionManager>().As< IPositionService > ();
            builder.RegisterType<EfPositionDal>().As< IPositionDal > ();

            builder.RegisterType<VacancyManager>().As< IVacancyService > ();
            builder.RegisterType<EfVacancyDal>().As< IVacancyDal > ();

            builder.RegisterType<UserManager>().As< IUserService > ();
            builder.RegisterType<EfUserDal>().As< IUserDal > ();

            builder.RegisterType<AuthManager>().As< IAuthService > ();
            builder.RegisterType<JwtHelper>().As< ITokenHelper > ();


            builder.RegisterType<EmployeeManager>().As< IEmployeeService > ();
            builder.RegisterType<EfEmployeeDal>().As< IEmployeeDal > ();

            builder.RegisterType<PictureManager>().As< IPictureService > ();
            builder.RegisterType<EfPictureDal>().As< IPictureDal > ();

            builder.RegisterType<ProjectManager>().As< IProjectService > ();
            builder.RegisterType<EfProjectDal>().As< IProjectDal>();


            builder.RegisterType<UnitOfwork>().As< IUnitOfWork > ();

            builder.RegisterType<VacancyInformationManager>().As< IVacancyInformationService > ();
            builder.RegisterType<EfVacancyInformationDal>().As< IVacancyInformationDal > ();

            builder.RegisterType<VacancyRequirementManager>().As< IVacancyRequirementService > ();
            builder.RegisterType<EfVacancyRequirementDal>().As< IVacancyRequirementDal > ();

            builder.RegisterType<AppealManager>().As< IAppealService > ();
            builder.RegisterType<EfAppealDal>().As< IAppealDal > ();

            builder.RegisterType<NewsManager>().As< INewsService > ();
            builder.RegisterType<EfNewsDal>().As< INewsDal > ();

            builder.RegisterType<FileManager>().As< IFileService > ();
            builder.RegisterType<EfFileDal>().As< IFileDal > ();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
