using MediatR;
using System;
using System.Threading.Tasks;

namespace Framework.Handler
{
    public abstract class CommandHandler<TCommand> : AsyncRequestHandler<TCommand> where TCommand : ICommand
    {
        //private readonly IUnitOfWork _unitOfWork;

        //protected CommandHandler(ICommandServices commandServices)
        //{
        //    _unitOfWork = commandServices.UnitOfWork;
        //}

        protected abstract Task Handle(TCommand command);

        protected override sealed async Task HandleCore(TCommand command)
        {
            await Handle(command);

            //if (command.IsValid)
            //{
            //    await _unitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);

            //    OnUnitOfWorkCompleted?.Invoke();
            //}
        }

        protected Action OnUnitOfWorkCompleted { get; private set; }
    }
}
