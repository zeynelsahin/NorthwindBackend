using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Module = Autofac.Module;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Product
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            //Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            //Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            //Customer
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            //Employee
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            //OperationClaim
            builder.RegisterType<EfOperationClaim>().As<IOperationClaimDal>();
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            //UserOperationClaim
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}