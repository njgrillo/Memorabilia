using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin
{
    public class SaveDomainViewModel : SaveViewModel
    {
        public SaveDomainViewModel() { }

        public SaveDomainViewModel(DomainViewModel viewModel)
        {
            Abbreviation = viewModel.Abbreviation;
            Id = viewModel.Id;
            Name = viewModel.Name;
        }

        public string Abbreviation { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        [MinLength(1, ErrorMessage = "Name is too short.")]
        public string Name { get; set; }

        //public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Bill";
    }
}
