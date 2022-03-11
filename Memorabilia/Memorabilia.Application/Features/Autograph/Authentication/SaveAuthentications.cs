using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Authentication
{
    public class SaveAuthentications
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IAutographRepository _autographRepository;

            public Handler(IAutographRepository autographRepository)
            {
                _autographRepository = autographRepository;
            }

            protected override async Task Handle(Command command)
            {
                var autograph = await _autographRepository.Get(command.AutographId).ConfigureAwait(false);

                foreach (var authentication in command.Items)
                {
                    autograph.SetAuthentication(authentication.Id,
                                                authentication.AuthenticationCompanyId,
                                                authentication.HasCertificationCard,
                                                authentication.HasHologram,
                                                authentication.HasLetter,
                                                authentication.Verification,
                                                authentication.Witnessed);
                }

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveAuthenticationsViewModel _viewModel;

            public Command(SaveAuthenticationsViewModel viewModel)
            {
                _viewModel = viewModel;
                Items = _viewModel.Authentications;
            }

            public int AutographId => _viewModel.AutographId;

            public IEnumerable<SaveAuthenticationViewModel> Items { get; set; }
        }
    }
}
