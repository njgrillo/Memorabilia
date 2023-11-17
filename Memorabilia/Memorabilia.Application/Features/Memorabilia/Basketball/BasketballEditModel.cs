namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class BasketballEditModel : MemorabiliaItemEditModel
{
    public BasketballEditModel() 
    { 
        BrandId = Constant.Brand.Spalding.Id;
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Full.Id;
    }

    public BasketballEditModel(BasketballModel model)
    {
        BasketballTypeId = model.Basketball?.BasketballTypeId ?? 0;
        BrandId = model.Brand.BrandId;
        CommissionerId = model.Commissioner?.CommissionerId ?? 0;
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Count != 0)
            Person = new PersonModel(model.People.First().Person);

        if (model.Teams.Count != 0)
            Team = model.Teams.First().Team.ToEditModel();
    }

    public int BasketballTypeId { get; set; } 
        = Constant.BasketballType.Official.Id;

    public int CommissionerId { get; set; }

    public override bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Full.Id;

    public override string ImageFileName 
        => Constant.ImageFileName.Basketball;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Basketball;

    public override Constant.Sport Sport 
        => Constant.Sport.Basketball;

    public override Constant.SportLeagueLevel SportLeagueLevel 
        => Constant.SportLeagueLevel.NationalBasketballAssociation;
}
