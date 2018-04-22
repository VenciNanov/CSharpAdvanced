public interface IWriter
{
    string StoredMessage { get; }

    void StoreMessage(string message);
    void WriteLine(string output);
}