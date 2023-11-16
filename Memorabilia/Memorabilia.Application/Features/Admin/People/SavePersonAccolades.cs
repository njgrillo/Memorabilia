namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.Role.Admin)]
public class SavePersonAccolades
{
    public class Handler(IPersonRepository personRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Person person = await personRepository.Get(command.PersonId);

            UpdateAccomplishments(command, person);
            UpdateAllStars(command, person);
            UpdateAwards(command, person);
            UpdateCareerRecords(command, person);
            UpdateCollegeRetiredNumbers(command, person);
            UpdateLeaders(command, person);
            UpdateRetiredNumbers(command, person);
            UpdateSingleSeasonRecords(command, person); 

            await personRepository.Update(person);
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

    public class Command(int personId, PersonAccoladeEditModel editModel) 
        : DomainCommand, ICommand
    {
        public PersonAccomplishmentEditModel[] Accomplishments 
            => editModel.Accomplishments
                        .Where(accomplishment => !accomplishment.IsDeleted)
                        .ToArray();

        public PersonAllStarEditModel[] AllStars
            => editModel.AllStars
                        .Where(allStar => !allStar.IsDeleted)
                        .ToArray();

        public PersonAwardEditModel[] Awards 
            => editModel.Awards
                        .Where(award => !award.IsDeleted)
                        .ToArray();

        public PersonCareerRecordEditModel[] CareerRecords 
            => editModel.CareerRecords
                        .Where(record => !record.IsDeleted)
                        .ToArray();

        public PersonCollegeRetiredNumberEditModel[] CollegeRetiredNumbers 
            => editModel.CollegeRetiredNumbers
                        .Where(retiredNumber => !retiredNumber.IsDeleted)
                        .ToArray();

        public int[] DeletedAccomplishmentIds
            => editModel.Accomplishments
                        .DeletedIds();

        public int[] DeletedAllStars
            => editModel.AllStars
                        .DeletedIds();

        public int[] DeletedAwardIds 
            => editModel.Awards
                        .DeletedIds();

        public int[] DeletedCareerRecordIds 
            => editModel.CareerRecords
                        .DeletedIds();

        public int[] DeletedCollegeRetiredNumberIds
            => editModel.CollegeRetiredNumbers
                        .DeletedIds();

        public int[] DeletedLeaderIds 
            => editModel.Leaders
                        .DeletedIds();

        public int[] DeletedRetiredNumberIds 
            => editModel.RetiredNumbers
                        .DeletedIds();

        public int[] DeletedSingleSeasonRecordIds 
            => editModel.SingleSeasonRecords
                        .DeletedIds();

        public PersonLeaderEditModel[] Leaders 
            => editModel.Leaders
                        .Where(leader => !leader.IsDeleted)
                        .ToArray();

        public int PersonId { get; } 
            = personId;

        public PersonRetiredNumberEditModel[] RetiredNumbers 
            => editModel.RetiredNumbers
                        .Where(retiredNumber => !retiredNumber.IsDeleted)
                        .ToArray();

        public PersonSingleSeasonRecordEditModel[] SingleSeasonRecords 
            => editModel.SingleSeasonRecords
                        .Where(leader => !leader.IsDeleted)
                        .ToArray();
    }
}
