using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public abstract class MemorabiliaItemEditViewModel : SaveItemViewModel
{
    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public int BrandId { get; set; }

    public virtual bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

    public virtual bool DisplayGameStyleType { get; } = true;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

    private int _gameStyleTypeId = GameStyleType.None.Id;
    public int GameStyleTypeId
    {
        get => _gameStyleTypeId;
        set
        {
            _gameStyleTypeId = value;

            if (!GameStyleType.IsGameWorthly(GameStyleType))
                GameDate = null;
        }
    }

    public int LevelTypeId { get; set; }

    public List<SavePersonViewModel> People { get; set; } = new();

    public SavePersonViewModel Person { get; set; }

    public int SizeId { get; set; }

    public virtual Sport Sport => Sport.Find(SportId);

    public int SportId { get; set; }

    public List<int> SportIds { get; set; } = new();

    public virtual SportLeagueLevel SportLeagueLevel { get; }

    public SaveTeamViewModel Team { get; set; }

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}
