using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class SaveCerealBoxViewModel : SaveItemViewModel
{
    public SaveCerealBoxViewModel() { }

    public SaveCerealBoxViewModel(CerealBoxViewModel viewModel)
    {
        BrandId = viewModel.Brand.BrandId;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public Brand Brand => Brand.Find(BrandId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.None.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImagePath => Domain.Constants.ImagePath.CerealBox;

    public override ItemType ItemType => ItemType.CerealBox;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;
   
    public List<SavePersonViewModel> People { get; set; } = new();

    public List<int> SportIds { get; set; } = new();

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}
