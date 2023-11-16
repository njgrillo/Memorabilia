namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonHallOfFame
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            UpdateCollegeHallOfFames(command, person);
            UpdateFranchiseHallOfFames(command, person);
            UpdateHallOfFames(command, person);
            UpdateInternationalHallOfFames(command, person);

            await personRepository.Update(person);
        }

        private static void UpdateCollegeHallOfFames(Command command, Entity.Person person)
        {
            person.RemoveCollegeHallOfFames(command.DeletedCollegeHallOfFameIds);

            foreach (var hallOfFame in command.CollegeHallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetCollegeHallOfFame(hallOfFame.College.Id, 
                                            hallOfFame.Sport.Id, 
                                            hallOfFame.Year);
            }
        }

        private static void UpdateFranchiseHallOfFames(Command command, Entity.Person person)
        {
            person.RemoveFranchiseHallOfFames(command.DeletedFranchiseHallOfFameIds);

            foreach (var hallOfFame in command.FranchiseHallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetFranchiseHallOfFame(hallOfFame.FranchiseHallOfFameType.Franchise.Id, 
                                              hallOfFame.Year);
            }
        }

        private static void UpdateHallOfFames(Command command, Entity.Person person)
        {
            person.RemoveHallOfFames(command.DeletedHallOfFameIds);

            foreach (var hallOfFame in command.HallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetHallOfFame(hallOfFame.SportLeagueLevelId,
                                     hallOfFame.InductionYear,
                                     hallOfFame.VotePercentage,
                                     hallOfFame.BallotNumber > 0 ? hallOfFame.BallotNumber : null);
            }
        }

        private static void UpdateInternationalHallOfFames(Command command, Entity.Person person)
        {
            person.RemoveInternationalHallOfFames(command.DeletedInternationalHallOfFameIds);

            foreach (var hallOfFame in command.InternationalHallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetInternationalHallOfFame(hallOfFame.Id,
                                                  hallOfFame.InternationalHallOfFameTypeId,
                                                  hallOfFame.Year);
            }
        }
    }

    public class Command(int personId, PersonHallOfFamesEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int[] DeletedCollegeHallOfFameIds 
            => editModel.CollegeHallOfFames
                        .Where(hof => hof.IsDeleted)
                        .Select(hof => hof.Id)
                        .ToArray();

        public int[] DeletedFranchiseHallOfFameIds 
            => editModel.FranchiseHallOfFames
                        .Where(hof => hof.IsDeleted)
                        .Select(hof => hof.Id)
                        .ToArray();

        public int[] DeletedHallOfFameIds 
            => editModel.HallOfFames
                        .Where(hof => hof.IsDeleted)
                        .Select(hof => hof.Id)
                        .ToArray();

        public int[] DeletedInternationalHallOfFameIds 
            => editModel.InternationalHallOfFames
                        .Where(hof => hof.IsDeleted)
                        .Select(hof => hof.Id)
                        .ToArray();

        public PersonCollegeHallOfFameEditModel[] CollegeHallOfFames 
            => editModel.CollegeHallOfFames
                        .Where(hof => !hof.IsDeleted)
                        .ToArray();

        public PersonFranchiseHallOfFameEditModel[] FranchiseHallOfFames 
            => editModel.FranchiseHallOfFames
                        .Where(hof => !hof.IsDeleted)
                        .ToArray();

        public PersonHallOfFameEditModel[] HallOfFames 
            => editModel.HallOfFames
                        .Where(hof => !hof.IsDeleted)
                        .ToArray();

        public PersonInternationalHallOfFameEditModel[] InternationalHallOfFames 
            => editModel.InternationalHallOfFames
                        .Where(hof => !hof.IsDeleted)
                        .ToArray();

        public int PersonId { get; } 
            = personId;
    }
}
