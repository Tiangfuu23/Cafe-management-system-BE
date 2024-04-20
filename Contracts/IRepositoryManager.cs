namespace Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryUser RepositoryUser { get; }

        IRepositoryRole RepositoryRole { get; }

        IRepositoryCategory RepositoryCategory { get; }
        void Save();
    }
}
