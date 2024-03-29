﻿using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();

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

        public bool HasPerson => Person?.Id > 0;

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Team?.Id > 0;

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

        public List<int> SportIds { get; set; } = new();

        public SportLeagueLevel SportLeagueLevel => SportLeagueLevel.NationalHockeyLeague;

        public SaveTeamViewModel Team { get; set; } 
    }
}
