using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Autograph
{
    public class SaveAutographViewModel : SaveViewModel
    {
        public SaveAutographViewModel() { }

        public SaveAutographViewModel(AutographViewModel viewModel)
        {
            ColorId = viewModel.ColorId;
            ConditionId = viewModel.ConditionId;
            CreateDate = viewModel.CreateDate;
            Id = viewModel.Id;
            LastModifiedDate = viewModel.LastModifiedDate;
            MemorabiliaId = viewModel.MemorabiliaId;
            PersonId = viewModel.PersonId;
            SpotId = viewModel.SpotId;
            UserId = viewModel.UserId;
            WritingInstrumentId = viewModel.WritingInstrumentId;
        }

        public int? ColorId { get; set; }

        public int? ConditionId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} Autograph";

        public int PersonId { get; set; }

        public int? SpotId { get; set; }

        public int UserId { get; set; }

        public int? WritingInstrumentId { get; set; }
    }
}
