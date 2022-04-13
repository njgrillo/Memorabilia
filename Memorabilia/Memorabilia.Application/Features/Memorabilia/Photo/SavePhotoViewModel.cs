﻿using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Photo
{
    public class SavePhotoViewModel : SaveItemViewModel
    {
        public SavePhotoViewModel() { }

        public SavePhotoViewModel(PhotoViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            Framed = viewModel.Picture.Framed;
            Matted = viewModel.Picture.Matted;
            MemorabiliaId = viewModel.MemorabiliaId;
            OrientationId = viewModel.Picture.OrientationId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            PhotoTypeId = viewModel.Picture.PhotoTypeId;
            SizeId = viewModel.Size.SizeId;
            SportIds = viewModel.Sports.Select(sport => sport.SportId).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool Framed { get; set; }

        public override string ImagePath => "images/phototypes.jpg";

        public override ItemType ItemType => ItemType.Photo;       
        
        public bool Matted { get; set; }

        public int OrientationId { get; set; }

        public Orientation[] Orientations => Orientation.All;

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
        public int? PhotoTypeId { get; set; }

        public PhotoType[] PhotoTypes => PhotoType.All;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
