using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class SaveBasketballViewModel : SaveItemViewModel
    {
        public SaveBasketballViewModel() { }

        public SaveBasketballViewModel(BasketballViewModel viewModel)
        {
            BasketballTypeId = viewModel.Basketball?.BasketballTypeId ?? 0;
            BrandId = viewModel.Brand.BrandId;
            CommissionerId = viewModel.Commissioner.CommissionerId;
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

        public BasketballType BasketballType => BasketballType.Find(BasketballTypeId);

        public int BasketballTypeId { get; set; }

        public BasketballType[] BasketballTypes { get; set; } = BasketballType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

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
                BasketballTypes = BasketballType.GetAll(GameStyleType.Find(value));              
            }
        }

        public override string ImagePath => "images/basketball.jpg";

        public override ItemType ItemType => ItemType.Basketball;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }        

        public SavePersonViewModel Person;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Basketball;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalBasketballAssociation;

        public SaveTeamViewModel Team { get; set; }
    }
}
