using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonOccupation
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

            UpdateOccupations(command, person);
            UpdatePositions(command, person);
            UpdateSports(command, person);

            await _personRepository.Update(person);
        }

        private static void UpdateOccupations(Command command, Person person)
        {
            person.RemoveOccupations(command.DeletedOccupationIds);

            foreach (var occupation in command.Occupations.Where(occupation => !occupation.IsDeleted))
            {
                person.SetOccupation(occupation.Occupation.Id, occupation.OccupationType.Id);
            }
        }

        private static void UpdatePositions(Command command, Person person)
        {
            person.RemovePositions(command.DeletedPositionIds);

            foreach (var personPosition in command.Positions.Where(position => !position.IsDeleted))
            {
                person.SetPosition(personPosition.Position.Id, personPosition.PositionType);
            }
        }

        private static void UpdateSports(Command command, Person person)
        {
            person.RemoveSports(command.DeletedSportsIds);

            foreach (var sport in command.Sports.Where(sport => !sport.IsDeleted))
            {
                person.SetSport(sport.Sport.Id, sport.IsPrimary);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SavePersonOccupationsViewModel _viewModel;

        public Command(int personId, SavePersonOccupationsViewModel viewModel)
        {
            PersonId = personId;
            _viewModel = viewModel;
        }

        public int[] DeletedOccupationIds => _viewModel.Occupations.Where(occupation => occupation.IsDeleted).Select(occupation => occupation.Id).ToArray();

        public int[] DeletedPositionIds => _viewModel.Positions.Where(position => position.IsDeleted).Select(position => position.Id).ToArray();

        public int[] DeletedSportsIds => _viewModel.Sports.Where(sport => sport.IsDeleted).Select(sport => sport.Id).ToArray();

        public SavePersonOccupationViewModel[] Occupations => _viewModel.Occupations.ToArray();

        public int PersonId { get; }

        public SavePersonPositionViewModel[] Positions => _viewModel.Positions.ToArray();

        public SavePersonSportViewModel[] Sports => _viewModel.Sports.ToArray();        
    }
}
