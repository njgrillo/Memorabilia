namespace Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.AllStars;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportAllStars
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.AllStars.Count == 0)
                return;           

            Entity.Person[] persons = await personRepository.GetAll(command.PersonIds);

            await UpdateAllStars(command, persons);
        }

        private async Task UpdateAllStars(Command command, Entity.Person[] persons)
        {
            foreach (SportAllStarEditModel allStar in command.AllStars)
            {
                if (allStar.Year == 0 || allStar.Person?.Id == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == allStar.Person.Id);

                if (allStar.Id > 0 && allStar.IsDeleted)
                {
                    person.RemoveAllStars(allStar.Id);
                }
                else
                {
                    person.SetAllStars(allStar.Id, allStar.Sport.Id, allStar.SportLeagueLevel?.Id, allStar.Year ?? 0);
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(SportAllStarsEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<SportAllStarEditModel> AllStars
            => editModel.AllStars
                        .ToList();

        public int[] PersonIds
            => editModel.AllStars
                        .Select(x => x.Person.Id)
                        .ToArray();
    }
}
