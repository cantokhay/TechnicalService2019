using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tech2019.WebLayer
{
    public class Global : System.Web.HttpApplication
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            DependencyInjectionConfig.ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

    }
}