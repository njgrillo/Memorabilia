﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.HockeyStick
{
    public class SaveHockeyStickViewModel : SaveItemViewModel
    {
        public SaveHockeyStickViewModel() { }

        public SaveHockeyStickViewModel(HockeyStickViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GamePersonId = viewModel.Game?.PersonId ?? 0;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

        public int GamePersonId { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        public int GameStyleTypeId { get; set; }

        public GameStyleType[] GameStyleTypes => GameStyleType.GetAll(ItemType.HockeyStick);

        public override string ImagePath => "images/hockeystick.jpg";

        public override ItemType ItemType => ItemType.HockeyStick;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public SavePersonViewModel Person { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Sport Sport => Sport.Hockey;

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalHockeyLeague;

        public SaveTeamViewModel Team { get; set; } 
    }
}
