using System;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Domain.Entities
{
    public class Autograph : Framework.Domain.Entity.DomainEntity
    {
        public Autograph() { }

        public Autograph(DateTime? acquiredDate,
                         int acquisitionTypeId, 
                         int colorId,
                         int conditionId,
                         decimal? cost,
                         decimal? estimatedValue,
                         int? grade,
                         int memorabiliaId,                         
                         string personalizationText,
                         int personId,
                         int? purchaseTypeId,
                         int writingInstrumentId)
        {
            ColorId = colorId;
            ConditionId = conditionId;
            EstimatedValue = estimatedValue;    
            Grade = grade;
            MemorabiliaId = memorabiliaId;
            PersonId = personId;
            WritingInstrumentId = writingInstrumentId;
            CreateDate = DateTime.UtcNow;

            Acquisition = new Acquisition(acquisitionTypeId, acquiredDate, cost, purchaseTypeId); 
            
            if (!string.IsNullOrEmpty(personalizationText))
                Personalization = new Personalization(Id, personalizationText);
        } 

        public Acquisition Acquisition { get; private set; }
        
        public int AcquisitionId { get; private set; }

        public List<AutographAuthentication> Authentications { get; private set; } = new();

        public int ColorId { get; private set; }

        public int ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public int? Grade { get; private set; }

        public List<AutographImage> Images { get; private set; } = new();

        public List<Inscription> Inscriptions { get; private set; } = new();

        public DateTime? LastModifiedDate { get; private set; }

        public Memorabilia Memorabilia { get; set; }

        public int MemorabiliaId { get; private set; }

        public Person Person { get; set; }

        public Personalization Personalization { get; private set; }

        public int PersonId { get; private set; }

        public AutographSpot Spot { get; private set; } 

        public int WritingInstrumentId { get; private set; }

        public void Set(DateTime? acquiredDate,
                        int acquisitionTypeId,
                        int colorId,
                        int conditionId,
                        decimal? cost,
                        decimal? estimatedValue,
                        int? grade,
                        string personalizationText,
                        int personId,
                        int? purchaseTypeId,
                        int writingInstrumentId)
        {
            ColorId = colorId;
            ConditionId = conditionId;
            EstimatedValue = estimatedValue;
            Grade = grade;
            PersonId = personId;
            WritingInstrumentId = writingInstrumentId;
            LastModifiedDate = DateTime.UtcNow;

            Acquisition.Set(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
            Personalization.Set(personalizationText);
        }

        public void SetAuthentication(int id, int authenticationCompanyId, bool? hasHologram, bool? hasLetter, string verification)
        {
            var authentication = Authentications.SingleOrDefault(authentication => authentication.Id == id);

            if (authentication == null)
            {
                Authentications.Add(new AutographAuthentication(authenticationCompanyId, Id, hasHologram, hasLetter, verification));
                return;
            }

            authentication.Set(authenticationCompanyId, hasHologram, hasLetter, verification);
        }

        public void SetImages(IEnumerable<string> filePaths, string primaryImageFilePath)
        {
            if (!filePaths.Any())
            {
                Images = new List<AutographImage>();
                return;
            }

            Images = filePaths.Select(filePath =>
                                        new AutographImage(Id,
                                                           filePath,
                                                           filePath == primaryImageFilePath
                                                                 ? Constants.ImageType.Primary.Id
                                                                 : Constants.ImageType.Secondary.Id,
                                                           DateTime.UtcNow)).ToList();
        }

        public void SetInscription(int id, int inscriptionTypeId, string inscriptionText)
        {
            var inscription = Inscriptions.SingleOrDefault(inscription => inscription.Id == id);

            if (inscription == null)
            {
                Inscriptions.Add(new Inscription(Id, inscriptionTypeId, inscriptionText));
                return;
            }

            inscription.Set(inscriptionTypeId, inscriptionText);
        }

        public void SetSpot(int spotId)
        {
            if (Spot == null)
            {
                Spot = new AutographSpot(Id, spotId);
                return;
            }

            Spot.Set(spotId);
        }
    }
}
