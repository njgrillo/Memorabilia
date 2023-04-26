using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

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
            var person = await _personRepository.Get(command.PersonId);

            UpdateCollegeHallOfFames(command, person);
            UpdateFranchiseHallOfFames(command, person);
            UpdateHallOfFames(command, person);
            UpdateInternationalHallOfFames(command, person);

            await _personRepository.Update(person);
        }

        private static void UpdateCollegeHallOfFames(Command command, Person person)
        {
            person.RemoveCollegeHallOfFames(command.DeletedCollegeHallOfFameIds);

            foreach (var hallOfFame in command.CollegeHallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetCollegeHallOfFame(hallOfFame.College.Id, hallOfFame.Sport.Id, hallOfFame.Year);
            }
        }

        private static void UpdateFranchiseHallOfFames(Command command, Person person)
        {
            person.RemoveFranchiseHallOfFames(command.DeletedFranchiseHallOfFameIds);

            foreach (var hallOfFame in command.FranchiseHallOfFames.Where(hof => !hof.IsDeleted))
            {
                person.SetFranchiseHallOfFame(hallOfFame.FranchiseHallOfFameType.Franchise.Id, hallOfFame.Year);
            }
        }

        private static void UpdateHallOfFames(Command command, Person person)
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

        private static void UpdateInternationalHallOfFames(Command command, Person person)
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
        private readonly SavePersonHallOfFamesViewModel _viewModel;

        public Command(int personId, SavePersonHallOfFamesViewModel viewModel)
        {               
            PersonId = personId;
            _viewModel = viewModel;
        }

        public int[] DeletedCollegeHallOfFameIds 
            => _viewModel.CollegeHallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

        public int[] DeletedFranchiseHallOfFameIds 
            => _viewModel.FranchiseHallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

        public int[] DeletedHallOfFameIds 
            => _viewModel.HallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

        public int[] DeletedInternationalHallOfFameIds 
            => _viewModel.InternationalHallOfFames.Where(hof => hof.IsDeleted).Select(hof => hof.Id).ToArray();

        public SavePersonCollegeHallOfFameViewModel[] CollegeHallOfFames 
            => _viewModel.CollegeHallOfFames.Where(hof => !hof.IsDeleted).ToArray();

        public SavePersonFranchiseHallOfFameViewModel[] FranchiseHallOfFames 
            => _viewModel.FranchiseHallOfFames.Where(hof => !hof.IsDeleted).ToArray();

        public SavePersonHallOfFameViewModel[] HallOfFames 
            => _viewModel.HallOfFames.Where(hof => !hof.IsDeleted).ToArray();

        public SavePersonInternationalHallOfFameViewModel[] InternationalHallOfFames 
            => _viewModel.InternationalHallOfFames.Where(hof => !hof.IsDeleted).ToArray();

        public int PersonId { get; }
    }
}
