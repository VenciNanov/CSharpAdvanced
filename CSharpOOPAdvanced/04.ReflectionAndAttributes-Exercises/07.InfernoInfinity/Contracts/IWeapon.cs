public interface IWeapon
{
    string Name { get; set; }

    void AddGem(int socket, IGem gem);
    void Remove(int socket);
}