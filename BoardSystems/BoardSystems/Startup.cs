using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoardSystems.Startup))]
namespace BoardSystems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
