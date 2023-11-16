namespace Memorabilia.Application.Features.Tools.Profile.Common;

public class SportProfileModel : ProfileModel
{
    public SportProfileModel() { }

    public SportProfileModel(Entity.Person person) : base(person) 
    {
        AllStars = Person.AllStars
                         .Select(allStar => new AllStarProfileModel(allStar, Person.Teams.FirstOrDefault(team => team.BeginYear <= allStar.Year && team.EndYear >= allStar.Year)))
                         .OrderBy(allStar => allStar.Year);

        CareerRecords = Person.CareerRecords
                              .Select(record => new CareerRecordProfileModel(record))
                              .OrderBy(record => record.CareerRecordTypeName);

        Championships = Person.Teams
                              .SelectMany(team => team.Team.Championships)
                              .Where(chip => Person.Teams.Any(team => team.BeginYear <= chip.Year && (!team.EndYear.HasValue || team.EndYear >= chip.Year)))
                              .Select(championship => new ChampionshipProfileModel(championship));

        Drafts = Person.Drafts
                       .Select(draft => new DraftProfileModel(draft));

        FranchiseHallOfFames = Person.FranchiseHallOfFames
                                     .Select(hof => new FranchiseHallOfFameProfileModel(hof));

        Leaders = Person.Leaders
                        .Select(leader => new LeaderProfileModel(leader))
                        .OrderBy(leader => leader.Year)
                        .ThenBy(leader => leader.LeaderTypeName);

        RetiredNumbers = Person.RetiredNumbers
                               .Select(retiredNumber => new RetiredNumberProfileModel(retiredNumber))
                               .OrderBy(retiredNumber => retiredNumber.FranchiseName);

        Service = new SportServiceProfileModel(Person.Service);

        SingleSeasonRecords = Person.SingleSeasonRecords
                                    .Select(record => new SingleSeasonRecordProfileModel(record))
                                    .OrderBy(record => record.RecordTypeName);

        Teams = Person.Teams
                      .Select(team => new TeamProfileModel(team));
    }

    public virtual IEnumerable<AllStarProfileModel> AllStars { get; set; } 
        = Enumerable.Empty<AllStarProfileModel>();

    public virtual string AllStarSummaryDisplayText 
        => $"{AllStars?.Count() ?? 0}x All Star";

    public virtual IEnumerable<CareerRecordProfileModel> CareerRecords { get; set; } 
        = Enumerable.Empty<CareerRecordProfileModel>();

    public virtual IEnumerable<ChampionshipProfileModel> Championships { get; set; } 
        = Enumerable.Empty<ChampionshipProfileModel>();

    public virtual string ChampionshipSummaryDisplayText 
        => $"{Championships?.Count() ?? 0}x Champion";

    public virtual string Debut 
        => Service?.DebutDate.HasValue ?? false
            ? $"Debut {Service.DebutDate.Value:MM/dd/yyyy}"
            : string.Empty;

    public virtual LeaderProfileModel[] DistinctLeaders 
        => Leaders.DistinctBy(leader => leader.LeaderTypeId)
                  .ToArray();

    public virtual IEnumerable<DraftProfileModel> Drafts { get; set; } 
        = Enumerable.Empty<DraftProfileModel>();

    public virtual IEnumerable<FranchiseHallOfFameProfileModel> FranchiseHallOfFames { get; set; } 
        = Enumerable.Empty<FranchiseHallOfFameProfileModel>();

    public virtual string FreeAgentSigning 
        => Service?.FreeAgentSigningDate.HasValue ?? false
            ? $"Signed {Service.FreeAgentSigningDate.Value:MM/dd/yyyy}"
            : string.Empty;

    public virtual bool HasAllStarData 
        => AllStars?.Any() ?? false;

    public virtual bool HasCareerRecords 
        => CareerRecords?.Any() ?? false;

    public virtual bool HasChampionships 
        => Championships?.Any() ?? false;

    public virtual bool HasDraftData 
        => Drafts?.Any() ?? false;

    public virtual bool HasFranchiseHallOfFameData 
        => FranchiseHallOfFames?.Any() ?? false;

    public virtual bool HasFreeAgentSigningData 
        => Service?.FreeAgentSigningDate.HasValue ?? false;

    public virtual bool HasLeaders 
        => Leaders?.Any() ?? false;

    public virtual bool HasRetiredNumbers 
        => RetiredNumbers?.Any() ?? false;

    public virtual bool HasSingleSeasonRecords 
        => SingleSeasonRecords?.Any() ?? false;

    public virtual string LastAppearance 
        => Service?.LastAppearanceDate.HasValue ?? false
            ? $"Last Appearance {Service.LastAppearanceDate.Value:MM/dd/yyyy}"
            : string.Empty;

    public virtual IEnumerable<LeaderProfileModel> Leaders { get; set; } 
        = Enumerable.Empty<LeaderProfileModel>();

    public virtual IEnumerable<RetiredNumberProfileModel> RetiredNumbers { get; set; } 
        = Enumerable.Empty<RetiredNumberProfileModel>();

    public virtual SportServiceProfileModel Service { get; set; }

    public virtual IEnumerable<SingleSeasonRecordProfileModel> SingleSeasonRecords { get; set; } 
        = Enumerable.Empty<SingleSeasonRecordProfileModel>();

    public virtual IEnumerable<TeamProfileModel> Teams { get; set; } 
        = Enumerable.Empty<TeamProfileModel>();
}
