using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
            FullName = viewModel.FullName;
            Id = viewModel.Id;
            ImagePath = viewModel.ImagePath;
            LastName = viewModel.LastName;
            Nickname = viewModel.Nickname;
            Occupations = viewModel.Occupations.Select(occupation => new SavePersonOccupationViewModel(occupation)).ToList();
            Suffix = viewModel.Suffix;   
            Teams = viewModel.Teams.Select(team => new SavePersonTeamViewModel(team)).ToList();
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

        public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Person";

        [StringLength(25, ErrorMessage = "Suffix is too long.")]
        public string Suffix { get; set; }

        public List<SavePersonTeamViewModel> Teams { get; set; } = new();
    }
}
