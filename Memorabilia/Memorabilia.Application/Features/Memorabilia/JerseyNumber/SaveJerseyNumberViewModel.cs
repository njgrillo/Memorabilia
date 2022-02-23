using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber
{
    public class SaveJerseyNumberViewModel : SaveViewModel
    {
        public SaveJerseyNumberViewModel() { }

        public SaveJerseyNumberViewModel(JerseyNumberViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Teams.Any();

        public ItemType ItemType => ItemType.JerseyNumber;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.JerseyNumber.Name} Details";

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
