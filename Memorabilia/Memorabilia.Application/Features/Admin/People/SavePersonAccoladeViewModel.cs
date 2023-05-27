using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAccoladeViewModel : SaveViewModel
{
    public SavePersonAccoladeViewModel() { }

    public SavePersonAccoladeViewModel(int personId, PersonAccoladeViewModel viewModel)
    {
        PersonId = personId;
        Accomplishments = viewModel.Accomplishments
                                   .Select(accomplishment => new SavePersonAccomplishmentViewModel(accomplishment))
                                   .OrderBy(accomplishment => accomplishment.AccomplishmentTypeName)
                                   .ToList();
        AllStars = viewModel.AllStars
                            .Select(allStar => new SavePersonAllStarViewModel(allStar))
                            .OrderBy(allStar => allStar.Year)
                            .ToList();
        Awards = viewModel.Awards
                          .Select(award => new SavePersonAwardViewModel(award))
                          .OrderBy(award => award.AwardTypeName)
                          .ThenBy(award => award.Year)
                          .ToList();
        CareerRecords = viewModel.CareerRecords
                                 .Select(careerRecord => new SavePersonCareerRecordViewModel(careerRecord))
                                 .OrderBy(careerRecord => careerRecord.RecordTypeName)
                                 .ToList();
        CollegeRetiredNumbers = viewModel.CollegeRetiredNumbers
                                         .Select(retiredNumber => new SavePersonCollegeRetiredNumberViewModel(retiredNumber))
                                         .OrderBy(retiredNumber => retiredNumber.CollegeName)
                                         .ToList();
        Colleges = viewModel.Colleges;
        Leaders = viewModel.Leaders
                           .Select(leader => new SavePersonLeaderViewModel(leader))
                           .OrderBy(leader => leader.LeaderTypeName)
                           .ThenBy(leader => leader.Year)
                           .ToList();
        RetiredNumbers = viewModel.RetiredNumbers
                                  .Select(retiredNumber => new SavePersonRetiredNumberViewModel(retiredNumber))
                                  .OrderBy(retiredNumber => retiredNumber.FranchiseName)
                                  .ToList();
        SingleSeasonRecords = viewModel.SingleSeasonRecords
                                       .Select(singleSeasonRecord => new SavePersonSingleSeasonRecordViewModel(singleSeasonRecord))
                                       .OrderBy(singleSeasonRecord => singleSeasonRecord.RecordTypeName)
                                       .ToList();
        Sports = viewModel.Sports
                          .Select(sport => Sport.Find(sport.SportId))
                          .ToArray();
    }

    public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

    public string AllStarGameLabel
    {
        get
        {
            var hasAllStarGames = Sport.HasAllStarGames(Sports);
            var hasProBowlGames = Sport.HasProBowlGames(Sports);

            if (hasAllStarGames && hasProBowlGames)
                return "All Stars & Pro Bowls";
            else if (hasAllStarGames)
                return "All Stars";
            else if (hasProBowlGames)
                return "Pro Bowls";

            return "All Stars";
        }
    }

    public List<SavePersonAllStarViewModel> AllStars { get; set; } = new();

    public List<SavePersonAwardViewModel> Awards { get; set; } = new();

    public override string BackNavigationPath => $"{AdminDomainItem.People.Title}/{AdminDomainItem.Teams.Item}/{EditModeType.Update.Name}/{PersonId}";

    public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

    public List<SavePersonCollegeRetiredNumberViewModel> CollegeRetiredNumbers { get; set; } = new();

    public College[] Colleges = Array.Empty<College>();

    public override string ContinueNavigationPath 
        => $"{AdminDomainItem.People.Title}/HallOfFame/{EditModeType.Update.Name}/{PersonId}";

    public bool DisplayAllStars => Sport.HasAllStarGames(Sports) || Sport.HasProBowlGames(Sports);

    public override EditModeType EditModeType => AllStars.Any() ? EditModeType.Update : EditModeType.Add;

    public string ImageFileName => Domain.Constants.ImageFileName.Athletes;

    public override string ItemTitle => "Accolade";

    public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

    public override string PageTitle => $"{(EditModeType == EditModeType.Update ? EditModeType.Update.Name : EditModeType.Add.Name)} Accolades";

    public int PersonId { get; set; }

    public PersonStep PersonStep => PersonStep.Accolade;

    public List<SavePersonRetiredNumberViewModel> RetiredNumbers { get; set; } = new();

    public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();

    public Sport[] Sports { get; set; } = Array.Empty<Sport>();
}
