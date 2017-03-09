using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbsenceManagement.WebUi.Startup))]
namespace AbsenceManagement.WebUi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
