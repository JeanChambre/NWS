using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;


namespace MSExampleSignalR
{
    public class MyHub : Hub
    {
        public void Send(string senderUserName,string message)
        {
            Clients.All.addMessage(senderUserName, message);
        }      
        public void Heartbeat()
        {
            Console.WriteLine("Hub Verbindungs Test\n");
            Clients.All.heartbeat();
        }

        public override Task OnConnected()
        {
            Console.WriteLine("Hub OnConnected {0}\n", Context.ConnectionId);
            return (base.OnConnected());
        }

        public override Task OnDisconnected()
        {
            Console.WriteLine("Hub OnDisconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }

        public override Task OnReconnected()
        {
            Console.WriteLine("Hub OnReconnected {0}\n", Context.ConnectionId);
            return (base.OnDisconnected());
        }
    }
}