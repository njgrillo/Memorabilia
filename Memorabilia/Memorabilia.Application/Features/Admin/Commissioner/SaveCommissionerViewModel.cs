using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class SaveCommissionerViewModel : SaveViewModel
    {
        public SaveCommissionerViewModel() { }

        public SaveCommissionerViewModel(CommissionerViewModel viewModel)
        {
            BeginYear = viewModel.BeginYear;
            EndYear = viewModel.EndYear;
            Id = viewModel.Id;
            PersonId = viewModel.PersonId;
            SportId = viewModel.SportId;
        }

        public int? BeginYear { get; set; }

        public int? EndYear { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Commissioner";

        [Required]
        public int PersonId { get; set; }

        [Required]
        public int SportId { get; set; }
    }
}
