using Memorabilia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Acquisition Acquisition => _memorabilia.MemorabiliaAcquisition.Acquisition;

        public string AcquisitionTypeName => Domain.Constants.AcquisitionType.Find(_memorabilia.MemorabiliaAcquisition.Acquisition.AcquisitionTypeId).Name;

        public int? ConditionId => _memorabilia.ConditionId;

        public string ConditionName => _memorabilia.Condition?.Name;

        public DateTime CreateDate => _memorabilia.CreateDate;

        public decimal? EstimatedValue => _memorabilia.EstimatedValue;

        public int Id => _memorabilia.Id;

        public string ImagePath => !_memorabilia.Images.Any() 
            ? "wwwroot/images/imagenotavailable.png"
            : _memorabilia.Images.First().FilePath;

        public int ItemTypeId => _memorabilia.ItemTypeId;

        public string ItemTypeName => _memorabilia.ItemType?.Name;

        public DateTime? LastModifiedDate => _memorabilia.LastModifiedDate;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public int PrivacyTypeId => _memorabilia.PrivacyTypeId;

        public string PrivacyTypeName => Domain.Constants.PrivacyType.Find(_memorabilia.PrivacyTypeId).Name;

        public int? PurchaseTypeId => _memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId;

        public string PurchaseTypeName => Domain.Constants.PurchaseType.Find(_memorabilia.MemorabiliaAcquisition.Acquisition.PurchaseTypeId ?? 0)?.Name;

        public string UserFirstName => _memorabilia.User.FirstName;

        public int UserId => _memorabilia.UserId;
    }
}
