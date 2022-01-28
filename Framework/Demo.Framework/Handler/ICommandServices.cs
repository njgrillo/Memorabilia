namespace Framework.Handler
{
    public interface ICommandServices
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
