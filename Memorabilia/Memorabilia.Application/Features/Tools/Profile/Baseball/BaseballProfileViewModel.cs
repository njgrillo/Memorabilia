using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Baseball
{
    public class BaseballProfileViewModel : ProfileViewModel
    {
        private readonly Person _person;

        public BaseballProfileViewModel() { }

        public BaseballProfileViewModel(Person person) : base(person)
        {
            _person = person;

            Accomplishments = _person.Accomplishments.Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment));  
            AllStars = _person.AllStars.Select(allStar => new AllStarProfileViewModel(allStar, _person.Teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year))).OrderBy(allStar => allStar.Year);  
            Awards = _person.Awards.Select(award => new AwardProfileViewModel(award)).OrderBy(award => award.Year)
                                                                                     .ThenBy(award => award.AwardTypeName);
            CareerRecords = _person.CareerRecords.Select(record => new CareerRecordProfileViewModel(record))
                                                 .OrderBy(record => record.CareerRecordTypeName);
            Championships = _person.Teams.SelectMany(team => team.Team.Championships.Select(championship => new ChampionshipProfileViewModel(championship)))
                                                                                    .OrderBy(championship => championship.Year);
            Colleges = _person.Colleges.Select(college => new CollegeProfileViewModel(college));
            Drafts = _person.Drafts.Select(draft => new DraftProfileViewModel(draft));
            FranchiseHallOfFames = _person.FranchiseHallOfFames.Select(hof => new FranchiseHallOfFameProfileViewModel(hof));
            HallOfFames = _person.HallOfFames.Select(hof => new HallOfFameProfileViewModel(hof));
            Leaders = _person.Leaders.Select(leader => new LeaderProfileViewModel(leader)).OrderBy(leader => leader.Year)
                                                                                          .ThenBy(leader => leader.LeaderTypeName);
            RetiredNumbers = _person.RetiredNumbers.Select(retiredNumber => new RetiredNumberProfileViewModel(retiredNumber))
                                                   .OrderBy(retiredNumber => retiredNumber.FranchiseName)
                                                   .ToList();
            Service = new SportServiceProfileViewModel(_person.Service);
            SingleSeasonRecords = _person.SingleSeasonRecords.Select(record => new SingleSeasonRecordProfileViewModel(record))
                                                             .OrderBy(record => record.RecordTypeName);
            Teams = _person.Teams.Select(team => new TeamProfileViewModel(team));
        }

        public IEnumerable<AccomplishmentProfileViewModel> Accomplishments { get; set; } = Enumerable.Empty<AccomplishmentProfileViewModel>();

        public IEnumerable<AllStarProfileViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarProfileViewModel>();

        public string AllStarSummaryDisplayText => $"{AllStars?.Count() ?? 0}x All Star";

        public IEnumerable<AwardProfileViewModel> Awards { get; set; } = Enumerable.Empty<AwardProfileViewModel>();

        public IEnumerable<CareerRecordProfileViewModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordProfileViewModel>();

        public IEnumerable<ChampionshipProfileViewModel> Championships { get; set; } = Enumerable.Empty<ChampionshipProfileViewModel>();

        public string ChampionshipSummaryDisplayText => $"{Championships?.Count() ?? 0}x World Series Champion";

        public IEnumerable<CollegeProfileViewModel> Colleges { get; set; } = Enumerable.Empty<CollegeProfileViewModel>();

        public AwardProfileViewModel[] DistinctAwards => Awards.DistinctBy(award => award.AwardTypeId).ToArray();

        public LeaderProfileViewModel[] DistinctLeaders => Leaders.DistinctBy(leader => leader.LeaderTypeId).ToArray();

        public IEnumerable<DraftProfileViewModel> Drafts { get; set; } = Enumerable.Empty<DraftProfileViewModel>();

        public IEnumerable<FranchiseHallOfFameProfileViewModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameProfileViewModel>();

        public IEnumerable<HallOfFameProfileViewModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameProfileViewModel>();

        public bool HasAccomplishments => Accomplishments?.Any() ?? false;

        public bool HasAllStarData => AllStars?.Any() ?? false;

        public bool HasAwards => Awards?.Any() ?? false;

        public bool HasCareerRecords => CareerRecords?.Any() ?? false;

        public bool HasChampionships => Championships?.Any() ?? false;

        public bool HasDraftData => Drafts?.Any() ?? false;

        public bool HasFranchiseHallOfFameData => FranchiseHallOfFames?.Any() ?? false;

        public bool HasFreeAgentSigningData => Service?.FreeAgentSigningDate.HasValue ?? false;

        public bool HasHallOfFameData => HallOfFames?.Any() ?? false;   

        public bool HasLeaders => Leaders?.Any() ?? false;

        public bool HasRetiredNumbers => RetiredNumbers?.Any() ?? false;

        public bool HasSingleSeasonRecords => SingleSeasonRecords?.Any() ?? false;

        public string Debut => Service?.DebutDate.HasValue ?? false
            ? $"MLB Debut {Service.DebutDate.Value:MM/dd/yyyy}"
            : string.Empty;

        public string FreeAgentSigning => Service?.FreeAgentSigningDate.HasValue ?? false
            ? $"Signed {Service.FreeAgentSigningDate.Value:MM/dd/yyyy}"
            : string.Empty;

        public string LastAppearance => Service?.LastAppearanceDate.HasValue ?? false
            ? $"Last MLB Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
            : string.Empty;

        public IEnumerable<LeaderProfileViewModel> Leaders { get; set; } = Enumerable.Empty<LeaderProfileViewModel>();

        public override string NameHeader 
        { 
            get
            {
                var header = base.NameHeader;
                var hof = HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevel == Domain.Constants.SportLeagueLevel.MajorLeagueBaseball);

                if (hof == null)
                    return header;

                return $"{header} | HOF {hof.InductionYear}";
            }
        }

        public IEnumerable<RetiredNumberProfileViewModel> RetiredNumbers { get; set; } = Enumerable.Empty<RetiredNumberProfileViewModel>();

        public SportServiceProfileViewModel Service { get; set; }

        public IEnumerable<SingleSeasonRecordProfileViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordProfileViewModel>();

        public IEnumerable<TeamProfileViewModel> Teams { get; set; } = Enumerable.Empty<TeamProfileViewModel>();
    }
}
