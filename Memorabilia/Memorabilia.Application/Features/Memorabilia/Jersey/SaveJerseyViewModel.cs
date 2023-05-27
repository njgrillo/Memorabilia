using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Jersey;

public class SaveJerseyViewModel : MemorabiliaItemEditViewModel
{
    public SaveJerseyViewModel() 
    { 
        GameStyleTypeId = GameStyleType.None.Id;
        LevelTypeId = LevelType.Professional.Id;
    }

    public SaveJerseyViewModel(JerseyViewModel viewModel)
    {            
        BrandId = viewModel.Brand.BrandId;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        JerseyQualityTypeId = viewModel.Jersey.JerseyQualityTypeId;
        JerseyStyleTypeId = viewModel.Jersey.JerseyStyleTypeId;
        JerseyTypeId = viewModel.Jersey.JerseyTypeId;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SizeId = viewModel.Size.SizeId;
        SportId = viewModel.Sports.Select(x => x.SportId).FirstOrDefault();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override bool DisplayGameDate 
        => DisplayGameStyleType && 
           IsGameWorthly;

    public override bool DisplayGameStyleType 
        => JerseyQualityTypeId == JerseyQualityType.Authentic.Id;

    public override string ImageFileName 
        => Domain.Constants.ImageFileName.ItemTypes;

    public bool IsGameWorthly
        => (GameStyleType?.IsGameWorthly() ?? false);

    public override ItemType ItemType 
        => ItemType.Jersey;

    public int JerseyQualityTypeId { get; set; }

    public int JerseyStyleTypeId { get; set; }

    public int JerseyTypeId { get; set; } 
        = JerseyType.Stitched.Id;
}
