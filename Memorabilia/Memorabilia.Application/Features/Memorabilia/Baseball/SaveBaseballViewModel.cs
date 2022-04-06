using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
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

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        private int _gameStyleTypeId;

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [StringLength(5, ErrorMessage = "Anniversary is too long.")]
        public string BaseballTypeAnniversary { get; set; }

        public BaseballType BaseballType => BaseballType.Find(BaseballTypeId);

        public int BaseballTypeId { get; set; }

        public BaseballType[] BaseballTypes { get; set; } = BaseballType.All;

        public int? BaseballTypeYear { get; set; }

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }  
        
        public int CommissionerId { get; set; }

        public bool DisplayBaseballType => BrandId == Brand.Rawlings.Id &&
                                           LevelTypeId == LevelType.Professional.Id &&
                                           SizeId == Size.Standard.Id;

        public bool DisplayBaseballTypeAnniversary => DisplayBaseballType && BaseballType.CanHaveAnniversary(BaseballType);

        public bool DisplayBaseballTypeYear => DisplayBaseballType && BaseballType.CanHaveYear(BaseballType);

        public bool DisplayGameDate => BaseballType.IsGameWorthly(BaseballType) && GameStyleType.IsGameWorthly(GameStyleType);

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

                if (GameStyleType.IsGameWorthly(GameStyleType))
                    BaseballTypeId = Brand == Brand.Rawlings ? BaseballType.Official.Id : 0;                
            }
        }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

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
        public int LevelTypeId { get; set; }

        public SavePersonViewModel Person { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Baseball;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public SaveTeamViewModel Team { get; set; } 
    }
}
