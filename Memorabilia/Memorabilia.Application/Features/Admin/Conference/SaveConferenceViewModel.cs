using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Conference
{
    public class SaveConferenceViewModel : SaveViewModel
    {
        public SaveConferenceViewModel() { }

        public SaveConferenceViewModel(ConferenceViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;
            SportId = viewModel.SportId;
        }

        [StringLength(10, ErrorMessage = "Abbreviation is too long.")]
        public string Abbreviation { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Conference";

        [Required]
        [MinLength(1, ErrorMessage = "Sport is required.")]
        public int SportId { get; set; }
    }
}
