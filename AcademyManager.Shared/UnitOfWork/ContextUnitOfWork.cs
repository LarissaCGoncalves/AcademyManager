namespace AcademyManager.Shared.UnitOfWork
{
    public interface IContextUnitOfWork
    {
        IUnitOfWork ContextUnitOfWork { get; }
    }
}
