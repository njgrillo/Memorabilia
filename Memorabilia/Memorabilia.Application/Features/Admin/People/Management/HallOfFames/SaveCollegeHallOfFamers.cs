namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveCollegeHallOfFamers
{
    public class Handler(IPersonRepository personRepository)
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            if (command.PersonIds.Length == 0)
                return;

            Entity.Person[] persons = await personRepository.GetAll(command.PersonIds);

            await UpdateHallOfFames(command, persons);
        }

        private async Task UpdateHallOfFames(Command command, Entity.Person[] persons)
        {
            foreach (CollegeHallOfFameEditModel hallOfFame in command.HallOfFames)
            {
                if (hallOfFame.CollegeId == 0 || hallOfFame.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == hallOfFame.GetPersonId());

                if (hallOfFame.Id > 0 && hallOfFame.IsDeleted)
                {
                    person.RemoveCollegeHallOfFames(hallOfFame.Id);
                }
                else
                {
                    person.SetCollegeHallOfFame(hallOfFame.Id, hallOfFame.CollegeId, hallOfFame.Year);
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(CollegeHallOfFamesEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<CollegeHallOfFameEditModel> HallOfFames
            => editModel.HallOfFames
                        .ToList();

        public int[] PersonIds
            => editModel.HallOfFames
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
