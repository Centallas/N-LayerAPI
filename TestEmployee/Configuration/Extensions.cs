using Microsoft.Extensions.DependencyInjection;

namespace Web_API.Configuration
{
    public static class Extensions
    {
        public static void ControllerConfiguration(this IServiceCollection  services)
        {
            services.AddControllers();
           
        }
    }
}
