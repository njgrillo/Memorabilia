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
                         string grade,
                         string greeting,
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
            Personalization = new Personalization(Id, greeting, personalizationText);
        } 

        public Acquisition Acquisition { get; private set; }
        
        public int AcquisitionId { get; private set; }

        public List<AutographAuthentication> Authentications { get; private set; } = new();

        public int ColorId { get; private set; }

        public int ConditionId { get; private set; }

        public DateTime CreateDate { get; private set; }

        public decimal? EstimatedValue { get; private set; }

        public string Grade { get; private set; }

        public List<AutographImage> Images { get; private set; } = new();

        public List<Inscription> Inscriptions { get; private set; } = new();

        public DateTime? LastModifiedDate { get; private set; }

        public Memorabilia Memorabilia { get; set; }

        public int MemorabiliaId { get; private set; }

        public Person Person { get; set; }

        public Personalization Personalization { get; private set; }

        public int PersonId { get; private set; }

        public List<AutographSpot> Spots { get; private set; } = new();

        public int WritingInstrumentId { get; private set; }

        public void Set(DateTime? acquiredDate,
                        int acquisitionTypeId,
                        int colorId,
                        int conditionId,
                        decimal? cost,
                        decimal? estimatedValue,
                        string grade,
                        string greeting,
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
            Personalization.Set(greeting, personalizationText);
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

        public void SetInscription(int id, int inscriptionTypeId, string text)
        {
            var inscription = Inscriptions.SingleOrDefault(inscription => inscription.Id == id);

            if (inscription == null)
            {
                Inscriptions.Add(new Inscription(Id, inscriptionTypeId, text));
                return;
            }

            inscription.Set(inscriptionTypeId, text);
        }
    }
}
