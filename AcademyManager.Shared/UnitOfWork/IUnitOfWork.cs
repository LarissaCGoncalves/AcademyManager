namespace AcademyManager.Shared.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
