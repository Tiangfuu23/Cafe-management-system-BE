namespace Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryUser RepositoryUser { get; }

        IRepositoryRole RepositoryRole { get; }

        IRepositoryCategory RepositoryCategory { get; }

        IRepositoryProduct RepositoryProduct{get; }
        void Save();
    }
}
