using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.People
{
    public class SavePersonSportService
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IPersonRepository _personRepository;

            public Handler(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            protected override async Task Handle(Command command)
            {
                var person = await _personRepository.Get(command.PersonId).ConfigureAwait(false);

                person.SetService(command.DebutDate,
                                  command.FreeAgentSigningDate,
                                  command.LastAppearnceDate);

                await _personRepository.Update(person).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SavePersonSportServiceViewModel _viewModel;

            public Command(SavePersonSportServiceViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public DateTime? DebutDate => _viewModel.DebutDate;

            public DateTime? FreeAgentSigningDate => _viewModel.FreeAgentSigningDate;

            public DateTime? LastAppearnceDate => _viewModel.LastAppearanceDate;

            public int PersonId => _viewModel.PersonId;
        }
    }
}
