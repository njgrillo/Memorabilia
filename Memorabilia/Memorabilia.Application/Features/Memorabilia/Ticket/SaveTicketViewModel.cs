using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Ticket
{
    public class SaveTicketViewModel : SaveItemViewModel
    {
        public SaveTicketViewModel() { }

        public SaveTicketViewModel(TicketViewModel viewModel)
        {
            GameDate = viewModel.Game?.GameDate;
            GamePersonId = viewModel.Game?.PersonId ?? 0;
            GameStyleTypeId = viewModel.Game?.GameStyleTypeId ?? 0;
            LevelTypeId = viewModel.Level.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;
            SportId = viewModel.Sports.Select(sport => sport.SportId).FirstOrDefault();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public bool DisplayGameDate => GameStyleType == GameStyleType.GameUsed;

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public DateTime? GameDate { get; set; }

        public int GamePersonId { get; set; }

        public GameStyleType GameStyleType => GameStyleType.Find(GameStyleTypeId);

        public int GameStyleTypeId { get; set; }

        public override string ImagePath => "images/ticket.jpg";

        public override ItemType ItemType => ItemType.Ticket;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.Ticket.Name} Details";

        public SavePersonViewModel Person { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public int SportId { get; set; } 

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
