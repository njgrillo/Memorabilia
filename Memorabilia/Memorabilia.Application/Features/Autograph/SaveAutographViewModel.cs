using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Memorabilia;
using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph
{
    public class SaveAutographViewModel : SaveViewModel
    {
        public SaveAutographViewModel() { }

        public SaveAutographViewModel(AutographViewModel viewModel)
        {
            AcquiredDate = viewModel.Acquisition?.AcquiredDate;
            AcquisitionTypeId = viewModel.Acquisition?.AcquisitionTypeId ?? 0;
            ColorId = viewModel.ColorId;
            ConditionId = viewModel.ConditionId;
            Cost = viewModel.Acquisition?.Cost;
            CreateDate = viewModel.CreateDate;
            EstimatedValue = viewModel.EstimatedValue;
            Grade = viewModel.Grade;
            Id = viewModel.Id;
            ItemTypeName = viewModel.ItemTypeName;
            LastModifiedDate = viewModel.LastModifiedDate;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.Person));
            PersonalizationText = viewModel.Personalization?.Text;            
            PurchaseTypeId = viewModel.Acquisition?.PurchaseTypeId ?? 0;
            WritingInstrumentId = viewModel.WritingInstrumentId;
        }

        public SaveAutographViewModel(MemorabiliaItemViewModel viewModel)
        {
            ItemTypeName = viewModel.ItemTypeName;
            MemorabiliaAcquiredDate = viewModel.Acquisition.AcquiredDate;
            MemorabiliaAcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
            MemorabiliaCost = viewModel.Acquisition.Cost;
            MemorabiliaId = viewModel.Id;            
            MemorabiliaPurchaseTypeId = viewModel.Acquisition.PurchaseTypeId;            
            UserFirstName = viewModel.UserFirstName;

            var person = viewModel.People.FirstOrDefault()?.Person;
            MemorabiliaPerson = person != null ? new PersonViewModel(person) : new PersonViewModel();
        }

        public DateTime? AcquiredDate { get; set; }

        public int AcquisitionTypeId { get; set; }

        public bool CanHaveCost => AcquisitionType.CanHaveCost(AcquisitionType.Find(AcquisitionTypeId));

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Color is required.")]
        public int ColorId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Condition is required.")]
        public int ConditionId { get; set; }

        public decimal? Cost { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? EstimatedValue { get; set; }

        public int? Grade { get; set; }

        public string ItemTypeName { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public DateTime? MemorabiliaAcquiredDate { get; set; }

        public int MemorabiliaAcquisitionTypeId { get; set; }

        public decimal? MemorabiliaCost { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public PersonViewModel MemorabiliaPerson { get; set; }

        public int? MemorabiliaPurchaseTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Autograph";

        [Required]
        public SavePersonViewModel Person { get; set; } = new();

        public string PersonalizationText { get; set; }

        public int PurchaseTypeId { get; set; }

        public string UserFirstName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Writing Instrument is required.")]
        public int WritingInstrumentId { get; set; }
    }
}
