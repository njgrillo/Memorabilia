using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class SaveMemorabiliaItemViewModel : SaveViewModel
    {
        public SaveMemorabiliaItemViewModel() { }

        public SaveMemorabiliaItemViewModel(MemorabiliaItemViewModel viewModel)
        { 
            ConditionId = viewModel.ConditionId;
            Cost = viewModel.Cost;
            CreateDate = viewModel.CreateDate;
            EstimatedValue = viewModel.EstimatedValue;
            Id = viewModel.Id;
            ImagePath = viewModel.ImagePath;
            ItemTypeId = viewModel.ItemTypeId;
            LastModifiedDate = viewModel.LastModifiedDate;
            UserId = viewModel.UserId;
        }

        public int? ConditionId { get; set; }

        public decimal? Cost { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? EstimatedValue { get; set; }

        [StringLength(500, ErrorMessage = "Image Path is too long.")]
        public string ImagePath { get; set; }

        [Required]
        public int ItemTypeId { get; set; }

        public string ItemTypeName => Domain.Constants.ItemType.Find(ItemTypeId)?.Name;

        public DateTime? LastModifiedDate { get; set; } 

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} {(ItemTypeId > 0 ? ItemTypeName : "Memorabilia")}";

        public int UserId { get; set; }
    }
}
