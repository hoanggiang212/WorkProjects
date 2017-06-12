using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TbsGroup.Startup))]
namespace TbsGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
