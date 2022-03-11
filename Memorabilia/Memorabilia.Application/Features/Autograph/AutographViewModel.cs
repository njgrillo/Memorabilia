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

        public bool AcquiredWithAutograph => _autograph.Memorabilia.Acquisition?.AcquiredWithAutograph ?? false;

        public Domain.Entities.Acquisition Acquisition => _autograph.Acquisition;

        public DateTime? AcquisitionDate => Acquisition?.AcquiredDate;

        public string AcquisitionTypeName => AcquisitionType.Find(Acquisition?.AcquisitionTypeId ?? 0)?.Name;

        public string AuthenticationIconPath => Authentications.Any() ? "images/check.png" : "images/none.png";

        public string AuthenticationTooltip => Authentications.Any() ? "Is Authenticated" : "No Authentications Found";

        public List<Domain.Entities.AutographAuthentication> Authentications => _autograph.Authentications;        

        public int ColorId => _autograph.ColorId;

        public string ColorName => Color.Find(_autograph.ColorId)?.Name;

        public int ConditionId => _autograph.ConditionId;

        public string ConditionName => Condition.Find(_autograph.ConditionId)?.Name;

        public DateTime CreateDate => _autograph.CreateDate;

        public bool DisplaySpot => ItemType.CanHaveSpot(ItemType.Find(ItemTypeId));

        public decimal? EstimatedValue => _autograph.EstimatedValue;

        public string FormattedAcquisitionDate => AcquisitionDate?.ToString("MM-dd-yyyy") ?? string.Empty;

        public string FormattedCost => Acquisition?.Cost?.ToString("c") ?? string.Empty;

        public string FormattedEstimatedValue => EstimatedValue?.ToString("c") ?? string.Empty;

        public bool? FullName => _autograph.FullName;   

        public int? Grade => _autograph.Grade;    

        public int Id => _autograph.Id;

        public string ImageDisplayCount
        {
            get
            {
                if (!Images.Any())
                    return "No Images Found";

                if (Images.Count == 1)
                    return "1 Image";

                return $"{Images.Count} Images";
            }
        }

        public List<Domain.Entities.AutographImage> Images => _autograph.Images;

        public string InscriptionIconPath => Inscriptions.Any() ? "images/check.png" : "images/none.png";

        public string InscriptionTooltip => Inscriptions.Any() ? "Has Inscription(s)" : "No Inscriptions Found";

        public List<Domain.Entities.Inscription> Inscriptions => _autograph.Inscriptions;

        public bool IsPersonalized => Personalization?.Id > 0;

        public int ItemTypeId => _autograph.Memorabilia.ItemTypeId;

        public string ItemTypeName => ItemType.Find(_autograph.Memorabilia.ItemTypeId)?.Name;

        public DateTime? LastModifiedDate => _autograph.LastModifiedDate;

        public int MemorabiliaId => _autograph.MemorabiliaId;

        public Domain.Entities.Person Person => _autograph.Person;

        public Domain.Entities.Personalization Personalization => _autograph.Personalization;

        public string PersonalizationIconPath => IsPersonalized ? "images/check.png" : "images/none.png";

        public string PersonalizationTooltip => IsPersonalized ? "Is Personalized" : "Not Personalized";

        public int PersonId => _autograph.PersonId;

        public string PersonName => _autograph.Person?.DisplayName;

        public string PrimaryImagePath => Images.Any()
            ? Images.SingleOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)?.FilePath ?? "wwwroot/images/imagenotavailable.png"
            : "wwwroot/images/imagenotavailable.png";        

        public int? PurchaseTypeId => _autograph?.Acquisition?.PurchaseTypeId;

        public string PurchaseTypeName => PurchaseType.Find(PurchaseTypeId ?? 0)?.Name;

        public DateTime? ReceivedDate => _autograph.ThroughTheMail?.ReceivedDate;

        public DateTime? SentDate => _autograph.ThroughTheMail?.SentDate;

        public string UserFirstName => _autograph.Memorabilia.User.FirstName;

        public int WritingInstrumentId => _autograph.WritingInstrumentId;

        public string WritingInstrumentName => WritingInstrument.Find(_autograph.WritingInstrumentId)?.Name;
    }
}
