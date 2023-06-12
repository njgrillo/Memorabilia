namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class CompactDiscEditModel : MemorabiliaItemEditModel
{
    public CompactDiscEditModel() { }

    public CompactDiscEditModel(CompactDiscModel model)
    {
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.CompactDisc;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.CompactDisc;
}
