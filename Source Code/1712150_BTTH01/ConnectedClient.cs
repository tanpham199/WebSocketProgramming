using System.Net.WebSockets;

namespace _1712150_BTTH01
{
    public class ConnectedClient
    {
        public ConnectedClient(int socketId, WebSocket socket)
        {
            SocketId = socketId;
            Socket = socket;
        }

        public int SocketId { get; private set; }

        public WebSocket Socket { get; private set; }
    }
}
