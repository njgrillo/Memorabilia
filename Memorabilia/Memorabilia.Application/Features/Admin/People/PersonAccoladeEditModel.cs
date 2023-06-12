namespace Memorabilia.Application.Features.Admin.People;

public class PersonAccoladeEditModel : EditModel
{
    public PersonAccoladeEditModel() { }

    public PersonAccoladeEditModel(int personId, PersonAccoladeModel model)
    {
        PersonId = personId;

        Accomplishments = model.Accomplishments
                               .ToEditModelList()
                               .OrderBy(accomplishment => accomplishment.AccomplishmentTypeName)
                               .ToList();

        AllStars = model.AllStars
                        .ToEditModelList()
                        .OrderBy(allStar => allStar.Year)
                        .ToList();

        Awards = model.Awards
                      .ToEditModelList()
                      .OrderBy(award => award.AwardTypeName)
                      .ThenBy(award => award.Year)
                      .ToList();

        CareerRecords = model.CareerRecords
                             .ToEditModelList()
                             .OrderBy(careerRecord => careerRecord.RecordTypeName)
                             .ToList();

        CollegeRetiredNumbers = model.CollegeRetiredNumbers
                                     .ToEditModelList()
                                     .OrderBy(retiredNumber => retiredNumber.CollegeName)
                                     .ToList();

        Colleges = model.Colleges;

        Leaders = model.Leaders
                       .ToEditModelList()
                       .OrderBy(leader => leader.LeaderTypeName)
                       .ThenBy(leader => leader.Year)
                       .ToList();

        RetiredNumbers = model.RetiredNumbers
                              .ToEditModelList()
                              .OrderBy(retiredNumber => retiredNumber.FranchiseName)
                              .ToList();

        SingleSeasonRecords = model.SingleSeasonRecords
                                   .ToEditModelList()
                                   .OrderBy(singleSeasonRecord => singleSeasonRecord.RecordTypeName)
                                   .ToList();

        Sports = model.Sports.ToConstantArray();
    }

    public List<PersonAccomplishmentEditModel> Accomplishments { get; set; } 
        = new();

    public string AllStarGameLabel
    {
        get
        {
            bool hasAllStarGames = Constant.Sport.HasAllStarGames(Sports);
            bool hasProBowlGames = Constant.Sport.HasProBowlGames(Sports);

            if (hasAllStarGames && hasProBowlGames)
                return "All Stars & Pro Bowls";
            else if (hasAllStarGames)
                return "All Stars";
            else if (hasProBowlGames)
                return "Pro Bowls";

            return "All Stars";
        }
    }

    public List<PersonAllStarEditModel> AllStars { get; set; } 
        = new();

    public List<PersonAwardEditModel> Awards { get; set; } 
        = new();

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Teams.Item}/{Constant.EditModeType.Update.Name}/{PersonId}";

    public List<PersonCareerRecordEditModel> CareerRecords { get; set; } 
        = new();

    public List<PersonCollegeRetiredNumberEditModel> CollegeRetiredNumbers { get; set; } 
        = new();

    public Constant.College[] Colleges 
        = Array.Empty<Constant.College>();

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/HallOfFame/{Constant.EditModeType.Update.Name}/{PersonId}";

    public bool DisplayAllStars 
        => Constant.Sport.HasAllStarGames(Sports) || 
           Constant.Sport.HasProBowlGames(Sports);

    public override Constant.EditModeType EditModeType 
        => AllStars.Any() 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => "Accolade";

    public List<PersonLeaderEditModel> Leaders { get; set; } 
        = new();

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Update ? Constant.EditModeType.Update.Name : Constant.EditModeType.Add.Name)} Accolades";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Accolade;

    public List<PersonRetiredNumberEditModel> RetiredNumbers { get; set; } 
        = new();

    public List<PersonSingleSeasonRecordEditModel> SingleSeasonRecords { get; set; } 
        = new();

    public Constant.Sport[] Sports { get; set; } 
        = Array.Empty<Constant.Sport>();
}
