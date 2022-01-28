using Memorabilia.Application.Features.Admin.Commissioner;
using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Application.Features.Admin.ItemTypeSize;
using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class SaveBaseballViewModel : SaveViewModel
    {
        public SaveBaseballViewModel() { }

        public SaveBaseballViewModel(BaseballViewModel viewModel)
        {
            BaseballTypeId = viewModel.MemorabiliaBaseballType.BaseballTypeId;
            BrandId = viewModel.MemorabiliaBrand.BrandId;
            Brands = viewModel.Brands;
            CommissionerId = viewModel.MemorabiliaCommissioner.CommissionerId;
            Commissioners = viewModel.Commissioners;
            MemorabiliaBaseballTypeId = viewModel.MemorabiliaBaseballType.Id;
            MemorabiliaBrandId = viewModel.MemorabiliaBrand.Id;
            MemorabiliaCommissionerId = viewModel.MemorabiliaCommissioner.Id;
            MemorabiliaId = viewModel.MemorabiliaId;
            MemorabiliaSizeId = viewModel.MemorabiliaSize.Id;
            People = viewModel.People;
            PersonIds = viewModel.PersonIds;
            SizeId = viewModel.MemorabiliaSize.SizeId;
            Sizes = viewModel.Sizes;
            SportIds = viewModel.SportIds;
            TeamIds = viewModel.TeamIds;
            Teams = viewModel.Teams;
        }

        [Required]
        public int BaseballTypeId { get; set; }

        [Required]
        public int BrandId { get; set; }  
        
        public IEnumerable<ItemTypeBrandViewModel> Brands { get; set; } = Enumerable.Empty<ItemTypeBrandViewModel>();
        
        public int CommissionerId { get; set; }

        public IEnumerable<CommissionerViewModel> Commissioners { get; set; } = Enumerable.Empty<CommissionerViewModel>();

        public int MemorabiliaBaseballTypeId { get; set; }

        public int MemorabiliaBrandId { get; set; }

        public int MemorabiliaCommissionerId { get; set; }

        [Required]
        public int MemorabiliaId { get; set; }

        public int MemorabiliaSizeId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {Domain.Constants.ItemType.Baseball.Name}";

        public IEnumerable<PersonViewModel> People { get; set; } = Enumerable.Empty<PersonViewModel>();

        public List<int> PersonIds { get; set; }

        [Required]
        public int SizeId { get; set; }

        public IEnumerable<ItemTypeSizeViewModel> Sizes { get; set; } = Enumerable.Empty<ItemTypeSizeViewModel>();

        public List<int> SportIds { get; set; }

        public IEnumerable<Domain.Constants.Sport> Sports => Domain.Constants.Sport.All;

        public List<int> TeamIds { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; } = Enumerable.Empty<TeamViewModel>();
    }
}
