using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZhongXinPay.Startup))]
namespace ZhongXinPay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
