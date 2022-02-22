using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.League
{
    public class SaveLeagueViewModel : SaveViewModel
    {
        public SaveLeagueViewModel() { }

        public SaveLeagueViewModel(LeagueViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;
            SportLeagueLevelId = viewModel.SportLeagueLevelId;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} League";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sport League Level is required.")]
        public int SportLeagueLevelId { get; set; }
    }
}
