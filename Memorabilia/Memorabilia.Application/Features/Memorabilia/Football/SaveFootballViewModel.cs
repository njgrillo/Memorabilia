using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class SaveFootballViewModel : SaveItemViewModel
    {
        public SaveFootballViewModel() { }

        public SaveFootballViewModel(FootballViewModel viewModel)
        {            
            BrandId = viewModel.Brand.BrandId;
            CommissionerId = viewModel.Commissioner.CommissionerId;
            FootballTypeId = viewModel.Football?.FootballTypeId ?? 0;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        private int _gameStyleTypeId;

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public FootballType FootballType => FootballType.Find(FootballTypeId);

        public int FootballTypeId { get; set; }

        public FootballType[] FootballTypes { get; set; } = FootballType.All;

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

                FootballTypes = FootballType.GetAll(GameStyleType.Find(value));
            }
        }

        public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.Football);

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public override string ImagePath => "images/football.jpg";

        public override ItemType ItemType => ItemType.Football;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Football;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalFootballLeague;

        public SaveTeamViewModel Team { get; set; }
    }
}
