namespace Memorabilia.Domain.Entities;

public class PrivateSigning : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigning() { }

    public PrivateSigning(DateTime createdDate,
                          int createdUserId,
                          string note,
                          bool selfAddressedStampedEnvelopeAccepted,
                          DateTime signingDate,
                          DateTime submissionDeadlineDate,
                          string promoterImageFileName)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
        PromoterImageFileName = promoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = selfAddressedStampedEnvelopeAccepted;
        SigningDate = signingDate;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public PrivateSigning(PrivateSigning privateSigning)
    {
        AuthenticationCompanies = privateSigning.AuthenticationCompanies;
        CreatedDate = privateSigning.CreatedDate;
        CreatedUser = privateSigning.CreatedUser;
        CreatedUserId = privateSigning.CreatedUserId;
        Id = privateSigning.Id;
        Note = privateSigning.Note;
        People = privateSigning.People;
        PromoterImageFileName = privateSigning.PromoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = privateSigning.SelfAddressedStampedEnvelopeAccepted;
        SigningDate = privateSigning.SigningDate;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;
    }

    public virtual List<PrivateSigningAuthenticationCompany> AuthenticationCompanies { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public string Note { get; private set; }

    public virtual List<PrivateSigningPerson> People { get; private set; }

    public string PromoterImageFileName { get; private set; }

    public virtual List<PrivateSigningPromoterProvidedItem> PromoterProvidedItems { get; private set; }

    public bool SelfAddressedStampedEnvelopeAccepted { get; private set; }

    public DateTime SigningDate { get; private set; }

    public DateTime SubmissionDeadlineDate { get; private set; }

    public void Set(string note,
                    bool selfAddressedStampedEnvelopeAccepted,    
                    DateTime signingDate,
                    DateTime submissionDeadlineDate,
                    string promoterImageFileName)
    {
        Note = note;
        PromoterImageFileName = promoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = selfAddressedStampedEnvelopeAccepted;
        SigningDate = signingDate;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public void SetAuthenticationCompany(int privateSigningAuthenticationCompanyId,
                                         int authenticationCompanyId,
                                         decimal cost)
    {
        AuthenticationCompanies ??= new();

        PrivateSigningAuthenticationCompany authenticationCompany
            = AuthenticationCompanies.SingleOrDefault(company => company.Id == privateSigningAuthenticationCompanyId);

        if (authenticationCompany == null)
        {
            AuthenticationCompanies.Add(new PrivateSigningAuthenticationCompany(authenticationCompanyId,
                                                                                cost,
                                                                                Id));                                        

            return;
        }

        authenticationCompany.Set(cost);
    }

    public void SetPerson(bool allowInscriptions,
                          decimal? inscriptionCost,
                          int privateSigningPersonId,
                          string note,
                          int personId,
                          string promoterImageFileName,
                          int? spotsAvailable,
                          int? spotsConfirmed)
    {
        People ??= new();

        PrivateSigningPerson privateSigningPerson
            = People.SingleOrDefault(person => person.Id == privateSigningPersonId);

        if (privateSigningPerson == null)
        {      
            People.Add(new PrivateSigningPerson(allowInscriptions,
                                                inscriptionCost,
                                                note,
                                                personId,
                                                Id,
                                                promoterImageFileName,
                                                spotsAvailable,
                                                spotsConfirmed));

            return;
        }

        privateSigningPerson.Set(allowInscriptions,
                                 inscriptionCost,
                                 note,
                                 promoterImageFileName,
                                 spotsAvailable,
                                 spotsConfirmed);
    }

    public void SetProvidedItem(int privateSigningPromoterProvidedItemId,
                                decimal cost,
                                int itemTypeId,
                                int promoterId,
                                decimal? shippingCost)
    {
        PromoterProvidedItems ??= new();

        PrivateSigningPromoterProvidedItem privateSigningPromoterProvidedItem
            = PromoterProvidedItems.SingleOrDefault(item => item.Id == privateSigningPromoterProvidedItemId);

        if (privateSigningPromoterProvidedItem == null)
        {
            PromoterProvidedItem providedItem = new(cost,
                                                    itemTypeId,
                                                    promoterId,
                                                    shippingCost);

            PrivateSigningPromoterProvidedItem promoterProvidedItem = new(Id, providedItem.Id);

            promoterProvidedItem.SetPromoterProvidedItem(providedItem);

            PromoterProvidedItems.Add(promoterProvidedItem);

            return;
        }

        privateSigningPromoterProvidedItem.PromoterProvidedItem.Set(cost, 
                                                                    itemTypeId, 
                                                                    shippingCost);
    }
}
