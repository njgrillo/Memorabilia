using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Sports;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Lithograph
{
    public class SaveLithographViewModel : SaveItemViewModel
    {
        public SaveLithographViewModel() { }

        public SaveLithographViewModel(LithographViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            Framed = viewModel.Lithograph.Framed;
            Matted = viewModel.Lithograph.Matted;
            MemorabiliaId = viewModel.MemorabiliaId;
            OrientationId = viewModel.Orientation.OrientationId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            Sports = viewModel.Sports.Select(sport => new SaveSportViewModel(new SportViewModel(sport.Sport))).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool Framed { get; set; }

        public bool HasPerson => People.Any();

        public bool HasSport => Sports.Any();

        public bool HasTeam => Teams.Any();

        public override string ImagePath => "images/lithograph.jpg";

        public override ItemType ItemType => ItemType.Lithograph;

        public bool Matted { get; set; }

        public int OrientationId { get; set; }

        public Orientation[] Orientations => Orientation.All;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.Lithograph.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<SaveSportViewModel> Sports { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
