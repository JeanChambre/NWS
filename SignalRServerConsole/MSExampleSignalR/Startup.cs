using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace MSExampleSignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    
                };
                hubConfiguration.EnableDetailedErrors = true;
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}