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
            Entity.Person person = await _personRepository.Get(command.PersonId);

            UpdateOccupations(command, person);
            UpdatePositions(command, person);
            UpdateSports(command, person);

            await _personRepository.Update(person);
        }

        private static void UpdateOccupations(Command command, Entity.Person person)
        {
            person.RemoveOccupations(command.DeletedOccupationIds);

            foreach (var occupation in command.Occupations.Where(occupation => !occupation.IsDeleted))
            {
                person.SetOccupation(occupation.Occupation.Id, 
                                     occupation.OccupationType.Id);
            }
        }

        private static void UpdatePositions(Command command, Entity.Person person)
        {
            person.RemovePositions(command.DeletedPositionIds);

            foreach (var personPosition in command.Positions.Where(position => !position.IsDeleted))
            {
                person.SetPosition(personPosition.Position.Id, 
                                   personPosition.PositionType);
            }
        }

        private static void UpdateSports(Command command, Entity.Person person)
        {
            person.RemoveSports(command.DeletedSportsIds);

            foreach (var sport in command.Sports.Where(sport => !sport.IsDeleted))
            {
                person.SetSport(sport.Sport.Id, 
                                sport.IsPrimary);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PersonOccupationsEditModel _editModel;

        public Command(int personId, PersonOccupationsEditModel editModel)
        {
            PersonId = personId;
            _editModel = editModel;
        }

        public int[] DeletedOccupationIds
            => _editModel.Occupations
                         .Where(occupation => occupation.IsDeleted)
                         .Select(occupation => occupation.Id)
                         .ToArray();

        public int[] DeletedPositionIds 
            => _editModel.Positions
                         .Where(position => position.IsDeleted)
                         .Select(position => position.Id)
                         .ToArray();

        public int[] DeletedSportsIds 
            => _editModel.Sports
                         .Where(sport => sport.IsDeleted)
                         .Select(sport => sport.Id)
                         .ToArray();

        public PersonOccupationEditModel[] Occupations 
            => _editModel.Occupations
                         .ToArray();

        public int PersonId { get; }

        public PersonPositionEditModel[] Positions 
            => _editModel.Positions
                         .ToArray();

        public PersonSportEditModel[] Sports 
            => _editModel.Sports
                         .ToArray();        
    }
}
