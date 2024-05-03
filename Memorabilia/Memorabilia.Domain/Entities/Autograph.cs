namespace Memorabilia.Domain.Entities;

public class Autograph : Entity
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
    }

    public virtual Acquisition Acquisition { get; private set; }

    public int? AcquisitionId { get; set; }

    public virtual List<AutographAuthentication> Authentications { get; private set; } 
        = [];

    public int ColorId { get; private set; }

    public int ConditionId { get; private set; }

    public DateTime CreateDate { get; private set; }

    public int? Denominator { get; private set; }

    [Precision(12, 2)]
    public decimal? EstimatedValue { get; private set; }

    public bool? FullName { get; private set; }

    public int? Grade { get; private set; }

    public virtual List<AutographImage> Images { get; private set; } 
        = [];

    public virtual List<Inscription> Inscriptions { get; private set; } 
        = [];

    public DateTime? LastModifiedDate { get; private set; }

    public virtual Memorabilia Memorabilia { get; set; }

    public int MemorabiliaId { get; private set; }

    public string Note { get; private set; }

    public int? Numerator { get; private set; }

    public virtual Person Person { get; set; }

    public virtual Personalization Personalization { get; private set; }

    public int PersonId { get; private set; }

    public virtual AutographSpot Spot { get; private set; } 

    public virtual ThroughTheMailMemorabilia ThroughTheMailMemorabilia { get; private set; }

    public int WritingInstrumentId { get; private set; }

    public void RemoveAuthentications(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
            return;

        Authentications.RemoveAll(authentication => ids.Contains(authentication.Id));
    }

    public void RemoveInscriptions(params int[] ids)
    {
        if (ids.IsNullOrEmpty())
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
        if (fileNames.IsNullOrEmpty())
        {
            Images = [];
            return;
        }

        Images = fileNames.Select(fileName =>
                                    new AutographImage(Id,
                                                       fileName,
                                                       fileName == primaryImageFileName
                                                             ? Constant.ImageType.Primary.Id
                                                             : Constant.ImageType.Secondary.Id,
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
}
