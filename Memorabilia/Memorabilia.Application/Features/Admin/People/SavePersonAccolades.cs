using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

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
            var person = await _personRepository.Get(command.PersonId);

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

        private static void UpdateAccomplishments(Command command, Person person)
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

        private static void UpdateAllStars(Command command, Person person)
        {
            person.RemoveAllStars(command.DeletedAllStars);

            foreach (var allStar in command.AllStars)
            {
                person.SetAllStars(allStar.Id,
                                   allStar.Sport.Id,
                                   allStar.Year);
            }
        }

        private static void UpdateAwards(Command command, Person person)
        {
            person.RemoveAwards(command.DeletedAwardIds);

            foreach (var award in command.Awards)
            {
                person.SetAward(award.Id, award.AwardType.Id, award.Year);
            }
        }

        private static void UpdateCareerRecords(Command command, Person person)
        {
            person.RemoveCareerRecords(command.DeletedCareerRecordIds);

            foreach (var record in command.CareerRecords)
            {
                person.SetCareerRecord(record.Id, record.RecordType.Id, record.Record);
            }
        }

        private static void UpdateCollegeRetiredNumbers(Command command, Person person)
        {
            person.RemoveCollegeRetiredNumbers(command.DeletedCollegeRetiredNumberIds);

            foreach (var retiredNumber in command.CollegeRetiredNumbers)
            {
                person.SetCollegeRetiredNumber(retiredNumber.Id, retiredNumber.College.Id, retiredNumber.PlayerNumber ?? 0);
            }
        }

        private static void UpdateLeaders(Command command, Person person)
        {
            person.RemoveLeaders(command.DeletedLeaderIds);

            foreach (var leader in command.Leaders)
            {
                person.SetLeader(leader.Id, leader.LeaderType.Id, leader.Year);
            }
        }

        private static void UpdateRetiredNumbers(Command command, Person person)
        {
            person.RemoveRetiredNumbers(command.DeletedRetiredNumberIds);

            foreach (var retiredNumber in command.RetiredNumbers)
            {
                person.SetRetiredNumber(retiredNumber.Id, retiredNumber.Franchise.Id, retiredNumber.PlayerNumber ?? 0);
            }
        }

        private static void UpdateSingleSeasonRecords(Command command, Person person)
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
        private readonly SavePersonAccoladeViewModel _viewModel;

        public Command(int personId, SavePersonAccoladeViewModel viewModel)
        {
            PersonId = personId;
            _viewModel = viewModel;
        }

        public SavePersonAccomplishmentViewModel[] Accomplishments 
            => _viewModel.Accomplishments
                         .Where(accomplishment => !accomplishment.IsDeleted)
                         .ToArray();

        public SavePersonAllStarViewModel[] AllStars
            => _viewModel.AllStars
                         .Where(allStar => !allStar.IsDeleted)
                         .ToArray();

        public SavePersonAwardViewModel[] Awards 
            => _viewModel.Awards
                         .Where(award => !award.IsDeleted)
                         .ToArray();

        public SavePersonCareerRecordViewModel[] CareerRecords 
            => _viewModel.CareerRecords
                         .Where(record => !record.IsDeleted)
                         .ToArray();

        public SavePersonCollegeRetiredNumberViewModel[] CollegeRetiredNumbers 
            => _viewModel.CollegeRetiredNumbers
                         .Where(retiredNumber => !retiredNumber.IsDeleted)
                         .ToArray();

        public int[] DeletedAccomplishmentIds
            => _viewModel.Accomplishments
                         .Where(accomplishment => accomplishment.IsDeleted)
                         .Select(accomplishment => accomplishment.Id)
                         .ToArray();

        public int[] DeletedAllStars
            => _viewModel.AllStars
                         .Where(allStar => allStar.IsDeleted)
                         .Select(allStar => allStar.Id)
                         .ToArray();

        public int[] DeletedAwardIds 
            => _viewModel.Awards
                         .Where(award => award.IsDeleted)
                         .Select(award => award.Id)
                         .ToArray();

        public int[] DeletedCareerRecordIds 
            => _viewModel.CareerRecords
                         .Where(record => record.IsDeleted)
                         .Select(record => record.Id)
                         .ToArray();

        public int[] DeletedCollegeRetiredNumberIds
            => _viewModel.CollegeRetiredNumbers
                         .Where(retiredNumber => retiredNumber.IsDeleted)
                         .Select(retiredNumber => retiredNumber.Id)
                         .ToArray();

        public int[] DeletedLeaderIds 
            => _viewModel.Leaders
                         .Where(leader => leader.IsDeleted)
                         .Select(leader => leader.Id)
                         .ToArray();

        public int[] DeletedRetiredNumberIds 
            => _viewModel.RetiredNumbers
                         .Where(retiredNumber => retiredNumber.IsDeleted)
                         .Select(retiredNumber => retiredNumber.Id)
                         .ToArray();

        public int[] DeletedSingleSeasonRecordIds 
            => _viewModel.SingleSeasonRecords
                         .Where(record => record.IsDeleted)
                         .Select(record => record.Id)
                         .ToArray();

        public SavePersonLeaderViewModel[] Leaders 
            => _viewModel.Leaders
                         .Where(leader => !leader.IsDeleted)
                         .ToArray();

        public int PersonId { get; }

        public SavePersonRetiredNumberViewModel[] RetiredNumbers 
            => _viewModel.RetiredNumbers
                         .Where(retiredNumber => !retiredNumber.IsDeleted)
                         .ToArray();

        public SavePersonSingleSeasonRecordViewModel[] SingleSeasonRecords 
            => _viewModel.SingleSeasonRecords
                         .Where(leader => !leader.IsDeleted)
                         .ToArray();
    }
}
