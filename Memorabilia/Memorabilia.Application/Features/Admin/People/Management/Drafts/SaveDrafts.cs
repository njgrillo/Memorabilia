namespace Memorabilia.Application.Features.Admin.People.Management.Drafts;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveDrafts
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            foreach (DraftEditModel draft in command.Drafts)
            {
                person.SetDraft(draft.Id, draft.Franchise.Id, draft.Year ?? 0, draft.Round ?? 0, draft.Pick, draft.Overall);
            }

            person.RemoveDrafts(command.DeletedDraftIds);

            await personRepository.Update(person);
        }
    }

    public class Command(DraftsEditModel editModel)
        : DomainCommand, ICommand
    {
        public int[] DeletedDraftIds
            => editModel.Drafts
                        .Where(draft => draft.Id > 0 && draft.IsDeleted)
                        .Select(draft => draft.Id)
                        .ToArray();

        public DraftEditModel[] Drafts
            => editModel.Drafts
                        .Where(draft => !draft.IsDeleted)
                        .ToArray();

        public int PersonId
            => editModel.PersonId;
    }
}
