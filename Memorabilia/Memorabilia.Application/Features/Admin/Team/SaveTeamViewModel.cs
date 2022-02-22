using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Team
{
    public class SaveTeamViewModel : SaveViewModel
    {
        public SaveTeamViewModel() { }

        public SaveTeamViewModel(TeamViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            BeginYear = viewModel.BeginYear;
            EndYear = viewModel.EndYear;
            FranchiseId = viewModel.FranchiseId;
            Id = viewModel.Id;
            ImagePath = viewModel.ImagePath;
            Location = viewModel.Location;
            Name = viewModel.Name;
            Nickname = viewModel.Nickname;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        public int? BeginYear { get; set; }

        public int? EndYear { get; set; }

        [Required]
        public int FranchiseId { get; set; }

        [StringLength(200, ErrorMessage = "Image Path is too long.")]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Location { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Nickname is too long.")]
        public string Nickname { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Team";

        public int SportLeagueLevelId { get; set; }
    }
}
