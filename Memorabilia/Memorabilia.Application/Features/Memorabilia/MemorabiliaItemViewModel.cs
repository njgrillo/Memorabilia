using System;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class MemorabiliaItemViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public MemorabiliaItemViewModel() { }

        public MemorabiliaItemViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int? ConditionId => _memorabilia.ConditionId;

        public string ConditionName => _memorabilia.Condition?.Name;

        public decimal? Cost => _memorabilia.Cost;

        public DateTime CreateDate => _memorabilia.CreateDate;

        public decimal? EstimatedValue => _memorabilia.EstimatedValue;

        public int Id => _memorabilia.Id;

        public string ImagePath => _memorabilia.ImagePath;

        public int ItemTypeId => _memorabilia.ItemTypeId;

        public string ItemTypeName => _memorabilia.ItemType?.Name;

        public DateTime? LastModifiedDate => _memorabilia.LastModifiedDate;

        public int UserId => _memorabilia.UserId;
    }
}
