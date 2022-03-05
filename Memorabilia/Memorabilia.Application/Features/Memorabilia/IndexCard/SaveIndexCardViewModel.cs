using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard
{
    public class SaveIndexCardViewModel : SaveViewModel
    {
        public SaveIndexCardViewModel() { }

        public SaveIndexCardViewModel(IndexCardViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            SizeId = viewModel.Size.SizeId;
        }

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayIndexCardType && IndexCardType != null)
                //{
                //    return $"{path}{IndexCardType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}IndexCard.jpg";
            }
        }

        public ItemType ItemType => ItemType.IndexCard;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.IndexCard.Name} Details";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }
    }
}
