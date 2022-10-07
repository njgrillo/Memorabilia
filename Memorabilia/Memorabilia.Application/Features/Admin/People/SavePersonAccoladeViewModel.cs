using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAccoladeViewModel : SaveViewModel
{
    public SavePersonAccoladeViewModel() { }

    public SavePersonAccoladeViewModel(int personId, PersonAccoladeViewModel viewModel)
    {
        PersonId = personId;
        Accomplishments = viewModel.Accomplishments.Select(accomplishment => new SavePersonAccomplishmentViewModel(accomplishment))
                                                   .OrderBy(accomplishment => accomplishment.AccomplishmentTypeName)
                                                   .ToList();
        AllStarYears = viewModel.AllStars.Select(allStar => allStar.Year)
                                         .OrderBy(year => year)
                                         .ToList();
        Awards = viewModel.Awards.Select(award => new SavePersonAwardViewModel(award))
                                 .OrderBy(award => award.AwardTypeName)
                                 .ThenBy(award => award.Year)
                                 .ToList();
        CareerRecords = viewModel.CareerRecords.Select(careerRecord => new SavePersonCareerRecordViewModel(careerRecord))
                                               .OrderBy(careerRecord => careerRecord.RecordTypeName)
                                               .ToList();
        Leaders = viewModel.Leaders.Select(leader => new SavePersonLeaderViewModel(leader))
                                   .OrderBy(leader => leader.LeaderTypeName)
                                   .ThenBy(leader => leader.Year)
                                   .ToList();
        RetiredNumbers = viewModel.RetiredNumbers.Select(retiredNumber => new SavePersonRetiredNumberViewModel(retiredNumber))
                                                 .OrderBy(retiredNumber => retiredNumber.FranchiseName)
                                                 .ToList();
        SingleSeasonRecords = viewModel.SingleSeasonRecords.Select(singleSeasonRecord => new SavePersonSingleSeasonRecordViewModel(singleSeasonRecord))
                                                           .OrderBy(singleSeasonRecord => singleSeasonRecord.RecordTypeName)
                                                           .ToList();
        SportIds = viewModel.Sports.Select(sport => sport.SportId).ToArray();
        AccomplishmentTypes = AccomplishmentType.GetAll(SportIds);
        AwardTypes = AwardType.GetAll(SportIds);
        Franchises = Franchise.GetAll(SportIds);
        LeaderTypes = LeaderType.GetAll(SportIds);
        RecordTypes = RecordType.GetAll(SportIds);
    }

    public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

    public AccomplishmentType[] AccomplishmentTypes { get; set; } = AccomplishmentType.All;

    public string AllStarGameLabel
    {
        get
        {
            var hasAllStarGames = Sport.HasAllStarGames(SportIds);
            var hasProBowlGames = Sport.HasProBowlGames(SportIds);

            if (hasAllStarGames && hasProBowlGames)
                return "All Star & Pro Bowl Games";
            else if (hasAllStarGames)
                return "All Star Games";
            else if (hasProBowlGames)
                return "Pro Bowl Games";

            return "All Star Games";
        }
    }

    public List<int> AllStarYears { get; set; } = new();

    public List<SavePersonAwardViewModel> Awards { get; set; } = new();

    public AwardType[] AwardTypes { get; set; } = AwardType.All;

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/{AdminDomainItem.Teams.Item}/{EditModeType.Update.Name}/{PersonId}";

    public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

    public override string ContinueNavigationPath => $"{AdminDomainItem.People.Title}/HallOfFame/{EditModeType.Update.Name}/{PersonId}";

    public bool DisplayAllStars => Sport.HasAllStarGames(SportIds) || Sport.HasProBowlGames(SportIds);

    public override EditModeType EditModeType => AllStarYears.Any() ? EditModeType.Update : EditModeType.Add;

    public Franchise[] Franchises { get; set; } = Franchise.All;

    public string ImagePath => Domain.Constants.ImagePath.Athletes;

    public override string ItemTitle => "Accolade";

    public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

    public LeaderType[] LeaderTypes { get; set; } = LeaderType.All;

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Accolades";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.Accolade;

    public RecordType[] RecordTypes { get; set; } = RecordType.All;

    public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

    public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();

    public int[] SportIds { get; set; } = Array.Empty<int>();
}
