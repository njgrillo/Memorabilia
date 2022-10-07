using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

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
            var person = await _personRepository.Get(command.PersonId);

            person.SetService(command.DebutDate,
                              command.FreeAgentSigningDate,
                              command.LastAppearnceDate);

            UpdateColleges(command, person);
            UpdateDrafts(command, person);

            await _personRepository.Update(person);
        }

        private static void UpdateColleges(Command command, Person person)
        {
            person.RemoveColleges(command.DeletedCollegeIds);

            foreach (var college in command.Colleges)
            {
                person.SetCollege(college.CollegeId, college.BeginYear, college.EndYear);
            }
        }

        private static void UpdateDrafts(Command command, Person person)
        {
            person.RemoveDrafts(command.DeletedDraftIds);

            foreach (var draft in command.Drafts)
            {
                person.SetDraft(draft.FranchiseId, draft.Year ?? 0, draft.Round ?? 0, draft.Pick, draft.Overall);
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

        public SavePersonCollegeViewModel[] Colleges => _viewModel.Colleges.Where(college => !college.IsDeleted).ToArray();

        public DateTime? DebutDate => _viewModel.DebutDate;

        public int[] DeletedCollegeIds => _viewModel.Colleges.Where(college => college.IsDeleted).Select(college => college.Id).ToArray();

        public int[] DeletedDraftIds => _viewModel.Drafts.Where(draft => draft.IsDeleted).Select(draft => draft.Id).ToArray();

        public SavePersonDraftViewModel[] Drafts => _viewModel.Drafts.Where(record => !record.IsDeleted).ToArray();

        public DateTime? FreeAgentSigningDate => _viewModel.FreeAgentSigningDate;

        public DateTime? LastAppearnceDate => _viewModel.LastAppearanceDate;

        public int PersonId { get; set; }
    }
}
