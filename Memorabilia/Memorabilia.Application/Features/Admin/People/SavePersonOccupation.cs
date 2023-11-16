namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonOccupation
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            UpdateOccupations(command, person);
            UpdatePositions(command, person);
            UpdateSports(command, person);

            await personRepository.Update(person);
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

    public class Command(int personId, PersonOccupationsEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int[] DeletedOccupationIds
            => editModel.Occupations
                        .Where(occupation => occupation.IsDeleted)
                        .Select(occupation => occupation.Id)
                        .ToArray();

        public int[] DeletedPositionIds 
            => editModel.Positions
                        .Where(position => position.IsDeleted)
                        .Select(position => position.Id)
                        .ToArray();

        public int[] DeletedSportsIds 
            => editModel.Sports
                        .Where(sport => sport.IsDeleted)
                        .Select(sport => sport.Id)
                        .ToArray();

        public PersonOccupationEditModel[] Occupations 
            => editModel.Occupations
                        .ToArray();

        public int PersonId { get; } 
            = personId;

        public PersonPositionEditModel[] Positions 
            => editModel.Positions
                        .ToArray();

        public PersonSportEditModel[] Sports 
            => editModel.Sports
                        .ToArray();        
    }
}
