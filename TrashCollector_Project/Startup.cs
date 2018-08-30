using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashCollector_Project.Startup))]
namespace TrashCollector_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
