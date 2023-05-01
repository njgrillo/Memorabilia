namespace Memorabilia.Domain.Entities;

public class Autograph : Framework.Library.Domain.Entity.DomainEntity
{
    public Autograph() { }

    public Autograph(DateTime? acquiredDate,
                     int? acquisitionTypeId, 
                     int colorId,
                     int conditionId,
                     decimal? cost,
                     int? denominator,
                     decimal? estimatedValue,
                     bool fullName,
                     int? grade,
                     int memorabiliaId, 
                     string note,
                     int? numerator,
                     string personalizationText,
                     int personId,
                     int? purchaseTypeId,
                     DateTime? receivedDate,
                     DateTime? sentDate,
                     int writingInstrumentId)
    {
        ColorId = colorId;
        ConditionId = conditionId;
        Denominator = denominator;
        EstimatedValue = estimatedValue;
        FullName = fullName;
        Grade = grade;
        MemorabiliaId = memorabiliaId;
        Note = note;
        Numerator = numerator;
        PersonId = personId;
        WritingInstrumentId = writingInstrumentId;
        CreateDate = DateTime.UtcNow;

        if (acquisitionTypeId.HasValue)
            Acquisition = new Acquisition(acquisitionTypeId.Value, acquiredDate, cost, purchaseTypeId); 
        
        if (!personalizationText.IsNullOrEmpty())
            Personalization = new Personalization(Id, personalizationText);

        SetThroughTheMail(sentDate, receivedDate);
    }

    public virtual Acquisition Acquisition { get; private set; }

    public int? AcquisitionId { get; set; }

    public virtual List<AutographAuthentication> Authentications { get; private set; } = new();

    public int ColorId { get; private set; }

    public int ConditionId { get; private set; }

    public DateTime CreateDate { get; private set; }

    public int? Denominator { get; private set; }

    public decimal? EstimatedValue { get; private set; }

    public bool? FullName { get; private set; }

    public int? Grade { get; private set; }

    public virtual List<AutographImage> Images { get; private set; } = new();

    public virtual List<Inscription> Inscriptions { get; private set; } = new();

    public DateTime? LastModifiedDate { get; private set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; private set; }

    public string Note { get; private set; }

    public int? Numerator { get; private set; }

    public virtual Person Person { get; set; }

    public virtual Personalization Personalization { get; private set; }

    public int PersonId { get; private set; }

    public virtual AutographSpot Spot { get; private set; } 

    public virtual AutographThroughTheMail ThroughTheMail { get; private set; }

    public int WritingInstrumentId { get; private set; }

    public void RemoveAuthentications(params int[] ids)
    {
        if (ids == null || ids.Length == 0)
            return;

        Authentications.RemoveAll(authentication => ids.Contains(authentication.Id));
    }

    public void RemoveInscriptions(params int[] ids)
    {
        if (ids == null || ids.Length == 0)
            return;

        Inscriptions.RemoveAll(inscription => ids.Contains(inscription.Id));
    }

    public void Set(DateTime? acquiredDate,
                    int? acquisitionTypeId,
                    int colorId,
                    int conditionId,
                    decimal? cost,
                    int? denominator,
                    decimal? estimatedValue,
                    bool fullName,
                    int? grade,
                    string note,
                    int? numerator,
                    string personalizationText,
                    int personId,
                    int? purchaseTypeId,
                    DateTime? receivedDate,
                    DateTime? sentDate,
                    int writingInstrumentId)
    {
        ColorId = colorId;
        ConditionId = conditionId;
        Denominator = denominator;
        EstimatedValue = estimatedValue;
        FullName = fullName;
        Grade = grade;
        Note = note;
        Numerator = numerator;
        PersonId = personId;
        WritingInstrumentId = writingInstrumentId;
        LastModifiedDate = DateTime.UtcNow;

        SetAcquisition(acquisitionTypeId, acquiredDate, cost, purchaseTypeId);
        SetPersonalization(personalizationText);
        SetThroughTheMail(sentDate, receivedDate);
    }

    public void SetAuthentication(int id, 
                                  int authenticationCompanyId,
                                  bool? hasCertificationCard,
                                  bool? hasHologram, 
                                  bool? hasLetter, 
                                  string verification,
                                  bool witnessed)
    {
        var authentication = Authentications.SingleOrDefault(authentication => id > 0 && authentication.Id == id) ??
                             Authentications.SingleOrDefault(authentication => authentication.AuthenticationCompanyId == authenticationCompanyId);

        if (authentication == null)
        {
            Authentications.Add(new AutographAuthentication(authenticationCompanyId, 
                                                            Id, 
                                                            hasCertificationCard, 
                                                            hasHologram, 
                                                            hasLetter, 
                                                            verification, 
                                                            witnessed));
            return;
        }

        authentication.Set(authenticationCompanyId, 
                           hasCertificationCard, 
                           hasHologram, 
                           hasLetter, 
                           verification, 
                           witnessed);
    }

    public void SetImages(IEnumerable<string> fileNames, string primaryImageFileName)
    {
        if (!fileNames.Any())
        {
            Images = new List<AutographImage>();
            return;
        }

        Images = fileNames.Select(fileName =>
                                    new AutographImage(Id,
                                                       fileName,
                                                       fileName == primaryImageFileName
                                                             ? Constants.ImageType.Primary.Id
                                                             : Constants.ImageType.Secondary.Id,
                                                       DateTime.UtcNow)).ToList();
    }

    public void SetInscription(int id, int inscriptionTypeId, string inscriptionText)
    {
        var inscription = Inscriptions.SingleOrDefault(inscription => id > 0 && inscription.Id == id) ??
                          Inscriptions.SingleOrDefault(inscription => inscription.InscriptionTypeId == inscriptionTypeId &&
                                                                      inscription.InscriptionText == inscriptionText);

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

    private void SetAcquisition(int? acquisitionTypeId, DateTime? acquiredDate, decimal? cost, int? purchaseTypeId)
    {
        if (acquisitionTypeId.HasValue)
            Acquisition.Set(acquisitionTypeId.Value, acquiredDate, cost, purchaseTypeId);
        else
            Acquisition = null;
    }

    private void SetPersonalization(string personalizationText)
    {
        if (!personalizationText.IsNullOrEmpty())
        {
            if (Personalization == null)
            {
                Personalization = new Personalization(Id, personalizationText);
                return;
            }

            Personalization.Set(personalizationText);
        }
        else
            Personalization = null;
    }

    private void SetThroughTheMail(DateTime? sentDate, DateTime? receivedDate)
    {
        var acquisitionType = Constants.AcquisitionType.Find(Acquisition?.AcquisitionTypeId ?? 0);

        if (acquisitionType != Constants.AcquisitionType.ThroughTheMail)
        {
            if (ThroughTheMail != null)
                ThroughTheMail = null;

            return;
        }

        ThroughTheMail = new AutographThroughTheMail(Id, sentDate, receivedDate);
    }
}
