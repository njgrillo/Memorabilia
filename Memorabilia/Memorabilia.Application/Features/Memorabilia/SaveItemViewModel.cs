using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class SaveItemViewModel : SaveViewModel
    {   
        public override string ContinueNavigationPath => $"Memorabilia/Image/Edit/{MemorabiliaId}";       

        public virtual string ImagePath { get; set; }

        public virtual ItemType ItemType { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Detail;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType?.Name} Details";
    }
}
