namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public class SavePersonHallOfFame
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.Person person = await _personRepository.Get(command.PersonId);

            UpdateCollegeHallOfFames(command, person);
            UpdateFranchiseHallOfFames(command, person);
            UpdateHallOfFames(command, person);
            UpdateInternationalHallOfFames(command, person);

            await _personRepository.Update(person);
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

    public class Command : DomainCommand, ICommand
    {
        private readonly PersonHallOfFamesEditModel _editModel;

        public Command(int personId, PersonHallOfFamesEditModel editModel)
        {               
            PersonId = personId;
            _editModel = editModel;
        }

        public int[] DeletedCollegeHallOfFameIds 
            => _editModel.CollegeHallOfFames
                         .Where(hof => hof.IsDeleted)
                         .Select(hof => hof.Id)
                         .ToArray();

        public int[] DeletedFranchiseHallOfFameIds 
            => _editModel.FranchiseHallOfFames
                         .Where(hof => hof.IsDeleted)
                         .Select(hof => hof.Id)
                         .ToArray();

        public int[] DeletedHallOfFameIds 
            => _editModel.HallOfFames
                         .Where(hof => hof.IsDeleted)
                         .Select(hof => hof.Id)
                         .ToArray();

        public int[] DeletedInternationalHallOfFameIds 
            => _editModel.InternationalHallOfFames
                         .Where(hof => hof.IsDeleted)
                         .Select(hof => hof.Id)
                         .ToArray();

        public PersonCollegeHallOfFameEditModel[] CollegeHallOfFames 
            => _editModel.CollegeHallOfFames
                         .Where(hof => !hof.IsDeleted)
                         .ToArray();

        public PersonFranchiseHallOfFameEditModel[] FranchiseHallOfFames 
            => _editModel.FranchiseHallOfFames
                         .Where(hof => !hof.IsDeleted)
                         .ToArray();

        public PersonHallOfFameEditModel[] HallOfFames 
            => _editModel.HallOfFames
                         .Where(hof => !hof.IsDeleted)
                         .ToArray();

        public PersonInternationalHallOfFameEditModel[] InternationalHallOfFames 
            => _editModel.InternationalHallOfFames
                         .Where(hof => !hof.IsDeleted)
                         .ToArray();

        public int PersonId { get; }
    }
}
