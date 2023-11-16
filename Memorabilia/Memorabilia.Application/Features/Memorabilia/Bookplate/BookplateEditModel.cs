namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class BookplateEditModel : MemorabiliaItemEditModel
{
    public BookplateEditModel() { }

    public BookplateEditModel(BookplateModel model)
    {
        MemorabiliaId = model.MemorabiliaId;

        if (model.People.Any())
            Person = model.People
                          .First()
                          .Person
                          .ToEditModel();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Bookplate;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Bookplate;
}
