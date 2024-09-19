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

        CareerFranchiseRecords = model.CareerFranchiseRecords
                                      .ToEditModelList()
                                      .OrderBy(careerFranchiseRecord => careerFranchiseRecord.RecordTypeName)
                                      .ThenBy(careerFranchiseRecord => careerFranchiseRecord.Record)
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

        Franchises = model.Franchises.ToArray();

        Leaders = model.Leaders
                       .ToEditModelList()
                       .OrderBy(leader => leader.LeaderTypeName)
                       .ThenBy(leader => leader.Year)
                       .ToList();

        RetiredNumbers = model.RetiredNumbers
                              .ToEditModelList()
                              .OrderBy(retiredNumber => retiredNumber.FranchiseName)
                              .ToList();

        SingleSeasonFranchiseRecords = model.SingleSeasonFranchiseRecords
                                            .ToEditModelList()
                                            .OrderBy(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.RecordTypeName)
                                            .ToList();

        SingleSeasonRecords = model.SingleSeasonRecords
                                   .ToEditModelList()
                                   .OrderBy(singleSeasonRecord => singleSeasonRecord.RecordTypeName)
                                   .ToList();

        Sports = model.Sports.ToConstantArray();
    }

    public List<PersonAccomplishmentEditModel> Accomplishments { get; set; } 
        = [];

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
        = [];

    public List<PersonAwardEditModel> Awards { get; set; } 
        = [];

    public override string BackNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/{Constant.AdminDomainItem.Teams.Item}/{Constant.EditModeType.Update.Name}/{PersonId}";

    public List<PersonCareerFranchiseRecordEditModel> CareerFranchiseRecords { get; set; }
        = [];

    public List<PersonCareerRecordEditModel> CareerRecords { get; set; } 
        = [];

    public List<PersonCollegeRetiredNumberEditModel> CollegeRetiredNumbers { get; set; } 
        = [];

    public Constant.College[] Colleges 
        = [];

    public override string ContinueNavigationPath 
        => $"{Constant.AdminDomainItem.People.Title}/HallOfFame/{Constant.EditModeType.Update.Name}/{PersonId}";

    public bool DisplayAllStars 
        => Constant.Sport.HasAllStarGames(Sports) || 
           Constant.Sport.HasProBowlGames(Sports);

    public override Constant.EditModeType EditModeType 
        => AllStars.Count != 0
            ? Constant.EditModeType.Update 
            : Constant.EditModeType.Add;

    public Constant.Franchise[] Franchises { get; set; }
        = [];

    public string ImageFileName 
        => Constant.ImageFileName.Athletes;

    public override string ItemTitle 
        => "Accolade";

    public List<PersonLeaderEditModel> Leaders { get; set; } 
        = [];

    public string MenuItemPath
        => "People";

    public override string PageTitle 
        => $"{EditModeType.ToEditModeTypeName()} Accolades";

    public int PersonId { get; set; }

    public Constant.PersonStep PersonStep 
        => Constant.PersonStep.Accolade;

    public int RecordCount
        => CareerFranchiseRecords.Count(record => !record.IsDeleted) + 
           CareerRecords.Count(record => !record.IsDeleted) + 
           SingleSeasonFranchiseRecords.Count(record => !record.IsDeleted) + 
           SingleSeasonRecords.Count(record => !record.IsDeleted);

    public List<PersonRetiredNumberEditModel> RetiredNumbers { get; set; } 
        = [];

    public List<PersonSingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords { get; set; }
        = [];

    public List<PersonSingleSeasonRecordEditModel> SingleSeasonRecords { get; set; } 
        = [];

    public Constant.Sport[] Sports { get; set; } 
        = [];
}
