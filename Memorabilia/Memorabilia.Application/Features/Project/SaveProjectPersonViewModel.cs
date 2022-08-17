using Memorabilia.Application.Features.Admin.People;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Project
{
    public class SaveProjectPersonViewModel : SaveViewModel
    {
        public SaveProjectPersonViewModel() { }

        public SaveProjectPersonViewModel(ProjectPersonViewModel viewModel)
        {            
            Id = viewModel.Id;
            ItemTypeId = viewModel.ItemTypeId ?? 0;
            Rank = viewModel.Rank;
            Upgrade = viewModel.Upgrade;
            PriorityTypeId = viewModel.PriorityTypeId ?? 0;
            Person =  new SavePersonViewModel(new PersonViewModel(viewModel.Person));
        }

        public bool Deceased => Person?.DeathDate.HasValue ?? false;

        public bool DisplayDoubleUpIcon => Rank > 1;

        public bool DisplayUpIcon => Rank > 1;

        public string DoubleDownIcon => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowDown;

        public string DoubleUpIcon => MudBlazor.Icons.Material.Filled.KeyboardDoubleArrowUp;

        public string DownIcon => MudBlazor.Icons.Material.Filled.ArrowDownward;

        public int ItemTypeId { get; set; }

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId)?.Name;

        [Required]
        public SavePersonViewModel Person { get; set; } = new();              

        public int PriorityTypeId { get; set; }

        public string PriorityTypeName => Domain.Constants.PriorityType.Find(PriorityTypeId)?.Name;

        public int? Rank { get; set; }

        public string UpIcon => MudBlazor.Icons.Material.Filled.ArrowUpward;

        public bool Upgrade { get; set; }
    }
}
