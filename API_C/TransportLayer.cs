
using System.Net.Sockets;

namespace API_C;
internal class TransportLayer(string address, int port) : IDisposable
{
  public void Dispose()
  {
      if(Connection == null)
      return;

    Connection.Close();
    Connection = null;
  }
  public bool OpenConnection()
  {
    Connection = new TcpClient(address, port);
    return true;
  }
  public bool write(byte[] stream, int size)
  {
    if(Connection != null && !Connection.Connected)
      return false;
      Connection!.GetStream().Write(stream, 0 , size);
      Connection!.GetStream().Flush();
    return true;
  }
  public bool read(byte[] stream, int outputSize)
  {
    if(Connection !=null && !Connection.Connected && Connection.Available <= 0)
      return false;
    outputSize =  Connection!.GetStream().Read(stream);
    return true;
  }
  public TcpClient? Connection { get; private set; }


  //PRIVATE
  readonly string address = address;
  readonly int port = port;
}
