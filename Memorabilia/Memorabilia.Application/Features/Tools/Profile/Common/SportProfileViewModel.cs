using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SportProfileViewModel : ProfileViewModel
{
    public SportProfileViewModel() { }

    public SportProfileViewModel(Person person) : base(person) 
    {
        AllStars = Person.AllStars
                         .Select(allStar => new AllStarProfileViewModel(allStar, Person.Teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year);
        CareerRecords = Person.CareerRecords
                              .Select(record => new CareerRecordProfileViewModel(record))
                              .OrderBy(record => record.CareerRecordTypeName);
        Championships = Person.Teams
                              .SelectMany(team => team.Team.Championships)
                              .Where(chip => Person.Teams.Any(team => team.BeginYear <= chip.Year && (!team.EndYear.HasValue || team.EndYear >= chip.Year)))
                              .Select(championship => new ChampionshipProfileViewModel(championship));
        Drafts = Person.Drafts
                       .Select(draft => new DraftProfileViewModel(draft));
        FranchiseHallOfFames = Person.FranchiseHallOfFames
                                     .Select(hof => new FranchiseHallOfFameProfileViewModel(hof));
        Leaders = Person.Leaders
                        .Select(leader => new LeaderProfileViewModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName);
        RetiredNumbers = Person.RetiredNumbers
                               .Select(retiredNumber => new RetiredNumberProfileViewModel(retiredNumber))
                               .OrderBy(retiredNumber => retiredNumber.FranchiseName);
        Service = new SportServiceProfileViewModel(Person.Service);
        SingleSeasonRecords = Person.SingleSeasonRecords
                                    .Select(record => new SingleSeasonRecordProfileViewModel(record))
                                    .OrderBy(record => record.RecordTypeName);
        Teams = Person.Teams
                      .Select(team => new TeamProfileViewModel(team));
    }

    public virtual IEnumerable<AllStarProfileViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarProfileViewModel>();

    public virtual string AllStarSummaryDisplayText => $"{AllStars?.Count() ?? 0}x All Star";

    public virtual IEnumerable<CareerRecordProfileViewModel> CareerRecords { get; set; } = Enumerable.Empty<CareerRecordProfileViewModel>();

    public virtual IEnumerable<ChampionshipProfileViewModel> Championships { get; set; } = Enumerable.Empty<ChampionshipProfileViewModel>();

    public virtual string ChampionshipSummaryDisplayText => $"{Championships?.Count() ?? 0}x Champion";

    public virtual string Debut => Service?.DebutDate.HasValue ?? false
        ? $"Debut {Service.DebutDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public virtual LeaderProfileViewModel[] DistinctLeaders => Leaders.DistinctBy(leader => leader.LeaderTypeId).ToArray();

    public virtual IEnumerable<DraftProfileViewModel> Drafts { get; set; } = Enumerable.Empty<DraftProfileViewModel>();

    public virtual IEnumerable<FranchiseHallOfFameProfileViewModel> FranchiseHallOfFames { get; set; } = Enumerable.Empty<FranchiseHallOfFameProfileViewModel>();

    public virtual string FreeAgentSigning => Service?.FreeAgentSigningDate.HasValue ?? false
        ? $"Signed {Service.FreeAgentSigningDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public virtual bool HasAllStarData => AllStars?.Any() ?? false;

    public virtual bool HasCareerRecords => CareerRecords?.Any() ?? false;

    public virtual bool HasChampionships => Championships?.Any() ?? false;

    public virtual bool HasDraftData => Drafts?.Any() ?? false;

    public virtual bool HasFranchiseHallOfFameData => FranchiseHallOfFames?.Any() ?? false;

    public virtual bool HasFreeAgentSigningData => Service?.FreeAgentSigningDate.HasValue ?? false;

    public virtual bool HasLeaders => Leaders?.Any() ?? false;

    public virtual bool HasRetiredNumbers => RetiredNumbers?.Any() ?? false;

    public virtual bool HasSingleSeasonRecords => SingleSeasonRecords?.Any() ?? false;

    public virtual string LastAppearance => Service?.LastAppearanceDate.HasValue ?? false
        ? $"Last Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
        : string.Empty;

    public virtual IEnumerable<LeaderProfileViewModel> Leaders { get; set; } = Enumerable.Empty<LeaderProfileViewModel>();

    public virtual IEnumerable<RetiredNumberProfileViewModel> RetiredNumbers { get; set; } = Enumerable.Empty<RetiredNumberProfileViewModel>();

    public virtual SportServiceProfileViewModel Service { get; set; }

    public virtual IEnumerable<SingleSeasonRecordProfileViewModel> SingleSeasonRecords { get; set; } = Enumerable.Empty<SingleSeasonRecordProfileViewModel>();

    public virtual IEnumerable<TeamProfileViewModel> Teams { get; set; } = Enumerable.Empty<TeamProfileViewModel>();
}
