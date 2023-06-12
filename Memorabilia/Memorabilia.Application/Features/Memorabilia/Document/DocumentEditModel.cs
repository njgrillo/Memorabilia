namespace Memorabilia.Application.Features.Memorabilia.Document;

public class DocumentEditModel : MemorabiliaItemEditModel
{
    public DocumentEditModel() { }

    public DocumentEditModel(DocumentModel model)
    {
        MemorabiliaId = model.MemorabiliaId;

        People = model.People
                      .Select(person => person.Person.ToEditModel())
                      .ToList();

        SizeId = model.Size.SizeId;

        Teams = model.Teams
                     .Select(team => team.Team.ToEditModel())
                     .ToList();
    }

    public override string ImageFileName 
        => Constant.ImageFileName.Document;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Document;
}
