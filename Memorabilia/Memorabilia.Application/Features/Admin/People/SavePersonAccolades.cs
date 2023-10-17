namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonAccolades
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

            UpdateAccomplishments(command, person);
            UpdateAllStars(command, person);
            UpdateAwards(command, person);
            UpdateCareerRecords(command, person);
            UpdateCollegeRetiredNumbers(command, person);
            UpdateLeaders(command, person);
            UpdateRetiredNumbers(command, person);
            UpdateSingleSeasonRecords(command, person); 

            await _personRepository.Update(person);
        }

        private static void UpdateAccomplishments(Command command, Entity.Person person)
        {
            person.RemoveAccomplishments(command.DeletedAccomplishmentIds);

            foreach (var accomplishment in command.Accomplishments)
            {
                person.SetAccomplishments(accomplishment.Id, 
                                          accomplishment.AccomplishmentType.Id, 
                                          accomplishment.Date, 
                                          accomplishment.Year);
            }
        }

        private static void UpdateAllStars(Command command, Entity.Person person)
        {
            person.RemoveAllStars(command.DeletedAllStars);

            foreach (var allStar in command.AllStars)
            {
                person.SetAllStars(allStar.Id,
                                   allStar.Sport.Id,
                                   allStar.SportLeagueLevelId > 0 ? allStar.SportLeagueLevelId : null,
                                   allStar.Year);
            }
        }

        private static void UpdateAwards(Command command, Entity.Person person)
        {
            person.RemoveAwards(command.DeletedAwardIds);

            foreach (var award in command.Awards)
            {
                person.SetAward(award.Id, award.AwardType.Id, award.Year);
            }
        }

        private static void UpdateCareerRecords(Command command, Entity.Person person)
        {
            person.RemoveCareerRecords(command.DeletedCareerRecordIds);

            foreach (var record in command.CareerRecords)
            {
                person.SetCareerRecord(record.Id, record.RecordType.Id, record.Record);
            }
        }

        private static void UpdateCollegeRetiredNumbers(Command command, Entity.Person person)
        {
            person.RemoveCollegeRetiredNumbers(command.DeletedCollegeRetiredNumberIds);

            foreach (var retiredNumber in command.CollegeRetiredNumbers)
            {
                person.SetCollegeRetiredNumber(retiredNumber.Id, retiredNumber.College.Id, retiredNumber.PlayerNumber ?? 0);
            }
        }

        private static void UpdateLeaders(Command command, Entity.Person person)
        {
            person.RemoveLeaders(command.DeletedLeaderIds);

            foreach (var leader in command.Leaders)
            {
                person.SetLeader(leader.Id, leader.LeaderType.Id, leader.Year);
            }
        }

        private static void UpdateRetiredNumbers(Command command, Entity.Person person)
        {
            person.RemoveRetiredNumbers(command.DeletedRetiredNumberIds);

            foreach (var retiredNumber in command.RetiredNumbers)
            {
                person.SetRetiredNumber(retiredNumber.Id, retiredNumber.Franchise.Id, retiredNumber.PlayerNumber ?? 0);
            }
        }

        private static void UpdateSingleSeasonRecords(Command command, Entity.Person person)
        {
            person.RemoveSingleSeasonRecords(command.DeletedSingleSeasonRecordIds);

            foreach (var record in command.SingleSeasonRecords)
            {
                person.SetSingleSeasonRecord(record.Id, record.RecordType.Id, record.Year ?? 0, record.Record);
            }
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly PersonAccoladeEditModel _editModel;

        public Command(int personId, PersonAccoladeEditModel editModel)
        {
            PersonId = personId;
            _editModel = editModel;
        }

        public PersonAccomplishmentEditModel[] Accomplishments 
            => _editModel.Accomplishments
                         .Where(accomplishment => !accomplishment.IsDeleted)
                         .ToArray();

        public PersonAllStarEditModel[] AllStars
            => _editModel.AllStars
                         .Where(allStar => !allStar.IsDeleted)
                         .ToArray();

        public PersonAwardEditModel[] Awards 
            => _editModel.Awards
                         .Where(award => !award.IsDeleted)
                         .ToArray();

        public PersonCareerRecordEditModel[] CareerRecords 
            => _editModel.CareerRecords
                         .Where(record => !record.IsDeleted)
                         .ToArray();

        public PersonCollegeRetiredNumberEditModel[] CollegeRetiredNumbers 
            => _editModel.CollegeRetiredNumbers
                         .Where(retiredNumber => !retiredNumber.IsDeleted)
                         .ToArray();

        public int[] DeletedAccomplishmentIds
            => _editModel.Accomplishments.DeletedIds();

        public int[] DeletedAllStars
            => _editModel.AllStars.DeletedIds();

        public int[] DeletedAwardIds 
            => _editModel.Awards.DeletedIds();

        public int[] DeletedCareerRecordIds 
            => _editModel.CareerRecords.DeletedIds();

        public int[] DeletedCollegeRetiredNumberIds
            => _editModel.CollegeRetiredNumbers.DeletedIds();

        public int[] DeletedLeaderIds 
            => _editModel.Leaders.DeletedIds();

        public int[] DeletedRetiredNumberIds 
            => _editModel.RetiredNumbers.DeletedIds();

        public int[] DeletedSingleSeasonRecordIds 
            => _editModel.SingleSeasonRecords.DeletedIds();

        public PersonLeaderEditModel[] Leaders 
            => _editModel.Leaders
                         .Where(leader => !leader.IsDeleted)
                         .ToArray();

        public int PersonId { get; }

        public PersonRetiredNumberEditModel[] RetiredNumbers 
            => _editModel.RetiredNumbers
                         .Where(retiredNumber => !retiredNumber.IsDeleted)
                         .ToArray();

        public PersonSingleSeasonRecordEditModel[] SingleSeasonRecords 
            => _editModel.SingleSeasonRecords
                         .Where(leader => !leader.IsDeleted)
                         .ToArray();
    }
}
