using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class SaveBasketballViewModel : SaveViewModel
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

            if (!viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public BasketballType BasketballType => BasketballType.Find(BasketballTypeId);

        public int BasketballTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int CommissionerId { get; set; }

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayBasketballType && BasketballType != null)
                //{
                //    return $"{path}{BasketballType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}basketball.jpg";
            }
        }

        public ItemType ItemType => ItemType.Basketball;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Basketball.Name} Details";

        public SavePersonViewModel Person;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalBasketballAssociation;

        public SaveTeamViewModel Team { get; set; }
    }
}
