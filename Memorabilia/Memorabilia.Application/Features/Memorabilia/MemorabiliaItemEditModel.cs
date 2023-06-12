namespace Memorabilia.Application.Features.Memorabilia;

public abstract class MemorabiliaItemEditModel : ItemEditModel
{
    public override string BackNavigationPath 
        => $"Memorabilia/{Constant.EditModeType.Update.Name}/{MemorabiliaId}";

    public int BrandId { get; set; }

    public virtual bool DisplayGameDate 
        => (GameStyleType?.IsGameWorthly() ?? false);

    public virtual bool DisplayGameStyleType { get; } 
        = true;

    public override Constant.EditModeType EditModeType 
        => MemorabiliaId > 0 
        ? Constant.EditModeType.Update 
        : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public DateTime? GameDate { get; set; }

    public Constant.GameStyleType GameStyleType 
        => Constant.GameStyleType.Find(GameStyleTypeId);

    private int _gameStyleTypeId 
        = Constant.GameStyleType.None.Id;
    public int GameStyleTypeId
    {
        get => _gameStyleTypeId;
        set
        {
            _gameStyleTypeId = value;

            if (!(GameStyleType?.IsGameWorthly() ?? false))
                GameDate = null;
        }
    }

    public int LevelTypeId { get; set; }

    public List<PersonEditModel> People { get; set; } 
        = new();

    public PersonEditModel Person { get; set; }

    public int SizeId { get; set; }

    public virtual Constant.Sport Sport 
        => Constant.Sport.Find(SportId);

    public int SportId { get; set; }

    public List<int> SportIds { get; set; } 
        = new();

    public virtual Constant.SportLeagueLevel SportLeagueLevel { get; }

    public TeamEditModel Team { get; set; }

    public List<TeamEditModel> Teams { get; set; } 
        = new();
}
