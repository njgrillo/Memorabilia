namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportLeaders
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.PersonIds.Length == 0)
                return;

            Entity.Person[] persons = await personRepository.GetAll(command.PersonIds);

            await UpdateLeaders(command, persons);
        }

        private async Task UpdateLeaders(Command command, Entity.Person[] persons)
        {
            foreach (LeaderEditModel leader in command.Leaders)
            {
                if (leader.LeaderTypeId == 0 || leader.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == leader.GetPersonId());

                if (leader.Id > 0 && leader.IsDeleted)
                {
                    person.RemoveLeaders(leader.Id);
                }
                else
                {
                    person.SetLeader(leader.Id, leader.LeaderTypeId, leader.Year ?? 0);
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(SportLeadersEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<LeaderEditModel> Leaders
            => editModel.Leaders
                        .ToList();

        public int[] PersonIds
            => editModel.Leaders
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
