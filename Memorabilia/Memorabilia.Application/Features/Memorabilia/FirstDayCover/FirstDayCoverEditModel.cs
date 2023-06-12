namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class FirstDayCoverEditModel : MemorabiliaItemEditModel
{
    public FirstDayCoverEditModel()
    { 
        SizeId = Constant.Size.Standard.Id;
    }

    public FirstDayCoverEditModel(FirstDayCoverModel model)
    {
        MemorabiliaId = model.MemorabiliaId;
        Date = model.FirstDayCover?.Date;

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
    }

    public DateTime? Date { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.FirstDayCover;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.FirstDayCover;
}
