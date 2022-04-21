using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Domain.Entities;
using Memorabilia.Repository.Interfaces;
using System;
using System.Linq;
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

                UpdateDrafts(command, person);

                await _personRepository.Update(person).ConfigureAwait(false);
            }

            private static void UpdateDrafts(Command command, Person person)
            {
                person.RemoveDrafts(command.DeletedDraftIds);

                foreach (var draft in command.Drafts)
                {
                    person.SetDraft(draft.FranchiseId, draft.Year, draft.Round, draft.Pick, draft.Overall);
                }
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SavePersonSportServiceViewModel _viewModel;

            public Command(int personId, SavePersonSportServiceViewModel viewModel)
            {
                PersonId = personId;
                _viewModel = viewModel;
            }

            public DateTime? DebutDate => _viewModel.DebutDate;

            public int[] DeletedDraftIds => _viewModel.Drafts.Where(draft => draft.IsDeleted).Select(draft => draft.Id).ToArray();

            public SavePersonDraftViewModel[] Drafts => _viewModel.Drafts.Where(record => !record.IsDeleted).ToArray();

            public DateTime? FreeAgentSigningDate => _viewModel.FreeAgentSigningDate;

            public DateTime? LastAppearnceDate => _viewModel.LastAppearanceDate;

            public int PersonId { get; set; }
        }
    }
}
