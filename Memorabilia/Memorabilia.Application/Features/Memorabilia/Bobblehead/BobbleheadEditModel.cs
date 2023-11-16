namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class BobbleheadEditModel : MemorabiliaItemEditModel
{
    public BobbleheadEditModel()
    {
        BrandId = Constant.Brand.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public BobbleheadEditModel(BobbleheadModel model)
    {
        BrandId = model.Brand.BrandId;
        HasBox = model.Bobblehead?.HasBox ?? false;
        LevelTypeId = model.Level.LevelTypeId;
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;

        SportId = model.Sports
                       .Select(x => x.SportId)
                       .FirstOrDefault();

        Year = model.Bobblehead?.Year;

        if (model.People.Any())
            Person = model.People
                          .First()
                          .Person
                          .ToEditModel();

        if (model.Teams.Any())
            Team = model.Teams
                        .First()
                        .Team
                        .ToEditModel();
    }

    public bool HasBox { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Bobblehead;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Bobble;   

    public int? Year { get; set; }
}
