using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Autograph
{
    public class AutographViewModel
    {
        private readonly Domain.Entities.Autograph _autograph;

        public AutographViewModel() { }

        public AutographViewModel(Domain.Entities.Autograph autograph)
        {
            _autograph = autograph;
        }

        public Domain.Entities.Acquisition Acquisition => _autograph.Acquisition;

        public DateTime? AcquisitionDate => Acquisition?.AcquiredDate;

        public string AcquisitionTypeName => AcquisitionType.Find(Acquisition?.AcquisitionTypeId ?? 0)?.Name;

        public List<Domain.Entities.AutographAuthentication> Authentications => _autograph.Authentications;

        public int ColorId => _autograph.ColorId;

        public string ColorName => Color.Find(_autograph.ColorId)?.Name;

        public int ConditionId => _autograph.ConditionId;

        public string ConditionName => Condition.Find(_autograph.ConditionId)?.Name;

        public DateTime CreateDate => _autograph.CreateDate;

        public decimal? EstimatedValue => _autograph.EstimatedValue;

        public string FormattedAcquisitionDate => AcquisitionDate?.ToString("MM-dd-yyyy") ?? string.Empty;

        public string FormattedEstimatedValue => EstimatedValue?.ToString("c") ?? string.Empty;

        public int? Grade => _autograph.Grade;    

        public int Id => _autograph.Id;

        public string ImagePath => !_autograph.Images.Any() ? "wwwroot/images/imagenotavailable.png" : _autograph.Images.First().FilePath;

        public List<Domain.Entities.Inscription> Inscriptions => _autograph.Inscriptions;

        public string ItemTypeName => ItemType.Find(_autograph.Memorabilia.ItemTypeId)?.Name;

        public DateTime? LastModifiedDate => _autograph.LastModifiedDate;

        public int MemorabiliaId => _autograph.MemorabiliaId;

        public Domain.Entities.Person Person => _autograph.Person;

        public Domain.Entities.Personalization Personalization => _autograph.Personalization;

        public int PersonId => _autograph.PersonId;

        public string PersonName => _autograph.Person?.DisplayName;

        public string UserFirstName => _autograph.Memorabilia.User.FirstName;

        public int WritingInstrumentId => _autograph.WritingInstrumentId;

        public string WritingInstrumentName => WritingInstrument.Find(_autograph.WritingInstrumentId)?.Name;
    }
}
