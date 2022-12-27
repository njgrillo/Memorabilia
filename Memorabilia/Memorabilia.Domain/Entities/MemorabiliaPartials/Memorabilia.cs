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
