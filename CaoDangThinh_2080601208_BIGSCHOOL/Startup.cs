using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaoDangThinh_2080601208_BIGSCHOOL.Startup))]
namespace CaoDangThinh_2080601208_BIGSCHOOL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
