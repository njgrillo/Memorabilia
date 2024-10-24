namespace Memorabilia.Application.Features.Admin.People.Management.Awards;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveAwards
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person;

            person = await personRepository.Get(command.PersonId);

            foreach (AwardEditModel award in command.Awards)
            {
                person.SetAward(award.Id, award.AwardType.Id, award.Year ?? 0);
            }

            person.RemoveAwards(command.DeletedAwardIds);

            await personRepository.Update(person);
        }
    }

    public class Command(AwardsEditModel editModel)
        : DomainCommand, ICommand
    {
        public AwardEditModel[] Awards
            => editModel.Awards
                        .Where(award => !award.IsDeleted)
                        .ToArray();

        public int[] DeletedAwardIds
            => editModel.Awards
                        .Where(award => award.Id > 0 && award.IsDeleted)
                        .Select(award => award.Id)
                        .ToArray();        

        public int PersonId
            => editModel.PersonId;
    }
}
