using Framework.Handler;

namespace Demo.Framework.Handler
{
    public class CommandServices : ICommandServices
    {
        public CommandServices(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }
    }
}
