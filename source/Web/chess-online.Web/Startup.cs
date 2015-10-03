using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chess_online.Web.Startup))]
namespace chess_online.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
