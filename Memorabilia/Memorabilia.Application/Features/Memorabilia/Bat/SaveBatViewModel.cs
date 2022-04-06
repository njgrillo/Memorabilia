using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bat
{
    public class SaveBatViewModel : SaveItemViewModel
    {
        public SaveBatViewModel() { }

        public SaveBatViewModel(BatViewModel viewModel)
        {
            BatTypeId = viewModel.Bat?.BatTypeId ?? 0;
            BrandId = viewModel.Brand.BrandId;
            ColorId = viewModel.Bat?.ColorId ?? 0;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            Length = viewModel.Bat?.Length ?? 0;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public BatType BatType => BatType.Find(BatTypeId);

        public int BatTypeId { get; set; }

        public BatType[] BatTypes => BatType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public Color[] Colors => Color.GetAll(ItemType);

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.Baseball);

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public override string ImagePath => "images/bat.jpg";

        public override ItemType ItemType => ItemType.Bat;

        public int? Length { get; set; }

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Baseball;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.MajorLeagueBaseball;

        public SaveTeamViewModel Team { get; set; }
    }
}
