namespace Memorabilia.Application.Features.Admin.People.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveInternationalHallOfFamers
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
            foreach (InternationalHallOfFameEditModel hallOfFame in command.HallOfFames)
            {
                if (hallOfFame.InternationalHallOfFameTypeId == 0 || hallOfFame.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == hallOfFame.GetPersonId());

                if (hallOfFame.Id > 0 && hallOfFame.IsDeleted)
                {
                    person.RemoveInternationalHallOfFames(hallOfFame.Id);
                }
                else
                {
                    person.SetInternationalHallOfFame(hallOfFame.Id, hallOfFame.InternationalHallOfFameTypeId, hallOfFame.Year);
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(InternationalHallOfFamesEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<InternationalHallOfFameEditModel> HallOfFames
            => editModel.HallOfFames
                        .ToList();

        public int[] PersonIds
            => editModel.HallOfFames
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
