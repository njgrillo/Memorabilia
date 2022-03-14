using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.SportLeagueLevel
{
    public class SaveSportLeagueLevelViewModel : SaveViewModel
    {
        public SaveSportLeagueLevelViewModel() { }

        public SaveSportLeagueLevelViewModel(SportLeagueLevelViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            LevelTypeId = viewModel.LevelTypeId;
            Name = viewModel.Name;            
            SportId = viewModel.SportId;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        public override string ItemTitle => "Sport League Level";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Sport League Level";

        public override string RoutePrefix => "SportLeagueLevels";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
        public int SportId { get; set; }
    }
}
