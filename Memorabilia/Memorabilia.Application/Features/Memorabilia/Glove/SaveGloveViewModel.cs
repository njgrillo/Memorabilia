using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class SaveGloveViewModel : MemorabiliaItemEditViewModel
{
    public SaveGloveViewModel() 
    { 
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
        SizeId = Size.Standard.Id;
    }

    public SaveGloveViewModel(GloveViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        GloveTypeId = viewModel.Glove?.GloveTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType) && DisplayGameStyleType;

    public override bool DisplayGameStyleType => SizeId == Size.Standard.Id;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Glove Type is required.")]
    public int GloveTypeId { get; set; }

    public override string ImageFileName => Domain.Constants.ImageFileName.Glove;

    public override ItemType ItemType => ItemType.Glove;
}
