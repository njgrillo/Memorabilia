﻿using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.HeadBand
{
    public class SaveHeadBandViewModel : SaveItemViewModel
    {
        public SaveHeadBandViewModel() { }

        public SaveHeadBandViewModel(HeadBandViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            GameDate = viewModel.Game?.GameDate;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));

            if (viewModel.Teams.Any())
                Team = new SaveTeamViewModel(new TeamViewModel(viewModel.Teams.First().Team));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool DisplayGameDate => GameStyleType.IsGameWorthly(GameStyleType);

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
        public int GameStyleTypeId { get; set; }

        public bool HasPerson => Person?.Id > 0;

        public bool HasTeam => Team?.Id > 0;

        public override string ImagePath => "images/headband.jpg";

        public override ItemType ItemType => ItemType.HeadBand;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.HeadBand.Name} Details";

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public SaveTeamViewModel Team { get; set; }
    }
}
