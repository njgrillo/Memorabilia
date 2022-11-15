using Memorabilia.Domain.Constants;

namespace Memorabilia.Domain.Entities;

public class Memorabilia : Framework.Library.Domain.Entity.DomainEntity
{
    public Memorabilia() { }

    public Memorabilia(Memorabilia memorabilia)
    {
        Id = memorabilia.Id;

        Autographs = memorabilia.Autographs;
        Bammer = memorabilia.Bammer;
        Baseball = memorabilia.Baseball;
        Basketball = memorabilia.Basketball;
        Bat = memorabilia.Bat;
        Bobblehead = memorabilia.Bobblehead;
        Book = memorabilia.Book;
        Brand = memorabilia.Brand;
        Card = memorabilia.Card;
        Commissioner = memorabilia.Commissioner;
        ConditionId = memorabilia.ConditionId;
        CreateDate = memorabilia.CreateDate;
        Denominator = memorabilia.Denominator;
        Figure = memorabilia.Figure;
        Football = memorabilia.Football;
        EstimatedValue = memorabilia.EstimatedValue;
        Game = memorabilia.Game;
        Glove = memorabilia.Glove;
        Helmet = memorabilia.Helmet;
        Images = memorabilia.Images;
        ItemTypeId = memorabilia.ItemTypeId;
        Jersey = memorabilia.Jersey;
        LastModifiedDate = memorabilia.LastModifiedDate;
        LevelType = memorabilia.LevelType;
        Magazine = memorabilia.Magazine;
        MemorabiliaAcquisition = memorabilia.MemorabiliaAcquisition;
        Note = memorabilia.Note;
        Numerator = memorabilia.Numerator;
        People = memorabilia.People;
        Picture = memorabilia.Picture;
        PrivacyTypeId = memorabilia.PrivacyTypeId;
        Size = memorabilia.Size;
        Sports = memorabilia.Sports;
        Teams = memorabilia.Teams;
        User = memorabilia.User;
        UserId = memorabilia.UserId;
    }

    public Memorabilia(DateTime? acquiredDate,
                       bool acquiredWithAutograph,
                       int acquisitionTypeId,
                       int? conditionId,
                       decimal? cost,
                       int? denominator,
                       decimal? estimatedValue,
                       int itemTypeId,
                       string note,
                       int? numerator,
                       int privacyTypeId,                           
                       int? purchaseTypeId,
                       int userId)
    {            
        ConditionId = conditionId;
        CreateDate = DateTime.UtcNow;
        Denominator = denominator;
        EstimatedValue = estimatedValue;
        Numerator = numerator;
        Note = note;
        ItemTypeId = itemTypeId;
        PrivacyTypeId = privacyTypeId;            
        UserId = userId;

        if (acquisitionTypeId > 0)
            MemorabiliaAcquisition = new MemorabiliaAcquisition(Id, 
                                                                acquisitionTypeId, 
                                                                acquiredDate, 
                                                                acquiredWithAutograph, 
                                                                cost, 
                                                                purchaseTypeId);
    }

    public virtual Acquisition Acquisition => MemorabiliaAcquisition.Acquisition;

    public virtual List<Autograph> Autographs { get; private set; } = new ();

    public virtual MemorabiliaBammer Bammer { get; private set; }

    public virtual MemorabiliaBaseball Baseball { get; private set; }

    public virtual MemorabiliaBasketball Basketball { get; private set; }

    public virtual MemorabiliaBat Bat { get; private set; }

    public virtual MemorabiliaBobblehead Bobblehead { get; private set; }

    public virtual MemorabiliaBook Book { get; private set; }

    public virtual MemorabiliaBrand Brand { get; private set; }

    public virtual MemorabiliaCard Card { get; private set; }

    public virtual MemorabiliaCommissioner Commissioner { get; private set; }

    public Constants.Condition Condition => Constants.Condition.Find(ConditionId ?? 0);

    public int? ConditionId { get; private set; }

    public DateTime CreateDate { get; private set; }

    public int? Denominator { get; private set; }

    public virtual MemorabiliaFigure Figure { get; private set; }

    public virtual MemorabiliaFirstDayCover FirstDayCover { get; private set; }

    public virtual MemorabiliaFootball Football { get; private set; }

    public decimal? EstimatedValue { get; private set; }

    public virtual MemorabiliaGame Game { get; private set; }

    public virtual MemorabiliaGlove Glove { get; private set; }

    public virtual MemorabiliaHelmet Helmet { get; private set; }

    public virtual List<MemorabiliaImage> Images { get; private set; } = new ();

    public Constants.ItemType ItemType => Constants.ItemType.Find(ItemTypeId);

    public int ItemTypeId { get; private set; }

    public virtual MemorabiliaJersey Jersey { get; private set; }

    public DateTime? LastModifiedDate { get; private set; }

    public virtual MemorabiliaLevelType LevelType { get; private set; }

    public virtual MemorabiliaMagazine Magazine { get; private set; }

    public virtual MemorabiliaAcquisition MemorabiliaAcquisition { get; private set; }

    public string Note { get; private set; }

    public int? Numerator { get; private set; }

    public virtual List<MemorabiliaPerson> People { get; private set; } = new ();

    public virtual MemorabiliaPicture Picture { get; private set; }

    public int PrivacyTypeId { get; private set; }

    public virtual MemorabiliaSize Size { get; private set; }

    public virtual List<MemorabiliaSport> Sports { get; private set; } = new ();

    public virtual List<MemorabiliaTeam> Teams { get; private set; } = new ();

    public virtual User User { get; set; }

    public int UserId { get; private set; }        

    public void Set(DateTime? acquiredDate,
                    bool acquiredWithAutograph,
                    int acquisitionTypeId,
                    int? conditionId,
                    decimal? cost,
                    int? denominator,
                    decimal? estimatedValue,
                    string note,
                    int? numerator,
                    int privacyTypeId,                        
                    int? purchaseTypeId)
    {
        ConditionId = conditionId;
        Denominator = denominator;
        EstimatedValue = estimatedValue;
        LastModifiedDate = DateTime.UtcNow;
        Numerator = numerator;
        Note = note;
        PrivacyTypeId = privacyTypeId; 

        MemorabiliaAcquisition.Set(acquisitionTypeId, acquiredDate, acquiredWithAutograph, cost, purchaseTypeId);
    }

    public void SetBammer(int? bammerTypeId,
                          int brandId,
                          bool inPackage,
                          int levelTypeId,
                          int[] personIds,
                          int? sportId,
                          int[] teamIds,
                          int? year)
    {
        SetBrand(brandId);
        SetBammerType(bammerTypeId, inPackage, year);
        SetLevelType(levelTypeId);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetBaseball(string anniversary,                                
                            int? baseballTypeId,  
                            int brandId, 
                            int commissionerId, 
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int? leaguePresidentId,
                            int levelTypeId,
                            int? personId,
                            int sizeId, 
                            int sportId,
                            int[] teamIds,
                            int? year)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetTeams(teamIds);
        SetBaseballType(baseballTypeId, leaguePresidentId, year, anniversary);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetBasketball(int? basketballTypeId,
                              int brandId,
                              int commissionerId,
                              DateTime? gameDate,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int sportId,
                              int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetBasketballType(basketballTypeId.Value);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetBat(int? batTypeId,
                       int brandId,
                       int? colorId,
                       DateTime? gameDate,
                       int? gameStyleTypeId,
                       int? length,
                       int? personId,
                       int sizeId,
                       int sportId,
                       int? teamId)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetSports(sportId);
        SetBatType(batTypeId, colorId, length);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetBobblehead(int brandId,
                              bool hasBox,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int? sportId,
                              int? teamId,
                              int? year)
    {
        SetBrand(brandId);
        SetBobblehead(year, hasBox);
        SetLevelType(levelTypeId);
        SetSize(sizeId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetBook(string edition,
                        bool hardCover,
                        int[] personIds,
                        string publisher,
                        int[] sportIds,
                        int[] teamIds,
                        string title)
    {
        SetBook(edition, hardCover, publisher, title);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetBookplate(int? personId)
    {
        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetCard(int brandId,
                        bool custom,
                        int levelTypeId,
                        bool licensed,
                        int orientationId,
                        int[] personIds,
                        int sizeId,
                        int[] sportIds,
                        int[] teamIds,
                        int? year)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetCard(orientationId, custom, licensed, year);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetCanvas(int brandId,
                          bool framed,
                          bool matted,
                          int orientationId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          bool stretched,
                          int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted, stretched);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetCerealBox(int brandId,
                             int levelTypeId,
                             int[] personIds,
                             int[] sportIds,
                             int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetCompactDisc(int[] personIds)
    {
        SetPeople(personIds);
    }

    public void SetDocument(int[] personIds, 
                            int sizeId,                                
                            int[] teamIds)
    {
        SetPeople(personIds);
        SetSize(sizeId);            
        SetTeams(teamIds);
    }

    public void SetDrum(int brandId, int[] personIds)
    {
        SetBrand(brandId);
        SetPeople(personIds);
    }

    public void SetFigure(int brandId,
                          int? figureSpecialtyTypeId,
                          int? figureTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          int[] teamIds,
                          int? year)
    {
        SetBrand(brandId);
        SetFigureType(figureSpecialtyTypeId, figureTypeId, year);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetFirstDayCover(int[] personIds,
                                 int sizeId,
                                 DateTime? date,
                                 int[] sportIds,
                                 int[] teamIds)
    {
        SetSize(sizeId);
        SetFirstDayCover(date);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetFootball(int brandId,
                            int commissionerId,
                            int? footballTypeId,
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int? personId,
                            int sizeId,
                            int sportId,
                            int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetFootballType(footballTypeId.Value);
        SetCommissioner(commissionerId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetGlove(int brandId,
                         DateTime? gameDate,
                         int? gamePersonId,
                         int? gameStyleTypeId,
                         int? gloveTypeId,
                         int levelTypeId,
                         int[] personIds,
                         int sizeId,
                         int? sportId,
                         int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, gamePersonId, gameDate);
        SetGloveType(gloveTypeId);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetGolfball(int brandId,
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int? personId,
                            int sizeId,
                            int sportId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetGuitar(int brandId, int[] personIds, int sizeId)
    {
        SetBrand(brandId);
        SetPeople(personIds);
        SetSize(sizeId);
    }

    public void SetHat(int brandId,
                       DateTime? gameDate,
                       int? gamePersonId,
                       int? gameStyleTypeId,
                       int levelTypeId,
                       int[] personIds,
                       int sizeId,
                       int? sportId,
                       int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, gamePersonId, gameDate);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetHeadBand(int brandId,
                            DateTime? gameDate,
                            int? gameStyleTypeId,
                            int levelTypeId,
                            int? personId,
                            int sizeId,
                            int? sportId,
                            int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSize(sizeId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetHelmet(int brandId,
                          DateTime? gameDate,
                          int? gameStyleTypeId,
                          int? helmetFinishId,
                          int? helmetQualityTypeId,
                          int? helmetTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          bool throwback,
                          params int[] teamIds)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportIds);
        SetHelmet(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
        SetGame(gameStyleTypeId, personIds.Any() ? personIds.First() : null, gameDate);
        SetTeams(teamIds);
        SetPeople(personIds);
    }

    public void SetHockeyStick(int brandId,
                               DateTime? gameDate,
                               int? gameStyleTypeId,
                               int levelTypeId,
                               int? personId,
                               int sizeId,
                               int sportId,
                               int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSports(sportId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetImages(IEnumerable<string> fileNames, string primaryImageFileName)
    {
        if (!fileNames.Any())
        {
            Images = new List<MemorabiliaImage>();
            return;
        }

        Images = fileNames.Select(fileName =>
                                    new MemorabiliaImage(Id,
                                                         fileName,
                                                         fileName == primaryImageFileName
                                                             ? Constants.ImageType.Primary.Id 
                                                             : Constants.ImageType.Secondary.Id,
                                                         DateTime.UtcNow)).ToList();
    }

    public void SetIndexCard(int sizeId)
    {
        SetSize(sizeId);
    }

    public void SetJersey(int brandId, 
                          DateTime? gameDate,
                          int? gameStyleTypeId,
                          int levelTypeId,
                          int[] personIds,
                          int qualityTypeId,                              
                          int sizeId, 
                          int? sportId,
                          int styleTypeId,
                          int[] teamIds,
                          int typeId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetJersey(qualityTypeId, styleTypeId, typeId);
        SetGame(gameStyleTypeId, personIds.FirstOrDefault(), gameDate);
        SetPeople(personIds);
        SetTeams(teamIds);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetJerseyNumber(int? personId, int? sportId, int? teamId)
    {
        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetLithograph(int brandId,
                              bool framed,
                              bool matted,
                              int orientationId,
                              int[] personIds,
                              int sizeId,
                              int[] sportIds,
                              int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetMagazine(int brandId,
                            DateTime? date,
                            bool framed,
                            bool matted,
                            int orientationId,
                            int[] personIds,
                            int sizeId,
                            int[] sportIds,
                            int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetMagazine(orientationId, date, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);            
    }

    public void SetPainting(int brandId,
                            bool framed,
                            bool matted,
                            int orientationId,
                            int[] personIds,
                            int sizeId,
                            int[] sportIds,
                            int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetPant(int brandId,
                        DateTime? gameDate,
                        int? gameStyleTypeId,
                        int levelTypeId,
                        int? personId,
                        int sizeId,
                        int? sportId,
                        int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetPhoto(int brandId,
                         bool framed,
                         bool matted,
                         int orientationId,
                         int[] personIds,
                         int? photoTypeId,
                         int sizeId,
                         int[] sportIds,
                         int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted, photoTypeId: photoTypeId);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetPinFlag(DateTime? gameDate,
                           int? gameStyleTypeId, 
                           int? personId, 
                           int sportId)
    {
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSports(sportId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetPlayingCard(int? personId, int sizeId, int? sportId, int? teamId)
    {
        SetSize(sizeId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetPoster(int brandId,
                          bool framed,
                          bool matted,
                          int orientationId,
                          int[] personIds,
                          int sizeId,
                          int[] sportIds,
                          int[] teamIds)
    {
        SetBrand(brandId);
        SetSize(sizeId);
        SetPicture(orientationId, framed, matted);
        SetPeople(personIds);
        SetSports(sportIds);
        SetTeams(teamIds);
    }

    public void SetPuck(int brandId,
                        DateTime? gameDate,
                        int? gameStyleTypeId,
                        int levelTypeId,
                        int? personId,
                        int sizeId,
                        int sportId,
                        int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetSports(sportId);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetPeople(teamId.Value);
    }

    public void SetPylon(DateTime? gameDate,
                         int? gameStyleTypeId,
                         int levelTypeId,
                         int sizeId,
                         int sportId,
                         int? teamId)
    {
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId: gameStyleTypeId, gameDate: gameDate);
        SetSports(sportId);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetShirt(int brandId,
                         DateTime? gameDate,
                         int? gameStyleTypeId,
                         int levelTypeId,
                         int? personId,
                         int sizeId,
                         int? sportId,
                         int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetShoe(int brandId,
                        DateTime? gameDate,
                        int? gameStyleTypeId,
                        int levelTypeId,
                        int? personId,
                        int sizeId,
                        int? sportId,
                        int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetSoccerball(int brandId,
                              DateTime? gameDate,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int? sportId,
                              int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    public void SetTennisball(int brandId,
                              DateTime? gameDate,
                              int? gameStyleTypeId,
                              int levelTypeId,
                              int? personId,
                              int sizeId,
                              int sportId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetTennisRacket(int brandId,
                                DateTime? gameDate,
                                int? gameStyleTypeId,
                                int levelTypeId,
                                int? personId,
                                int sizeId,
                                int sportId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetSports(sportId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);
    }

    public void SetTicket(DateTime? gameDate,
                          int? gameStyleTypeId,
                          int levelTypeId,
                          int? personId,
                          int sizeId,
                          int? sportId,
                          int[] teamIds)
    {
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);
        SetTeams(teamIds);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetTrunk(int brandId,
                         DateTime? gameDate,
                         int? gameStyleTypeId,
                         int levelTypeId,
                         int? personId,
                         int sizeId,
                         int? sportId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetSize(sizeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);
    }

    public void SetWristBand(int brandId,
                             DateTime? gameDate,
                             int? gameStyleTypeId,
                             int levelTypeId,
                             int? personId,
                             int? sportId,
                             int? teamId)
    {
        SetBrand(brandId);
        SetLevelType(levelTypeId);
        SetGame(gameStyleTypeId, personId, gameDate);

        if (!personId.HasValue)
            People = new List<MemorabiliaPerson>();
        else
            SetPeople(personId.Value);

        if (!sportId.HasValue)
            Sports = new List<MemorabiliaSport>();
        else
            SetSports(sportId.Value);

        if (!teamId.HasValue)
            Teams = new List<MemorabiliaTeam>();
        else
            SetTeams(teamId.Value);
    }

    private void SetBammerType(int? bammerTypeId, bool inPackage, int? year)
    {
        if (bammerTypeId.HasValue)
        {
            if (Brand.BrandId != Constants.Brand.Salvino.Id)
                return;

            if (Bammer == null)
            {
                Bammer = new MemorabiliaBammer(Id, bammerTypeId.Value, inPackage, year);
                return;
            }

            Bammer.Set(bammerTypeId.Value, inPackage, year);
        }
        else
        {
            if (Bammer?.Id > 0)
                Bammer = null;
        }
    }

    private void SetBaseballType(int? baseballTypeId, int? leaguePresidentId, int? year, string anniversary)
    {
        if (baseballTypeId.HasValue)
        {
            if (Brand.BrandId != Constants.Brand.Rawlings.Id)
                return;

            if (Baseball == null)
            {
                Baseball = new MemorabiliaBaseball(Id, baseballTypeId.Value, leaguePresidentId, year, anniversary);
                return;
            }

            Baseball.Set(baseballTypeId.Value, leaguePresidentId, year, anniversary);
        }
        else
        {
            if (Baseball?.Id > 0)
                Baseball = null;
        }            
    }

    private void SetBasketballType(int? basketballTypeId)
    {
        if (basketballTypeId.HasValue)
        {
            if (Basketball == null)
            {
                Basketball = new MemorabiliaBasketball(Id, basketballTypeId.Value);
                return;
            }

            Basketball.Set(basketballTypeId.Value);
        }
        else
        {
            if (Basketball?.Id > 0)
                Basketball = null;
        }
    }

    private void SetBatType(int? batTypeId, int? colorId, int? length)
    {
        if (batTypeId.HasValue || colorId.HasValue || length.HasValue)
        {
            if (Bat == null)
            {
                Bat = new MemorabiliaBat(Id, batTypeId, colorId, length);
                return;
            }

            Bat.Set(batTypeId, colorId, length);
        }
        else
        {
            if (Bat?.Id > 0)
                Bat = null;
        }
    }

    private void SetBobblehead(int? year, bool hasBox)
    {
        if (Bobblehead == null)
        {
            Bobblehead = new MemorabiliaBobblehead(Id, year, hasBox);
            return;
        }

        Bobblehead.Set(year, hasBox);
    }

    private void SetBook(string edition, bool hardCover, string publisher, string title)
    {
        if (Book == null)
        {
            Book = new MemorabiliaBook(Id, edition, hardCover, publisher, title);
            return;
        }

        Book.Set(edition, hardCover, publisher, title);  
    }

    private void SetBrand(int brandId)
    {
        if (Brand == null)
        {
            Brand = new MemorabiliaBrand(Id, brandId);
            return;
        }

        Brand.Set(brandId);
    }

    private void SetCard(int orientationId, bool custom, bool licensed, int? year)
    {
        if (Card == null)
        {
            Card = new MemorabiliaCard(Id, orientationId, custom, licensed, year);
            return;
        }

        Card.Set(orientationId, custom, licensed, year);
    }

    private void SetCommissioner(int commissionerId)
    {
        if (commissionerId > 0)
        {
            if (Commissioner == null)
            {
                Commissioner = new MemorabiliaCommissioner(Id, commissionerId);
                return;
            }

            Commissioner.Set(commissionerId);
        }
        else
        {
            if (Commissioner?.Id > 0)
                Commissioner = null;
        }
    }

    private void SetFigureType(int? figureSpecialtyTypeId, int? figureTypeId, int? year)
    {
        if (figureSpecialtyTypeId.HasValue || figureTypeId.HasValue || year.HasValue)
        {
            if (Figure == null)
            {
                Figure = new MemorabiliaFigure(Id, figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
                return;
            }

            Figure.Set(figureSpecialtyTypeId.Value, figureTypeId.Value, year.Value);
        }
        else
        {
            if (Figure?.Id > 0)
                Figure = null;
        }
    }

    private void SetFirstDayCover(DateTime? date)
    {
        if (FirstDayCover == null)
        {
            FirstDayCover = new MemorabiliaFirstDayCover(Id, date);
            return;
        }

        FirstDayCover.Set(date);
    }

    private void SetFootballType(int? footballTypeId)
    {
        if (footballTypeId.HasValue)
        {
            if (Football == null)
            {
                Football = new MemorabiliaFootball(Id, footballTypeId.Value);
                return;
            }

            Football.Set(footballTypeId.Value);
        }
        else
        {
            if (Football?.Id > 0)
                Football = null;
        }
    }

    private void SetGame(int? gameStyleTypeId = null, int? personId = null, DateTime? gameDate = null)
    {
        if (gameStyleTypeId.HasValue)
        {
            if (ItemType.Id == Constants.ItemType.Jersey.Id && Jersey.JerseyQualityTypeId != Constants.JerseyQualityType.Authentic.Id)
                return;

            if (Game == null)
            {
                Game = new MemorabiliaGame(Id, gameStyleTypeId.Value, personId, gameDate);
                return;
            }

            Game.Set(gameStyleTypeId.Value, personId, gameDate);
        }
        else
        {
            if (Game?.Id > 0)
                Game = null;
        }
    }

    private void SetGloveType(int? gloveTypeId)
    {
        if (gloveTypeId.HasValue)
        {
            if (Glove == null)
            {
                Glove = new MemorabiliaGlove(Id, gloveTypeId.Value);
                return;
            }

            Glove.Set(gloveTypeId.Value);
        }
        else
        {
            if (Glove?.Id > 0)
                Glove = null;
        }
    }

    private void SetHelmet(int? helmetFinishId, int? helmetQualityTypeId, int? helmetTypeId, bool throwback)
    {
        if (Helmet == null)
        {
            Helmet = new MemorabiliaHelmet(Id, helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
            return;
        }

        Helmet.Set(helmetFinishId, helmetQualityTypeId, helmetTypeId, throwback);
    }

    private void SetJersey(int qualityTypeId, int styleTypeId, int typeId)
    {
        if (Jersey == null)
        {
            Jersey = new MemorabiliaJersey(Id, qualityTypeId, styleTypeId, typeId);
            return;
        }

        Jersey.Set(qualityTypeId, styleTypeId, typeId);
    }

    private void SetLevelType(int levelTypeId)
    {
        if (LevelType == null)
        {
            LevelType = new MemorabiliaLevelType(Id, levelTypeId);
            return;
        }

        LevelType.Set(levelTypeId);
    }

    private void SetMagazine(int orientationId, DateTime? date, bool framed, bool matted)
    {
        if (Magazine == null)
        {
            Magazine = new MemorabiliaMagazine(Id, orientationId, date, framed, matted);
            return;
        }

        Magazine.Set(orientationId, date, framed, matted);
    }

    private void SetPeople(params int[] personIds)
    {
        if (personIds == null || !personIds.Any())
            People = new List<MemorabiliaPerson>();

        People.RemoveAll(team => !personIds.Contains(team.PersonId));
        People.AddRange(personIds.Where(personId => !People.Select(person => person.PersonId).Contains(personId)).Select(personId => new MemorabiliaPerson(Id, personId)));
    }

    private void SetPicture(int orientationId, 
                            bool framed, 
                            bool matted,
                            bool stretched = false, 
                            int? photoTypeId = null)
    {
        if (Picture == null)
        {
            Picture = new MemorabiliaPicture(Id, orientationId, framed, matted, stretched, photoTypeId);
            return;
        }

        Picture.Set(orientationId, framed, matted, stretched, photoTypeId);
    }

    private void SetSize(int sizeId)
    {
        if (Size == null)
        {
            Size = new MemorabiliaSize(Id, sizeId);
            return;
        }

        Size.Set(sizeId);
    }

    private void SetSports(params int[] sportIds)
    {
        if (sportIds == null || !sportIds.Any())
            Sports = new List<MemorabiliaSport>();

        Sports.RemoveAll(sportId => !sportIds.Contains(sportId.SportId));
        Sports.AddRange(sportIds.Where(sportId => !Sports.Select(sport => sport.SportId).Contains(sportId)).Select(sportId => new MemorabiliaSport(Id, sportId)));
    }

    private void SetTeams(params int[] teamIds)
    {
        if (teamIds == null || !teamIds.Any())
            Teams = new List<MemorabiliaTeam>();

        Teams.RemoveAll(team => !teamIds.Contains(team.TeamId));
        Teams.AddRange(teamIds.Where(teamId => !Teams.Select(team => team.TeamId).Contains(teamId)).Select(teamId => new MemorabiliaTeam(Id, teamId)));
    }
}
