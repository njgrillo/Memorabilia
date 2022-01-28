using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Person
{
    public class SavePersonViewModel : SaveViewModel
    {
        public SavePersonViewModel() { }

        public SavePersonViewModel(PersonViewModel viewModel)
        {
            BirthDate = viewModel.BirthDate;
            DeathDate = viewModel.DeathDate;
            FirstName = viewModel.FirstName;
            Id = viewModel.Id;
            ImagePath = viewModel.ImagePath;
            LastName = viewModel.LastName;
            Suffix = viewModel.Suffix;
            Nickname = viewModel.Nickname;
            FullName = viewModel.FullName;
        }

        public DateTime? BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First Name is too long.")]
        [MinLength(1, ErrorMessage = "First Name is too short.")]
        public string FirstName { get; set; }

        [StringLength(125, ErrorMessage = "Full Name is too long.")]
        public string FullName { get; set; }

        [StringLength(200, ErrorMessage = "Image Path is too long.")]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name is too long.")]
        [MinLength(1, ErrorMessage = "Last Name is too short.")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Nickname is too long.")]
        public string Nickname { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Person";

        [StringLength(25, ErrorMessage = "Suffix is too long.")]
        public string Suffix { get; set; }
    }
}
