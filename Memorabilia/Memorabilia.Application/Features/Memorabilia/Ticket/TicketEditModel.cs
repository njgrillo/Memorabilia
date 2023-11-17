namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public class TicketEditModel : MemorabiliaItemEditModel
{
    public TicketEditModel() 
    {
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public TicketEditModel(TicketModel model)
    {
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        if (model.People.Any())
            Person = new PersonModel(model.People.First().Person);

        SportId = model.Sports
                       .Select(sport => sport.SportId)
                       .FirstOrDefault();

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();        
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Ticket;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Ticket;
}
