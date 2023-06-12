namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class PlayingCardEditModel : MemorabiliaItemEditModel
{
    public PlayingCardEditModel()
    {
        SizeId = Constant.Size.Standard.Id;
    }

    public PlayingCardEditModel(PlayingCardModel model)
    {
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        SportId = model.Sports
                       .Select(sport => sport.SportId)
                       .FirstOrDefault(); 

        if (model.People.Any())
            Person = model.People.First().Person.ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams.First().Team.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.PlayingCard;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.PlayingCard;
}
