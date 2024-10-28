using Memorabilia.Application.Features.Admin.Sports.Management.Accomplishments.Leaders;

namespace Memorabilia.Application.Features.Admin.Sports.Management.HallOfFames.Sports;

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
            foreach (HallOfFameEditModel hallOfFame in command.HallOfFames)
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

    public class Command(SportHallOfFameEditModel editModel)
        : DomainCommand, ICommand
    {
        public List<HallOfFameEditModel> HallOfFames
            => editModel.HallOfFames
                        .ToList();

        public int[] PersonIds
            => editModel.HallOfFames
                        .Select(x => x.GetPersonId())
                        .Distinct()
                        .ToArray();
    }
}
