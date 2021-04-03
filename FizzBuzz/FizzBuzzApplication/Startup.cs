using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FizzBuzzApplication.Startup))]
namespace FizzBuzzApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
