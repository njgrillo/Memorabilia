namespace Memorabilia.Application.Features.Memorabilia.Card;

public class CardEditModel : MemorabiliaItemEditModel
{
    public CardEditModel() 
    {
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public CardEditModel(CardModel model)
    {
        BrandId = model.Brand.BrandId;
        Custom = model.Card.Custom;
        LevelTypeId = model.Level.LevelTypeId;
        Licensed = model.Card.Licensed;
        MemorabiliaId = model.MemorabiliaId;
        OrientationId = model.Card.OrientationId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        SportIds = model.Sports
                        .Select(x => x.SportId)
                        .ToList();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();

        Year = model.Card.Year;
    }

    public bool Custom { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.TradingCard;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.TradingCard;

    public bool Licensed { get; set; }

    public int OrientationId { get; set; }

    public int? Year { get; set; }
}
