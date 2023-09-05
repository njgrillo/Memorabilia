namespace Memorabilia.Domain.Entities;

public partial class Memorabilia
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
        CollectionMemorabilias = memorabilia.CollectionMemorabilias;
        Commissioner = memorabilia.Commissioner;
        ConditionId = memorabilia.ConditionId;
        CreateDate = memorabilia.CreateDate;
        Denominator = memorabilia.Denominator;
        Figure = memorabilia.Figure;
        Football = memorabilia.Football;
        ForTrade = memorabilia.ForTrade;
        Framed = memorabilia.Framed;
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
                       Collection[] collections,
                       int? conditionId,
                       decimal? cost,
                       int? denominator,
                       decimal? estimatedValue,
                       bool forTrade,
                       bool framed,
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
        ForTrade = forTrade;
        Framed = framed;
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

        SetCollections(collections);
    }

    public void Set(DateTime? acquiredDate,
                    bool acquiredWithAutograph,
                    int acquisitionTypeId,
                    Collection[] collections,
                    int? conditionId,
                    decimal? cost,
                    int? denominator,
                    decimal? estimatedValue,
                    bool forTrade,
                    bool framed,
                    string note,
                    int? numerator,
                    int privacyTypeId,
                    int? purchaseTypeId)
    {
        ConditionId = conditionId;
        Denominator = denominator;
        EstimatedValue = estimatedValue;
        ForTrade = forTrade;
        Framed = framed;
        LastModifiedDate = DateTime.UtcNow;
        Numerator = numerator;
        Note = note;
        PrivacyTypeId = privacyTypeId;

        MemorabiliaAcquisition.Set(acquisitionTypeId, acquiredDate, acquiredWithAutograph, cost, purchaseTypeId);

        SetCollections(collections);
    }    

    public void SetForSale(decimal? buyNowPrice, bool allowBestOffer, decimal? minimumOfferPrice)
    {
        if (ForSale == null)
        {
            ForSale = new MemorabiliaForSale(Id, buyNowPrice, allowBestOffer, minimumOfferPrice);
            return;
        }

        ForSale.Set(buyNowPrice, allowBestOffer, minimumOfferPrice);
    }

    public void SetForTrade(bool forTrade)
    {
        ForTrade = forTrade;
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
           
    private void SetBrand(int brandId)
    {
        if (Brand == null)
        {
            Brand = new MemorabiliaBrand(Id, brandId);
            return;
        }

        Brand.Set(brandId);
    }

    private void SetCollections(Collection[] collections)
    {
        if (!collections.Any())
        {
            CollectionMemorabilias = new List<CollectionMemorabilia>();
            return;
        }

        CollectionMemorabilias 
            = collections.Select(collection =>
                                    new CollectionMemorabilia(collection.Id, Id)).ToList();
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

    private void SetGame(int? gameStyleTypeId = null, int? personId = null, DateTime? gameDate = null)
    {
        if (gameStyleTypeId.HasValue)
        {
            if (ItemType.Id == Constant.ItemType.Jersey.Id && Jersey.JerseyQualityTypeId != Constants.JerseyQualityType.Authentic.Id)
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
    
    private void SetPeople(params int[] personIds)
    {
        if (personIds == null || !personIds.Any())
        {
            People = new List<MemorabiliaPerson>();
            return;
        }            

        People.RemoveAll(team => !personIds.Contains(team.PersonId));
        People.AddRange(personIds.Where(personId => !People.Select(person => person.PersonId).Contains(personId)).Select(personId => new MemorabiliaPerson(Id, personId)));
    }

    private void SetPicture(int orientationId,
                            bool matted,
                            bool stretched = false,
                            int? photoTypeId = null)
    {
        if (Picture == null)
        {
            Picture = new MemorabiliaPicture(Id, orientationId, matted, stretched, photoTypeId);
            return;
        }

        Picture.Set(orientationId, matted, stretched, photoTypeId);
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
