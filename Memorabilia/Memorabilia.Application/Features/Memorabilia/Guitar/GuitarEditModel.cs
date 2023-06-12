namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class GuitarEditModel : MemorabiliaItemEditModel
{
    public GuitarEditModel() 
    {
        BrandId = Constant.Brand.Fender.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public GuitarEditModel(GuitarModel model)
    {
        BrandId = model.Brand.BrandId;
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Guitar;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Guitar;
}
