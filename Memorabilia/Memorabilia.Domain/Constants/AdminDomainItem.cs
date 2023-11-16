namespace Memorabilia.Domain.Constants;

public sealed class AdminDomainItem
{
    public static readonly AdminDomainItem AccomplishmentTypes = new("Accomplishment Types", "Defines variations of accomplishments", Constant.ImageFileName.AccomplishmentTypes);
    public static readonly AdminDomainItem AcquisitionTypes = new("Acquisition Types", "Describes how the memorabilia and/or autograph was obtained", Constant.ImageFileName.AcquisitionTypes);
    public static readonly AdminDomainItem AuthenticationCompanies = new("Authentication Companies", "Defines third party companies that ensure the authenticity of autographs", Constant.ImageFileName.AuthenticationCompanies, "Authentication Company");
    public static readonly AdminDomainItem AwardTypes = new("Award Types", "Defines variations of awards", Constant.ImageFileName.AwardTypes);
    public static readonly AdminDomainItem BammerTypes = new("Bammer Types", "Defines variations of bammers", Constant.ImageFileName.Bammer);
    public static readonly AdminDomainItem BaseballTypes = new("Baseball Types", "Defines variations of baseballs", Constant.ImageFileName.BaseballTypes);
    public static readonly AdminDomainItem BasketballTypes = new("Basketball Types", "Defines variations of basketballs", Constant.ImageFileName.BasketballTypes);
    public static readonly AdminDomainItem BatTypes = new("Bat Types", "Defines variations of bats", Constant.ImageFileName.BatTypes);
    public static readonly AdminDomainItem Brands = new("Brands", "Defines the brands memorabilia can have", Constant.ImageFileName.Brands);
    public static readonly AdminDomainItem CerealTypes = new("Cereal Types", "Defines the types of cereal", Constant.ImageFileName.CerealTypes);
    public static readonly AdminDomainItem ChampionTypes = new("Champion Types", "Defines the championships in various sports", Constant.ImageFileName.ChampionshipTypes);
    public static readonly AdminDomainItem Colleges = new("Colleges", "Defines colleges", Constant.ImageFileName.Colleges);
    public static readonly AdminDomainItem Colors = new("Colors", "Defines the colors for autographs", Constant.ImageFileName.Colors);
    public static readonly AdminDomainItem Commissioners = new("Commissioners", "Specifies the commissioners of each sport", Constant.ImageFileName.Commissioners);
    public static readonly AdminDomainItem Conditions = new("Conditions", "Defines the conditions for memorabila and autographs", Constant.ImageFileName.Conditions);
    public static readonly AdminDomainItem Conferences = new("Conferences", "Defines conferences of sports", Constant.ImageFileName.Conferences);
    public static readonly AdminDomainItem DashboardItems = new("Dashboard Items", "Defines the types of dashboard items", Constant.ImageFileName.Dashboard);
    public static readonly AdminDomainItem Divisions = new("Divisions", "Defines divisions of conferences", Constant.ImageFileName.Divisions);
    public static readonly AdminDomainItem FigureSpecialtyTypes = new("Figure Specialty Types", "Defines variations of figure specialty types", Constant.ImageFileName.FigureSpecialtyTypes);
    public static readonly AdminDomainItem FigureTypes = new("Figure Types", "Defines variations of figures", Constant.ImageFileName.Figure);
    public static readonly AdminDomainItem FootballTypes = new("Football Types", "Defines variations of footballs", Constant.ImageFileName.FootballTypes);
    public static readonly AdminDomainItem FranchiseHallOfFameTypes = new("Franchise Hall Of Fame Types", "Defines various hall of fames, ring of honors etc.", Constant.ImageFileName.FranchiseHallOfFameTypes);
    public static readonly AdminDomainItem Franchises = new("Franchises", "Defines sport franchises", Constant.ImageFileName.Franchises);
    public static readonly AdminDomainItem GameStyleTypes = new("Game Style Types", "Describes how the memorabilia was used in a game", Constant.ImageFileName.GameStyleTypes);
    public static readonly AdminDomainItem GloveTypes = new("Glove Types", "Defines variations of gloves", Constant.ImageFileName.GloveTypes);
    public static readonly AdminDomainItem HelmetFinishes = new("Helmet Finishes", "Defines the finish of a helmet", Constant.ImageFileName.HelmetFinishes, "Helmet Finish");
    public static readonly AdminDomainItem HelmetQualityTypes = new("Helmet Quality Types", "Defines the quality of a helmet", Constant.ImageFileName.HelmetQualityTypes);
    public static readonly AdminDomainItem HelmetTypes = new("Helmet Types", "Defines variations of helmets", Constant.ImageFileName.HelmetTypes);
    public static readonly AdminDomainItem ImageTypes = new("Image Types", "Defines the importance of the image", Constant.ImageFileName.ImageTypes);
    public static readonly AdminDomainItem InscriptionTypes = new("Inscription Types", "Defines variations of inscriptions for autographs", Constant.ImageFileName.InscriptionTypes);
    public static readonly AdminDomainItem InternationalHallOfFameTypes = new("International Hall Of Fame Types", "Defines variations of international hall of fames", Constant.ImageFileName.InternationalHallOfFameTypes);
    public static readonly AdminDomainItem ItemTypeBrands = new("Item Type Brands", "Defines which items have which brands", Constant.ImageFileName.Brands);
    public static readonly AdminDomainItem ItemTypeGameStyles = new("Item Type Game Styles", "Defines which items have which game styles", Constant.ImageFileName.GameStyleTypes);
    public static readonly AdminDomainItem ItemTypeLevels = new("Item Type Levels", "Defines which items have which levels", Constant.ImageFileName.LevelTypes);
    public static readonly AdminDomainItem ItemTypeSizes = new("Item Type Sizes", "Defines which items have which sizes", Constant.ImageFileName.Sizes);
    public static readonly AdminDomainItem ItemTypeSports = new("Item Type Sports", "Defines which items have which sports", Constant.ImageFileName.Sports);
    public static readonly AdminDomainItem ItemTypeSpots = new("Item Type Spots", "Defines which items have which spots", Constant.ImageFileName.Spots);
    public static readonly AdminDomainItem ItemTypes = new("Item Types", "Defines memorabilia items", Constant.ImageFileName.ItemTypes);
    public static readonly AdminDomainItem JerseyQualityTypes = new("Jersey Quality Types", "Defines variations of jersey quality types", Constant.ImageFileName.JerseyQualityTypes);
    public static readonly AdminDomainItem JerseyStyleTypes = new("Jersey Style Types", "Defines variations of jersey style types", Constant.ImageFileName.JerseyStyleTypes);
    public static readonly AdminDomainItem JerseyTypes = new("Jersey Types", "Defines variations of jersey types", Constant.ImageFileName.JerseyTypes);
    public static readonly AdminDomainItem LeaderTypes = new("Leader Types", "Defines variations of leaders", Constant.ImageFileName.LeaderTypes);
    public static readonly AdminDomainItem LeaguePresidents = new("League Presidents", "Specifies the jleague presidents of each sport", Constant.ImageFileName.LeaguePresidents);
    public static readonly AdminDomainItem Leagues = new("Leagues", "Defines leagues of a sport", Constant.ImageFileName.Leagues);
    public static readonly AdminDomainItem LevelTypes = new("Level Types", "Defines memorabila level types", Constant.ImageFileName.LevelTypes);
    public static readonly AdminDomainItem MagazineTypes = new("Magazine Types", "Defines variations of magazine types", Constant.ImageFileName.MagazineTypes);
    public static readonly AdminDomainItem Occupations = new("Occupations", "Defines occupations for a person", Constant.ImageFileName.Occupations);
    public static readonly AdminDomainItem Orientations = new("Orientations", "Defines orientations of memorabilia", Constant.ImageFileName.Orientations);
    public static readonly AdminDomainItem People = new("People", "Defines people", Constant.ImageFileName.Athletes, "Person");
    public static readonly AdminDomainItem Pewters = new("Pewters", "Defines variations of pewters", Constant.ImageFileName.Pewters);
    public static readonly AdminDomainItem PhotoTypes = new("Photo Types", "Defines variations of photos", Constant.ImageFileName.Photo);    
    public static readonly AdminDomainItem Positions = new("Positions", "Defines variations of positions", Constant.ImageFileName.Positions);    
    public static readonly AdminDomainItem PriorityTypes = new("Priority Types", "Defines the priority types of projects", Constant.ImageFileName.PriorityTypes);
    public static readonly AdminDomainItem PrivacyTypes = new("Privacy Types", "Defines the privacy types of memorabilia", Constant.ImageFileName.PrivacyTypes);
    public static readonly AdminDomainItem ProjectStatusTypes = new("Project Status Types", "Defines the project status types of memorabilia", Constant.ImageFileName.ProjectStatusTypes);
    public static readonly AdminDomainItem ProjectTypes = new("Project Types", "Defines the project types of memorabilia", Constant.ImageFileName.ProjectTypes);
    public static readonly AdminDomainItem PurchaseTypes = new("Purchase Types", "Defines variations of purchase types", Constant.ImageFileName.PurchaseTypes);
    public static readonly AdminDomainItem RecordTypes = new("Record Types", "Defines variations of record", Constant.ImageFileName.RecordTypes);
    public static readonly AdminDomainItem Sizes = new("Sizes", "Defines variations of sizes", Constant.ImageFileName.Sizes);
    public static readonly AdminDomainItem SportLeagueLevels = new("Sport League Levels", "Defines variations of sport leagues", Constant.ImageFileName.SportLeagueLevels);
    public static readonly AdminDomainItem Sports = new("Sports", "Defines sports", Constant.ImageFileName.Sports);
    public static readonly AdminDomainItem Spots = new("Spots", "Defines variations of autograph spots", Constant.ImageFileName.Spots);
    public static readonly AdminDomainItem TeamRoleTypes = new("Team Role Types", "Defines the variations of roles in a team", Constant.ImageFileName.TeamRoleTypes);
    public static readonly AdminDomainItem Teams = new("Teams", "Defines teams", Constant.ImageFileName.Teams);
    public static readonly AdminDomainItem ThroughTheMailFailureTypes = new("Through The Mail Failure Types", "Defines types of failure when sending items through the mail", Constant.ImageFileName.ThroughTheMailFailureTypes);
    public static readonly AdminDomainItem TransactionTypes = new("Transaction Types", "Defines types of transactions for memorabilia", Constant.ImageFileName.TransactionTypes);
    public static readonly AdminDomainItem WritingInstruments = new("Writing Instruments", "Defines variations of writing instruments", Constant.ImageFileName.WritingInstruments);

    public static readonly AdminDomainItem[] All =
    [
        AccomplishmentTypes,
        AcquisitionTypes,
        AuthenticationCompanies,
        AwardTypes,
        BammerTypes,
        BaseballTypes,
        BasketballTypes,
        BatTypes,
        Brands,
        CerealTypes,
        ChampionTypes,
        Colleges,
        Colors,
        Commissioners,
        Conditions,
        Conferences,
        DashboardItems,
        Divisions,
        FigureSpecialtyTypes,
        FigureTypes,
        FootballTypes,
        FranchiseHallOfFameTypes,
        Franchises,
        GameStyleTypes,
        GloveTypes,
        HelmetFinishes,
        HelmetQualityTypes,
        HelmetTypes,
        InscriptionTypes,
        InternationalHallOfFameTypes,
        ItemTypeBrands,
        ItemTypeGameStyles,
        ItemTypeLevels,
        ItemTypeSizes,
        ItemTypeSports,
        ItemTypeSpots,
        ItemTypes,
        JerseyQualityTypes,
        JerseyStyleTypes,
        JerseyTypes,
        LeaderTypes,
        LeaguePresidents,
        Leagues,
        LevelTypes,
        MagazineTypes,
        Occupations,
        Orientations,
        People,
        Pewters,
        PhotoTypes,   
        Positions,
        PriorityTypes,
        PrivacyTypes,
        ProjectStatusTypes,
        ProjectTypes,
        PurchaseTypes,
        RecordTypes,
        Sizes,
        SportLeagueLevels,
        Sports,
        Spots,
        TeamRoleTypes,
        Teams,
        ThroughTheMailFailureTypes,
        TransactionTypes,
        WritingInstruments
    ];

    private AdminDomainItem(string title, 
                            string description, 
                            string imageFileName, 
                            string item = null)
    {
        Title = title;
        Description = description;
        ImageFileName = imageFileName;

        Item = !item.IsNullOrEmpty() 
            ? item 
            : Title.TrimEnd('s');
    }

    public string Description { get; }

    public string ImageFileName { get; }

    public string Item { get; }

    public string Page 
        => Title.Replace(" ", "");

    public string Title { get; }
}
