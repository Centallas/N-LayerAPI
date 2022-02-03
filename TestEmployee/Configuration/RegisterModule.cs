using Autofac;
using Business_Logic_Layer.Service;
using Data_Access_Layer;
using Data_Access_Layer.Repository;

namespace Web_API.Configuration
{
    public class RegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            
            builder.RegisterType<Employee>().As<IEmployee>();

            // Other Lifetime
            // Transient
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .InstancePerDependency();

            //// Scoped
            builder.RegisterType<EmployeeService>().As<IEmployeeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Employee>().As<IEmployee>()
                .InstancePerLifetimeScope();


            //// Singleton
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .SingleInstance();
        }
    }
}

