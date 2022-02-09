using Memorabilia.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {
            AuthenticTypeId = viewModel.MemorabiliaGame?.AuthenticTypeId ?? 0;
            BaseballTypeAnniversary = viewModel.MemorabiliaBaseball?.Anniversary;
            BaseballTypeId = viewModel.MemorabiliaBaseball?.BaseballTypeId ?? 0;
            BaseballTypeYear = viewModel.MemorabiliaBaseball?.Year;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            CommissionerId = viewModel.MemorabiliaCommissioner.CommissionerId;
            GameDate = viewModel.MemorabiliaGame?.GameDate;
            LevelTypeId = viewModel.MemorabiliaLevelType.LevelTypeId;
            MemorabiliaId = viewModel.MemorabiliaId;
            PersonId = viewModel.PersonId ?? 0;
            SizeId = viewModel.MemorabiliaSize.SizeId;
            TeamId = viewModel.TeamId ?? 0;
        }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Game Level Type is required.")]
        public int AuthenticTypeId { get; set; }

        [StringLength(5, ErrorMessage = "Anniversary is too long.")]
        public string BaseballTypeAnniversary { get; set; }

        public BaseballType BaseballType => BaseballType.Find(BaseballTypeId);

        public int BaseballTypeId { get; set; }

        public int? BaseballTypeYear { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }  
        
        public int CommissionerId { get; set; }

        public bool DisplayBaseballType => BrandId == Brand.Rawlings.Id;

        public bool DisplayBaseballTypeAnniversary => DisplayBaseballType && BaseballType.CanHaveAnniversary(BaseballType);

        public bool DisplayBaseballTypeYear => DisplayBaseballType && BaseballType.CanHaveYear(BaseballType);

        public DateTime? GameDate { get; set; }

        public bool HasPerson => PersonId > 0;

        public bool HasTeam => TeamId > 0;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Level is required.")]
        public int LevelTypeId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Baseball.Name} Details";

        public int PersonId { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public int TeamId { get; set; }
    }
}
