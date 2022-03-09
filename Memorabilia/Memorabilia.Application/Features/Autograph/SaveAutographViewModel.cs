﻿using Framework.Extension;
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
            AcquiredWithAutograph = viewModel.AcquiredWithAutograph;
            AcquisitionTypeId = viewModel.Acquisition?.AcquisitionTypeId ?? 0;
            ColorId = viewModel.ColorId;
            ConditionId = viewModel.ConditionId;
            Cost = viewModel.Acquisition?.Cost;
            CreateDate = viewModel.CreateDate;
            EstimatedValue = viewModel.EstimatedValue;
            Grade = viewModel.Grade;
            Id = viewModel.Id;
            LastModifiedDate = viewModel.LastModifiedDate;
            MemorabiliaId = viewModel.MemorabiliaId;
            Person = new SavePersonViewModel(new PersonViewModel(viewModel.Person));
            PersonalizationText = viewModel.Personalization?.Text;            
            PurchaseTypeId = viewModel.Acquisition?.PurchaseTypeId ?? 0;
            ReceivedDate = viewModel.ReceivedDate;
            SentDate = viewModel.SentDate;
            WritingInstrumentId = viewModel.WritingInstrumentId;
        }

        public SaveAutographViewModel(MemorabiliaItemViewModel viewModel)
        {
            AcquiredWithAutograph = viewModel.Acquisition?.AcquiredWithAutograph ?? false;
            MemorabiliaAcquiredDate = viewModel.Acquisition.AcquiredDate;
            MemorabiliaAcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
            MemorabiliaCost = viewModel.Acquisition.Cost;
            MemorabiliaEstimatedValue = viewModel.EstimatedValue;
            MemorabiliaId = viewModel.Id;            
            MemorabiliaPurchaseTypeId = viewModel.Acquisition.PurchaseTypeId;            
            UserFirstName = viewModel.UserFirstName;

            var person = viewModel.People.FirstOrDefault()?.Person;
            MemorabiliaPerson = person != null ? new PersonViewModel(person) : new PersonViewModel();
        }

        public DateTime? AcquiredDate { get; set; }

        public bool AcquiredWithAutograph { get; set; }

        public AcquisitionType AcquisitionType => AcquisitionType.Find(AcquisitionTypeId);

        public int AcquisitionTypeId { get; set; }

        public bool CanHaveCost => AcquisitionType.CanHaveCost(AcquisitionType.Find(AcquisitionTypeId));

        public bool CanHavePlaceOfPurchase => AcquisitionType == AcquisitionType.Purchase;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Color is required.")]
        public int ColorId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Condition is required.")]
        public int ConditionId { get; set; }

        public decimal? Cost { get; set; }

        public DateTime CreateDate { get; set; }

        public bool DisplayAcquisitionDetails => !AcquiredWithAutograph;

        public bool DisplayThroughTheMailDetails => AcquisitionType == AcquisitionType.ThroughTheMail;

        public decimal? EstimatedValue { get; set; }        

        public int? Grade { get; set; }

        public bool IsAcquisitionFromMemorabilia
        {
            get
            {
                if (AcquisitionTypeId == MemorabiliaAcquisitionTypeId && 
                    AcquiredDate == MemorabiliaAcquiredDate &&
                    Cost == MemorabiliaCost &&
                    PurchaseTypeId == MemorabiliaPurchaseTypeId)
                    return true;

                return false;
            }
        }

        public bool IsEstimatedValueFromMemorabilia
        {
            get
            {
                if (EstimatedValue == MemorabiliaEstimatedValue &&
                    MemorabiliaEstimatedValue.HasValue)
                    return true;

                return false;
            }
        }

        public bool IsPersonalized => !PersonalizationText.IsNullOrEmpty();

        public DateTime? LastModifiedDate { get; set; }

        public DateTime? MemorabiliaAcquiredDate { get; set; }

        public int MemorabiliaAcquisitionTypeId { get; set; }

        public decimal? MemorabiliaCost { get; set; }

        public decimal? MemorabiliaEstimatedValue { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public PersonViewModel MemorabiliaPerson { get; set; }

        public int? MemorabiliaPurchaseTypeId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Autograph";

        [Required]
        public SavePersonViewModel Person { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Person is required.")]
        public int? PersonId => Person?.Id;

        public string PersonalizationText { get; set; }

        public int PurchaseTypeId { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? SentDate { get; set; }

        public string UserFirstName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Writing Instrument is required.")]
        public int WritingInstrumentId { get; set; }
    }
}
