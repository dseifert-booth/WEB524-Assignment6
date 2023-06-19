using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(F2022A6DSB.Startup))]

namespace F2022A6DSB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
