using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCanteen.Startup))]
namespace TheCanteen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
