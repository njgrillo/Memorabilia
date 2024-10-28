namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveFranchiseHallOfFamers
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
            foreach (FranchiseHallOfFameEditModel hallOfFame in command.HallOfFames)
            {
                if (hallOfFame.FranchiseId == 0 || hallOfFame.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == hallOfFame.GetPersonId());

                if (hallOfFame.Id > 0 && hallOfFame.IsDeleted)
                {
                    person.RemoveFranchiseHallOfFames(hallOfFame.Id);
                }
                else
                {
                    person.SetFranchiseHallOfFame(hallOfFame.FranchiseId, hallOfFame.Year);
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(FranchiseHallOfFamesEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<FranchiseHallOfFameEditModel> HallOfFames
            => editModel.HallOfFames
                        .ToList();

        public int[] PersonIds
            => editModel.HallOfFames
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
