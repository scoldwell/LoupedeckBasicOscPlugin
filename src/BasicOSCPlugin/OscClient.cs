using System.Net;
using System.Net.Sockets;
using System.Text;

using Loupedeck.BasicOSCPlugin;

using OscCore;

public static class OscClient
{
    public static void SendOscMessage(String ip, Int32 port, String address, Single value)
    {
        using (var udpClient = new UdpClient())
        {
            udpClient.Connect(ip, port);
            var message = new OscMessage(address, value);
            var buffer = new Byte[message.SizeInBytes];
            message.Write(buffer, 0);
            udpClient.SendAsync(buffer);
        }
    }
}