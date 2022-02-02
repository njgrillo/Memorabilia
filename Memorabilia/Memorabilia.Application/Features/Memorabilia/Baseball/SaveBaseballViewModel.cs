using Memorabilia.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {
            BaseballTypeAnniversary = viewModel.MemorabiliaBaseballType?.Anniversary;
            BaseballTypeId = viewModel.MemorabiliaBaseballType?.BaseballTypeId ?? 0;
            BaseballTypeYear = viewModel.MemorabiliaBaseballType?.Year;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            CommissionerId = viewModel.MemorabiliaCommissioner.CommissionerId;
            MemorabiliaBaseballTypeId = viewModel.MemorabiliaBaseballType?.Id;
            MemorabiliaBrandId = viewModel.MemorabiliaBrand.Id;
            MemorabiliaCommissionerId = viewModel.MemorabiliaCommissioner.Id;
            MemorabiliaId = viewModel.MemorabiliaId;
            MemorabiliaSizeId = viewModel.MemorabiliaSize.Id;
            PersonId = viewModel.PersonId ?? 0;
            SizeId = viewModel.MemorabiliaSize.SizeId;
            TeamId = viewModel.TeamId ?? 0;
        }

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

        public bool HasPerson => PersonId > 0;

        public bool HasTeam => TeamId > 0;

        public int? MemorabiliaBaseballTypeId { get; set; }

        public int MemorabiliaBrandId { get; set; }

        public int MemorabiliaCommissionerId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public int MemorabiliaSizeId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {Domain.Constants.ItemType.Baseball.Name} Details";

        public int PersonId { get; set; } 

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public int TeamId { get; set; }
    }
}
