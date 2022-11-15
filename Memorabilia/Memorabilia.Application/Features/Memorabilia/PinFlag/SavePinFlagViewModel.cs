using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class SavePinFlagViewModel : SaveItemViewModel
{
    public SavePinFlagViewModel() { }

    public SavePinFlagViewModel(PinFlagViewModel viewModel)
    {
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        MemorabiliaId = viewModel.MemorabiliaId;            

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Tournament Style Type is required.")]
    public int GameStyleTypeId { get; set; } = GameStyleType.None.Id;

    public override string ImageFileName => Domain.Constants.ImageFileName.PinFlag;

    public override ItemType ItemType => ItemType.PinFlag;

    public SavePersonViewModel Person { get; set; }
}
