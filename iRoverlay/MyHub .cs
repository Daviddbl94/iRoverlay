using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace iRoverlay
{
    public class MyHub : Hub
    {
        public void SendMessage(string message)
        {
            Clients.All.ReceiveMessage(message); // Define el método para enviar mensajes a los clientes
        }
    }
}
