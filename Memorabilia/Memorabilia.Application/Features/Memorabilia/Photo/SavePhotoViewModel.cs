using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Sport;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Photo
{
    public class SavePhotoViewModel : SaveViewModel
    {
        public SavePhotoViewModel() { }

        public SavePhotoViewModel(PhotoViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            Framed = viewModel.Photo.Framed;
            MemorabiliaId = viewModel.MemorabiliaId;
            OrientationId = viewModel.Orientation.Id;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            PhotoTypeId = viewModel.Photo.PhotoTypeId;
            SizeId = viewModel.Size.SizeId;
            Sports = viewModel.Sports.Select(sport => new SaveSportViewModel(new SportViewModel(sport.Sport))).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool Framed { get; set; }

        public bool HasPerson => People.Any();

        public bool HasSport => Sports.Any();

        public bool HasTeam => Teams.Any();

        public ItemType ItemType => ItemType.Photo;        

        [Required]
        public int MemorabiliaId { get; set; }

        public int OrientationId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Photo.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Type is required.")]
        public int PhotoTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<SaveSportViewModel> Sports { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
