namespace Memorabilia.Domain.Entities;

public class PrivateSigningPerson : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigningPerson() { }

    public PrivateSigningPerson(bool allowInscriptions,
                                decimal? inscriptionCost,
                                string note,
                                int personId,
                                int privateSigningId,
                                string promoterImageFileName,
                                int? spotsAvailable = null,
                                int? spotsConfirmed = null,
                                int? spotsReserved = null)
    {
        AllowInscriptions = allowInscriptions;
        InscriptionCost = inscriptionCost;
        Note = note;
        PersonId = personId;
        PrivateSigningId = privateSigningId;
        PromoterImageFileName = promoterImageFileName;
        SpotsAvailable = spotsAvailable;
        SpotsConfirmed = spotsConfirmed;
        SpotsReserved = spotsReserved;
    }

    public bool AllowInscriptions { get; private set; }

    public virtual List<PrivateSigningPersonExcludeItemType> ExcludedItems { get; private set; }

    public decimal? InscriptionCost { get; private set; }

    public string Note { get; private set; }

    public virtual Person Person { get; private set; }

    public int PersonId { get; private set; }

    public virtual List<PrivateSigningPersonDetail> Pricing { get; private set; }

    public virtual PrivateSigning PrivateSigning { get; private set; }

    public int PrivateSigningId { get; private set; }

    public string PromoterImageFileName { get; private set; }

    public int? SpotsAvailable { get; private set; }

    public int? SpotsConfirmed { get; private set; }

    public int? SpotsReserved { get; private set; }

    public void Set(bool allowInscriptions,
                    decimal? inscriptionCost,
                    string note,
                    string promoterImageFileName,
                    int? spotsAvailable = null,
                    int? spotsConfirmed = null,
                    int? spotsReserved = null)
    {
        AllowInscriptions = allowInscriptions;
        InscriptionCost = inscriptionCost;
        Note = note;
        PromoterImageFileName = promoterImageFileName;
        SpotsAvailable = spotsAvailable;
        SpotsConfirmed = spotsConfirmed;
        SpotsReserved = spotsReserved;
    }
}
