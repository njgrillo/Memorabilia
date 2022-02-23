using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Book
{
    public class SaveBook
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task Handle(Command command)
            {
                var memorabilia = await _memorabiliaRepository.Get(command.MemorabiliaId).ConfigureAwait(false);

                memorabilia.SetBook(command.Bookplate,
                                    command.PersonIds,
                                    command.SportIds,
                                    command.TeamIds,
                                    command.Title);

                await _memorabiliaRepository.Update(memorabilia).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveBookViewModel _viewModel;

            public Command(SaveBookViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public bool Bookplate => _viewModel.Bookplate;

            public int MemorabiliaId => _viewModel.MemorabiliaId;

            public int[] PersonIds => _viewModel.People.Select(person => person.Id).ToArray();

            public int[] SportIds => _viewModel.SportIds.ToArray();

            public int[] TeamIds => _viewModel.Teams.Select(team => team.Id).ToArray();

            public string Title => _viewModel.Title;
        }
    }
}
