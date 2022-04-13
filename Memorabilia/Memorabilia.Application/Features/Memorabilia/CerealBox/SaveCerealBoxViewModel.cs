using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox
{
    public class SaveCerealBoxViewModel : SaveItemViewModel
    {
        public SaveCerealBoxViewModel() { }

        public SaveCerealBoxViewModel(CerealBoxViewModel viewModel)
        {
            BrandId = viewModel.Brand.BrandId;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SportIds = viewModel.Sports.Select(x => x.SportId).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public Brand Brand => Brand.Find(BrandId);

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public override string ImagePath => "images/cerealbox.jpg";

        public override ItemType ItemType => ItemType.CerealBox;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.CerealBox.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
