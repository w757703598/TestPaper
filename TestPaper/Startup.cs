using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestPaper.Startup))]
namespace TestPaper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
