namespace Memorabilia.Domain.Entities;

public class PrivateSigningPerson : Entity
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

    [Precision(12, 2)]
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

    public void SetCustomPrice(decimal cost,
                               string note,
                               int privateSigningCustomItemTypeGroupDetailId,
                               int privateSigningPersonDetailId,
                               int privateSigningPersonId,
                               decimal? shippingCost)
    {
        Pricing ??= [];

        PrivateSigningPersonDetail privateSigningPersonDetail
            = Pricing.SingleOrDefault(personDetail => personDetail.Id == privateSigningPersonDetailId);

        if (privateSigningPersonDetail == null)
        {
            privateSigningPersonDetail = new(note,
                                             privateSigningCustomItemTypeGroupDetailId,
                                             null,
                                             privateSigningPersonId);

            //TODO
            //privateSigningPersonDetail.SetItemTypeGroup(cost,
            //                                            privateSigningCustomItemTypeGroupDetailId,
            //                                            shippingCost);

            Pricing.Add(privateSigningPersonDetail);

            return;
        }

        privateSigningPersonDetail.PrivateSigningItemTypeGroup.Set(cost,
                                                                   shippingCost);
    }

    public void SetExcludedItem(int privateSigningPersonExcludeItemTypeId,
                                int itemTypeId,
                                string note,
                                int privateSigningPersonId)
    {
        ExcludedItems ??= [];

        PrivateSigningPersonExcludeItemType privateSigningPersonExcludeItemType
            = ExcludedItems.SingleOrDefault(item => item.Id == privateSigningPersonExcludeItemTypeId);

        if (privateSigningPersonExcludeItemType == null)
        {
            ExcludedItems.Add(new PrivateSigningPersonExcludeItemType(itemTypeId,
                                                                      note,
                                                                      privateSigningPersonId));

            return;
        }

        privateSigningPersonExcludeItemType.Set(note);
    }

    public void SetPrice(decimal cost,
                         string note,
                         int privateSigningItemGroupId,
                         int privateSigningPersonDetailId,
                         int privateSigningPersonId,
                         decimal? shippingCost)
    {
        Pricing ??= [];

        PrivateSigningPersonDetail privateSigningPersonDetail
            = Pricing.SingleOrDefault(personDetail => personDetail.Id == privateSigningPersonDetailId);

        if (privateSigningPersonDetail == null)
        {
            privateSigningPersonDetail = new(note,
                                             null,
                                             null,
                                             privateSigningPersonId);

            privateSigningPersonDetail.SetItemTypeGroup(cost,
                                                        privateSigningItemGroupId,
                                                        shippingCost);

            Pricing.Add(privateSigningPersonDetail);

            return;
        }

        privateSigningPersonDetail.PrivateSigningItemTypeGroup.Set(cost,
                                                                   shippingCost);
    }
}
