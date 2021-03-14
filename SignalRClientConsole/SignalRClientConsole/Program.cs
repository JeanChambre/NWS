using System;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;


namespace SignalRClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client  http://localhost:8080");
            Console.WriteLine("Name eingeben");
            string username = Console.ReadLine();
           
            var hubConnection = new HubConnection("http://localhost:8080/");
            IHubProxy myHubProxy = hubConnection.CreateHubProxy("MyHub");

            myHubProxy.On<string, string>("addMessage", (name, message) => Console.Write(name + ": " + message + "\n"));
            myHubProxy.On("heartbeat", () => Console.Write("Verbindungstest erhalten \n"));

            hubConnection.Start().Wait();
            Console.WriteLine("Eine Nachricht normal eingeben um sie an alle Clienten zusenden" +
                "\n \"2\" Verbindung zum Server und Clienten testen" +
                "\n \"3\" Beenden");
            while (true)
            {
                string key = Console.ReadLine();              
                if (key == "2")
                {
                    myHubProxy.Invoke("Heartbeat").ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine("Fehler bei Verbindung:{0}", task.Exception.GetBaseException());
                        }

                    }).Wait();
                    Console.WriteLine("Verbindung getestet \n");
                }
                
                if (key.ToUpper() == "3")
                {
                    break;
                }
                else
                {
                    
                    myHubProxy.Invoke("Send", username, key).ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            Console.WriteLine("Fehler bei Verbindung:{0} \n", task.Exception.GetBaseException());
                        }

                    }).Wait();
                }
            }

        }
    }
}
