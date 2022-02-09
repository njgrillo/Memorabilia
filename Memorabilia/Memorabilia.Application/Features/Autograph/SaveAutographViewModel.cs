using Memorabilia.Application.Features.Autograph.Authentication;
using Memorabilia.Application.Features.Autograph.Inscription;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph
{
    public class SaveAutographViewModel : SaveViewModel
    {
        public SaveAutographViewModel() { }

        public SaveAutographViewModel(AutographViewModel viewModel)
        {
            AcquiredDate = viewModel.Acquisition.AcquiredDate;
            AcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
            Authentications = viewModel.Authentications.Select(authentication => new SaveAuthenticationViewModel(authentication)).ToList();
            ColorId = viewModel.ColorId;
            ConditionId = viewModel.ConditionId;
            Cost = viewModel.Acquisition.Cost;
            CreateDate = viewModel.CreateDate;
            EstimatedValue = viewModel.EstimatedValue;
            Grade = viewModel.Grade;
            Greeting = viewModel.Personalization.Greeting;
            Id = viewModel.Id;
            Inscriptions = viewModel.Inscriptions.Select(inscription => new SaveInscriptionViewModel(inscription)).ToList();
            LastModifiedDate = viewModel.LastModifiedDate;
            MemorabiliaId = viewModel.MemorabiliaId;
            PersonalizationText = viewModel.Personalization.Text;
            PersonId = viewModel.PersonId;
            PurchaseTypeId = viewModel.Acquisition.PurchaseTypeId ?? 0;
            WritingInstrumentId = viewModel.WritingInstrumentId;
        }

        public DateTime? AcquiredDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Acquisition Type is required.")]
        public int AcquisitionTypeId { get; set; }

        public List<SaveAuthenticationViewModel> Authentications { get; set; } = new();

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

        public string Grade { get; set; }

        public string Greeting { get; set; }

        public List<SaveInscriptionViewModel> Inscriptions { get; set; } = new();

        public DateTime? LastModifiedDate { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Autograph";

        public string PersonalizationText { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Person is required.")]
        public int PersonId { get; set; }

        public int PurchaseTypeId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Writing Instrument is required.")]
        public int WritingInstrumentId { get; set; }
    }
}
