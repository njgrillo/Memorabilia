namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class PinFlagEditModel : MemorabiliaItemEditModel
{
    public PinFlagEditModel() 
    {
        GameStyleTypeId = Constant.GameStyleType.None.Id;
    }

    public PinFlagEditModel(PinFlagModel model)
    {
        GameDate = model.Game?.GameDate;
        GameStyleTypeId = model.Game?.GameStyleTypeId ?? 0;
        MemorabiliaId = model.MemorabiliaId;            

        if (model.People.Any())
            Person = model.People.First().Person.ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.PinFlag;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.PinFlag;

    public override Constant.Sport Sport
        => Constant.Sport.Golf;
}
