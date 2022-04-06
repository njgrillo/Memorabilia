using Framework.Extension;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class SaveMemorabiliaItemViewModel : SaveViewModel
    {
        public SaveMemorabiliaItemViewModel() { }

        public SaveMemorabiliaItemViewModel(MemorabiliaItemViewModel viewModel)
        {
            AcquiredDate = viewModel.Acquisition.AcquiredDate;
            AcquiredWithAutograph = viewModel.Acquisition.AcquiredWithAutograph ?? false;
            AcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
            ConditionId = viewModel.ConditionId ?? 0;
            Cost = viewModel.Acquisition.Cost;
            CreateDate = viewModel.CreateDate;
            EstimatedValue = viewModel.EstimatedValue;
            Id = viewModel.Id;
            PrivacyTypeId = viewModel.PrivacyTypeId;            
            PurchaseTypeId = viewModel.PurchaseTypeId ?? 0;
            ItemTypeId = viewModel.ItemTypeId;
            LastModifiedDate = viewModel.LastModifiedDate;
            UserId = viewModel.UserId;
        }

        public DateTime? AcquiredDate { get; set; }

        public bool AcquiredWithAutograph { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Acquisition Type is required.")]
        public int AcquisitionTypeId { get; set; }

        public AcquisitionType[] AcquisitionTypes => AcquisitionType.MemorabiliaAcquisitionTypes;

        public bool CanHaveCost => AcquisitionType.CanHaveCost(AcquisitionType.Find(AcquisitionTypeId));

        public int ConditionId { get; set; }

        public Condition[] Conditions => Condition.All;

        public decimal? Cost { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? EstimatedValue { get; set; }

        public override string ExitNavigationPath => "Memorabilia/Items";

        public string ImagePath => $"images/{(!ItemTypeName.IsNullOrEmpty() ? ItemTypeName + ".jpg" : "itemtypes.jpg")}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
        public int ItemTypeId { get; set; }

        public string ItemTypeName => ItemType.Find(ItemTypeId)?.Name;

        public ItemType[] ItemTypes => ItemType.All;

        public DateTime? LastModifiedDate { get; set; }

        public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Item;

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} {(ItemTypeId > 0 ? ItemTypeName : "Memorabilia")}";

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Privacy Type is required.")]
        public int PrivacyTypeId { get; set; }   
        
        public PrivacyType[] PrivacyTypes => PrivacyType.All;

        public int PurchaseTypeId { get; set; }

        public PurchaseType[] PurchaseTypes => PurchaseType.All;

        public int UserId { get; set; }
    }
}
