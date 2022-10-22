using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class SaveBaseballViewModel : SaveItemViewModel
{
    public SaveBaseballViewModel() { }

    public SaveBaseballViewModel(BaseballViewModel viewModel)
    {
        BaseballTypeAnniversary = viewModel.Baseball?.Anniversary;
        BaseballTypeId = viewModel.Baseball?.BaseballTypeId ?? 0;
        BaseballTypeYear = viewModel.Baseball?.Year;
        BrandId = viewModel.Brand.BrandId;
        CommissionerId = viewModel.Commissioner?.CommissionerId ?? 0;
        GameDate = viewModel.Game?.GameDate;
        GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
        LevelTypeId = viewModel.Level.LevelTypeId;
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
        Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();

        if (viewModel.People.Any())
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
    }

    private int _gameStyleTypeId;

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    [StringLength(5, ErrorMessage = "Anniversary is too long.")]
    public string BaseballTypeAnniversary { get; set; }

    public BaseballType BaseballType => BaseballType.Find(BaseballTypeId);

    public int BaseballTypeId { get; set; } = BaseballType.Official.Id;

    public BaseballType[] BaseballTypes { get; set; } = BaseballType.All;

    public int? BaseballTypeYear { get; set; }

    public Brand Brand => Brand.Find(BrandId);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
    public int BrandId { get; set; } = Brand.Rawlings.Id;

    public int CommissionerId { get; set; }

    public bool DisplayBaseballType => BrandId == Brand.Rawlings.Id &&
                                       LevelTypeId == LevelType.Professional.Id &&
                                       SizeId == Size.Standard.Id;

    public bool DisplayBaseballTypeAnniversary => DisplayBaseballType && BaseballType.CanHaveAnniversary(BaseballType);

    public bool DisplayBaseballTypeYear => DisplayBaseballType && BaseballType.CanHaveYear(BaseballType);

    public bool DisplayCommissioner => Brand.IsGameWorthlyBaseballBrand(Brand);

    public bool DisplayGameDate => Brand.IsGameWorthlyBaseballBrand(Brand) &&
                                   SizeId == Size.Standard.Id && 
                                   BaseballType.IsGameWorthly(BaseballType) && 
                                   GameStyleType.IsGameWorthly(GameStyleType);

    public bool DisplayGameStyleType => Brand.IsGameWorthlyBaseballBrand(Brand) &&
                                        SizeId == Size.Standard.Id;

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public DateTime? GameDate { get; set; }

    public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);        

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId
    {
        get
        {
            return _gameStyleTypeId;
        }
        set
        {
            _gameStyleTypeId = value;
            BaseballTypes = BaseballType.GetAll(GameStyleType.Find(value));               
        }
    }

    public override string ImagePath
    {
        get
        {
            var path = "images/";

            if (DisplayBaseballType && BaseballType != null)
            {
                return $"{path}{BaseballType.Name.Replace(" ", "")}.jpg";
            }

            return $"{path}baseball.jpg";
        }
    }

    public override ItemType ItemType => ItemType.Baseball;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
    public int LevelTypeId { get; set; } = LevelType.Professional.Id;

    public SavePersonViewModel Person { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.Standard.Id;

    public Sport Sport => Sport.Baseball;

    public List<SaveTeamViewModel> Teams { get; set; } = new();
}
