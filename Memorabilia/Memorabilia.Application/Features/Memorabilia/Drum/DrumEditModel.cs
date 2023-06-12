namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class DrumEditModel : MemorabiliaItemEditModel
{
    public DrumEditModel() 
    { 
        BrandId = Constant.Brand.Muslady.Id;
    }

    public DrumEditModel(DrumModel model)
    {
        BrandId = model.Brand.BrandId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Drum;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Drum;
}
