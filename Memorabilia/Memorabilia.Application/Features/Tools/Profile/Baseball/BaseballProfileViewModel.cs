using Memorabilia.Application.Features.Tools.Profile.Common;
using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Tools.Profile.Baseball
{
    public class BaseballProfileViewModel : ProfileViewModel
    {
        private readonly Person _person;

        public BaseballProfileViewModel() { }

        public BaseballProfileViewModel(Person person) : base(person)
        {
            _person = person;

            AllStars = _person.AllStars.Select(allStar => new AllStarProfileViewModel(allStar));  
            Awards = _person.Awards.Select(award => new AwardProfileViewModel(award));
            CareerRecords = _person.CareerRecords.Select(record => new CareerRecordProfileViewModel(record));
            Championships = _person.Teams.SelectMany(team => team.Team.Championships.Select(championship => new ChampionshipProfileViewModel(championship)));
            Colleges = _person.Colleges.Select(college => new CollegeProfileViewModel(college));
            Drafts = _person.Drafts.Select(draft => new DraftProfileViewModel(draft));
            HallOfFames = _person.HallOfFames.Select(hof => new HallOfFameProfileViewModel(hof));
            Leaders = _person.Leaders.Select(leader => new LeaderProfileViewModel(leader));
            Service = new SportServiceProfileViewModel(_person.Service);
            SingleSeasonRecords = _person.SingleSeasonRecords.Select(record => new SingleSeasonRecordProfileViewModel(record));
            Teams = _person.Teams.Select(team => new TeamProfileViewModel(team));
        }

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

        public IEnumerable<HallOfFameProfileViewModel> HallOfFames { get; set; } = Enumerable.Empty<HallOfFameProfileViewModel>();

        public bool HasCareerRecords => CareerRecords?.Any() ?? false;

        public bool HasDraftData => Drafts?.Any() ?? false;

        public bool HasSingleSeasonRecords => SingleSeasonRecords?.Any() ?? false;

        public string Debut => Service?.DebutDate.HasValue ?? false
            ? $"MLB Debut {Service.DebutDate.Value:MM/dd/yyyy}"
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

        public SportServiceProfileViewModel Service { get; set; }

        public IEnumerable<SingleSeasonRecordProfileViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordProfileViewModel>();

        public IEnumerable<TeamProfileViewModel> Teams { get; set; } = Enumerable.Empty<TeamProfileViewModel>();
    }
}
