namespace libEventHandler.tools;
public interface ICommnunication<T>
{
  public bool OpenConnection();
  public bool CloseConnection();
  public void Read(T t);
  public T Write();
}