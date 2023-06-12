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
            Entity.Person person = await _personRepository.Get(command.PersonId);

            person.SetService(command.DebutDate,
                              command.FreeAgentSigningDate,
                              command.LastAppearanceDate);

            UpdateColleges(command, person);
            UpdateDrafts(command, person);

            await _personRepository.Update(person);
        }

        private static void UpdateColleges(Command command, Entity.Person person)
        {
            person.RemoveColleges(command.DeletedCollegeIds);

            foreach (var college in command.Colleges)
            {
                person.SetCollege(college.College.Id, 
                                  college.BeginYear, 
                                  college.EndYear);
            }
        }

        private static void UpdateDrafts(Command command, Entity.Person person)
        {
            person.RemoveDrafts(command.DeletedDraftIds);

            foreach (var draft in command.Drafts)
            {
                person.SetDraft(draft.Franchise.Id, 
                                draft.Year ?? 0, 
                                draft.Round ?? 0, 
                                draft.Pick, 
                                draft.Overall);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PersonSportServiceEditModel _editModel;

        public Command(int personId, PersonSportServiceEditModel editModel)
        {
            PersonId = personId;
            _editModel = editModel;
        }

        public PersonCollegeEditModel[] Colleges 
            => _editModel.Colleges
                         .Where(college => !college.IsDeleted)
                         .ToArray();

        public DateTime? DebutDate 
            => _editModel.DebutDate;

        public int[] DeletedCollegeIds 
            => _editModel.Colleges
                         .Where(college => college.IsDeleted)
                         .Select(college => college.Id)
                         .ToArray();

        public int[] DeletedDraftIds 
            => _editModel.Drafts
                         .Where(draft => draft.IsDeleted)
                         .Select(draft => draft.Id)
                         .ToArray();

        public PersonDraftEditModel[] Drafts 
            => _editModel.Drafts
                         .Where(record => !record.IsDeleted)
                         .ToArray();

        public DateTime? FreeAgentSigningDate 
            => _editModel.FreeAgentSigningDate;

        public DateTime? LastAppearanceDate 
            => _editModel.LastAppearanceDate;

        public int PersonId { get; set; }
    }
}
