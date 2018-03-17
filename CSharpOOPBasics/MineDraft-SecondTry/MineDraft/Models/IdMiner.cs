
public abstract class IdMiner : IIdMiner
{
    private string id;

    protected IdMiner(string id)
    {
        Id = id;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        private set
        {
            this.id = value;
        }
    }
}