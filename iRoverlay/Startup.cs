// Startup.cs
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(iRoverlay.Startup))]
namespace iRoverlay
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR(); // Configura SignalR en la aplicación
        }
    }
}
