using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard
{
    public class SaveIndexCardViewModel : SaveItemViewModel
    {
        public SaveIndexCardViewModel() { }

        public SaveIndexCardViewModel(IndexCardViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public override string ImagePath => "images/indexcard.jpg";

        public override ItemType ItemType => ItemType.IndexCard;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.IndexCard.Name} Details";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }
    }
}
