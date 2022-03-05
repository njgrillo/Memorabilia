using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox
{
    public class SaveCerealBoxViewModel : SaveViewModel
    {
        public SaveCerealBoxViewModel() { }

        public SaveCerealBoxViewModel(CerealBoxViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayCerealBoxType && CerealBoxType != null)
                //{
                //    return $"{path}{CerealBoxType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}CerealBox.jpg";
            }
        }

        public ItemType ItemType => ItemType.CerealBox;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.CerealBox.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
