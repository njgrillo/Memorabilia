namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames;

[AuthorizeByRole(Enum.Role.Admin)]
public class SaveSportHallOfFamers
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
            foreach (SportHallOfFameEditModel hallOfFame in command.HallOfFames)
            {
                if (hallOfFame.SportLeagueLevelId == 0 || hallOfFame.GetPersonId() == 0)
                    continue;

                Entity.Person person = persons.Single(x => x.Id == hallOfFame.GetPersonId());

                if (hallOfFame.Id > 0 && hallOfFame.IsDeleted)
                {
                    person.RemoveHallOfFames(hallOfFame.Id);
                }
                else
                {
                    person.SetHallOfFame(
                        hallOfFame.SportLeagueLevelId,
                        hallOfFame.InductionYear,
                        hallOfFame.VotePercentage,
                        hallOfFame.BallotNumber
                        );
                }

                await personRepository.Update(person);
            }
        }
    }

    public class Command(SportHallOfFamesEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<SportHallOfFameEditModel> HallOfFames
            => editModel.HallOfFames
                        .ToList();

        public int[] PersonIds
            => editModel.HallOfFames
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
