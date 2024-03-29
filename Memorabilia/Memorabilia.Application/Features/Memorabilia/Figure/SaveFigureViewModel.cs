﻿using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Figure
{
    public class SaveFigureViewModel : SaveItemViewModel
    {
        public SaveFigureViewModel() { }

        public SaveFigureViewModel(FigureViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            FigureSpecialtyTypeId = viewModel.Figure?.FigureSpecialtyTypeId ?? 0;
            FigureTypeId = viewModel.Figure?.FigureTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
            Year = viewModel.Figure?.Year;
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public int FigureSpecialtyTypeId { get; set; }

        public int FigureTypeId { get; set; }

        public FigureType[] FigureTypes => FigureType.All;

        public bool HasPerson => People.Any();

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Teams.Any();

        public override string ImagePath => "images/figure.jpg";

        public override ItemType ItemType => ItemType.Figure;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();

        public int? Year { get; set; }
    }
}
