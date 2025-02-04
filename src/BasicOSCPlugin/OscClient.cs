using System.Net;
using System.Net.Sockets;
using System.Text;

using Loupedeck.BasicOSCPlugin;

public static class OscClient
{
    public static void SendOscMessage(String ip, Int32 port, String address, Single value)
    {
        using (var udpClient = new UdpClient())
        {
            udpClient.Connect(ip, port);
            var message = $"{address} {value}";
            var data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length);
        }
    }
}