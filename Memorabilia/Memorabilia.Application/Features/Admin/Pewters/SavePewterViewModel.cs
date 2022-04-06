using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Memorabilia.Application.Features.Admin.Pewters
{
    public class SavePewterViewModel : SaveViewModel
    {
        public SavePewterViewModel() { }

        public SavePewterViewModel(PewterViewModel viewModel)
        {
            FranchiseId = viewModel.FranchiseId;
            Id = viewModel.Id;
            ImagePath = viewModel.ImagePath;
            SizeId = viewModel.SizeId;
            TeamId = viewModel.TeamId;
        }

        public override string ExitNavigationPath => "Pewters";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Franchise is required.")]
        public int FranchiseId { get; set; }

        public Domain.Constants.Franchise[] Franchises => Domain.Constants.Franchise.GetFranchises(SportLeagueLevel);

        [Required]
        public string ImagePath { get; set; } 

        public override string ItemTitle => "Pewter";

        public string PageImagePath => "images/pewters.jpg";

        public override string PageTitle => $"{(EditModeType == Domain.Constants.EditModeType.Update ? "Edit " : "Add ")} Pewter";

        public override string RoutePrefix => "Pewters";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public Domain.Constants.SportLeagueLevel SportLeagueLevel => Domain.Constants.SportLeagueLevel.NationalFootballLeague;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Team is required.")]
        public int TeamId { get; set; }
    }
}
