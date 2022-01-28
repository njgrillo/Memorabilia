using Framework.Extension;
using Framework.Handler;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Framework.Web
{
    public class MvcController : Controller
    {
        private IMediator _mediator;

        public MvcController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task SendCommand(ICommand command)
        {
            MvcController mvcController = this;
            await mvcController._mediator.Send(command, new CancellationToken()).ConfigureAwait(false);
            if (command.IsValid)
                return;
            ValidationResult validationResult = command.ValidationResult;
            if (validationResult == null)
                return;
            validationResult.AddToModelState((ModelStateDictionary)mvcController.ModelBinderFactory, null);
        }

        protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request)
        {
            return _mediator.Send(request, new CancellationToken());
        }
    }
}
