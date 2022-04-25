using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Autograph.Inscriptions
{
    public class SaveInscriptions
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

                autograph.RemoveInscriptions(command.DeletedIds);

                foreach (var inscription in command.Items.Where(item => !item.IsDeleted))
                {
                    autograph.SetInscription(inscription.Id,
                                             inscription.InscriptionTypeId,
                                             inscription.InscriptionText);
                }

                await _autographRepository.Update(autograph).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveInscriptionsViewModel _viewModel;

            public Command(SaveInscriptionsViewModel viewModel)
            {
                _viewModel = viewModel;
                Items = _viewModel.Inscriptions;
            }

            public int AutographId => _viewModel.AutographId;

            public int[] DeletedIds => Items.Where(item => item.IsDeleted).Select(item => item.Id).ToArray();

            public IEnumerable<SaveInscriptionViewModel> Items { get; set; }
        }
    }
}
