using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;

namespace MSExampleSignalR
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.WriteLine(" \"1\" Nachricht an alle Clienten Senden" +
               "\n \"2\" Verbindung zum den Clienten testen" +
               "\n \"3\" Beenden");
                while (true)
                {
                    string key = Console.ReadLine();
                    if (key == "1")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                        hubContext.Clients.All.addMessage("Server", "Test");
                    }
                    if (key == "2")
                    {
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                        hubContext.Clients.All.heartbeat();
                        Console.WriteLine("Verbindung Testen\n");
                    }
                    
                    if (key == "3")
                    {
                        break;
                    }
                }

                Console.ReadLine();
            }
        }
    }
}
