namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonSportService
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            person.SetService(command.DebutDate,
                              command.FreeAgentSigningDate,
                              command.LastAppearanceDate);

            UpdateColleges(command, person);
            UpdateDrafts(command, person);

            await personRepository.Update(person);
        }

        private static void UpdateColleges(Command command, Entity.Person person)
        {
            person.RemoveColleges(command.DeletedCollegeIds);

            foreach (var college in command.Colleges)
            {
                person.SetCollege(college.Id,
                                  college.College.Id, 
                                  college.BeginYear, 
                                  college.EndYear);
            }
        }

        private static void UpdateDrafts(Command command, Entity.Person person)
        {
            person.RemoveDrafts(command.DeletedDraftIds);

            foreach (var draft in command.Drafts)
            {
                person.SetDraft(draft.Id,
                                draft.Franchise.Id, 
                                draft.Year ?? 0, 
                                draft.Round ?? 0, 
                                draft.Pick, 
                                draft.Overall);
            }
        }
    }

    public class Command(int personId, PersonSportServiceEditModel editModel) 
        : DomainCommand, ICommand
    {
        public PersonCollegeEditModel[] Colleges 
            => editModel.Colleges
                        .Where(college => !college.IsDeleted)
                        .ToArray();

        public DateTime? DebutDate 
            => editModel.DebutDate;

        public int[] DeletedCollegeIds 
            => editModel.Colleges
                        .Where(college => college.IsDeleted)
                        .Select(college => college.Id)
                        .ToArray();

        public int[] DeletedDraftIds 
            => editModel.Drafts
                        .Where(draft => draft.IsDeleted)
                        .Select(draft => draft.Id)
                        .ToArray();

        public PersonDraftEditModel[] Drafts 
            => editModel.Drafts
                        .Where(record => !record.IsDeleted)
                        .ToArray();

        public DateTime? FreeAgentSigningDate 
            => editModel.FreeAgentSigningDate;

        public DateTime? LastAppearanceDate 
            => editModel.LastAppearanceDate;

        public int PersonId { get; set; } 
            = personId;
    }
}
