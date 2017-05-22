using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCalcNew.Startup))]
namespace WebCalcNew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
