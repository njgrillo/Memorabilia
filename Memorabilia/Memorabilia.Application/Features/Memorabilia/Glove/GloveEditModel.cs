namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class GloveEditModel : MemorabiliaItemEditModel
{
    public GloveEditModel() 
    { 
        GameStyleTypeId = Constant.GameStyleType.None.Id;
        LevelTypeId = Constant.LevelType.Professional.Id;
        SizeId = Constant.Size.Standard.Id;
    }

    public GloveEditModel(GloveModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        GloveTypeId = viewModel.Glove?.GloveTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;

        People = viewModel.People
                          .Select(person => person.Person.ToEditModel())
                          .ToList();

        SizeId = viewModel.Size.SizeId;

        SportId = viewModel.Sports
                           .Select(x => x.SportId)
                           .FirstOrDefault();

        Teams = viewModel.Teams
                         .Select(team => team.Team.ToEditModel())
                         .ToList();
    }

    public override bool DisplayGameDate
        => (GameStyleType?.IsGameWorthly() ?? false) && 
           DisplayGameStyleType;

    public override bool DisplayGameStyleType 
        => SizeId == Constant.Size.Standard.Id;

    public int GloveTypeId { get; set; }

    public override string ImageFileName 
        => Constant.ImageFileName.Glove;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.Glove;
}
