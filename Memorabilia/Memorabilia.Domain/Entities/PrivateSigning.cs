namespace Memorabilia.Domain.Entities;

public class PrivateSigning : Entity
{
    public PrivateSigning() { }

    public PrivateSigning(DateOnly? beginSigningDate,
                          DateTime createdDate,
                          int createdUserId,
                          DateOnly? endSigningDate,
                          string note,
                          bool selfAddressedStampedEnvelopeAccepted,
                          DateTime submissionDeadlineDate,
                          string promoterImageFileName)
    {
        BeginSigningDate = beginSigningDate;
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        EndSigningDate = endSigningDate;
        Note = note;
        PromoterImageFileName = promoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = selfAddressedStampedEnvelopeAccepted;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public PrivateSigning(PrivateSigning privateSigning)
    {
        AuthenticationCompanies = privateSigning.AuthenticationCompanies;
        BeginSigningDate = privateSigning.BeginSigningDate;
        CreatedDate = privateSigning.CreatedDate;
        CreatedUser = privateSigning.CreatedUser;
        CreatedUserId = privateSigning.CreatedUserId;
        EndSigningDate = privateSigning.EndSigningDate;
        Id = privateSigning.Id;
        Note = privateSigning.Note;
        People = privateSigning.People;
        PromoterImageFileName = privateSigning.PromoterImageFileName;
        Published = privateSigning.Published;
        PublishedDate = privateSigning.PublishedDate;
        SelfAddressedStampedEnvelopeAccepted = privateSigning.SelfAddressedStampedEnvelopeAccepted;
        SubmissionDeadlineDate = privateSigning.SubmissionDeadlineDate;
    }

    public virtual List<PrivateSigningAuthenticationCompany> AuthenticationCompanies { get; private set; }

    public DateOnly? BeginSigningDate { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public virtual User CreatedUser { get; private set; }

    public int CreatedUserId { get; private set; }

    public DateOnly? EndSigningDate { get; private set; }

    public string Note { get; private set; }

    public virtual List<PrivateSigningPaymentOption> PaymentOptions { get; private set; }

    public virtual List<PrivateSigningPerson> People { get; private set; }

    public string PromoterImageFileName { get; private set; }

    public virtual List<PrivateSigningPromoterProvidedItem> PromoterProvidedItems { get; private set; }

    public bool Published { get; private set; }

    public DateTime? PublishedDate { get; private set; }

    public bool SelfAddressedStampedEnvelopeAccepted { get; private set; }

    public DateTime SubmissionDeadlineDate { get; private set; }

    public void Publish()
    {
        Published = true;
        PublishedDate = DateTime.UtcNow;
    }

    public void RemoveAuthenticationCompany(int privateSigningAuthenticationCompanyId)
    {
        AuthenticationCompanies ??= [];

        PrivateSigningAuthenticationCompany privateSigningAuthenticationCompany
            = AuthenticationCompanies.SingleOrDefault(company => company.Id == privateSigningAuthenticationCompanyId);

        if (privateSigningAuthenticationCompany == null)
        {
            return;
        }

        AuthenticationCompanies.Remove(privateSigningAuthenticationCompany);
    }

    public void RemovePaymentOption(int privateSigningPaymentOptionId)
    {
        PaymentOptions ??= [];

        PrivateSigningPaymentOption privateSigningPaymentOption
            = PaymentOptions.SingleOrDefault(option => option.Id == privateSigningPaymentOptionId);

        if (privateSigningPaymentOption == null)
        {
            return;
        }

        PaymentOptions.Remove(privateSigningPaymentOption);
    }

    public void RemovePerson(int privateSigningPersonId)
    {
        People ??= [];

        PrivateSigningPerson privateSigningPerson
            = People.SingleOrDefault(person => person.Id == privateSigningPersonId);

        if (privateSigningPerson == null)
        {
            return;
        }

        People.Remove(privateSigningPerson);
    }

    public void RemoveProvidedItem(int privateSigningProvidedItemId)
    {
        PromoterProvidedItems ??= [];

        PrivateSigningPromoterProvidedItem promoterProvidedItem
            = PromoterProvidedItems.SingleOrDefault(item => item.Id == privateSigningProvidedItemId);

        if (promoterProvidedItem == null)
        {
            return;
        }

        PromoterProvidedItems.Remove(promoterProvidedItem);
    }

    public void Set(DateOnly? beginSigningDate,
                    DateOnly? endSigningDate,   
                    string note,
                    bool selfAddressedStampedEnvelopeAccepted,    
                    DateTime submissionDeadlineDate,
                    string promoterImageFileName)
    {
        BeginSigningDate = beginSigningDate;
        EndSigningDate = endSigningDate;
        Note = note;
        PromoterImageFileName = promoterImageFileName;
        SelfAddressedStampedEnvelopeAccepted = selfAddressedStampedEnvelopeAccepted;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public void SetAuthenticationCompany(int authenticationCompanyId,
                                         decimal cost)
    {
        AuthenticationCompanies ??= [];

        PrivateSigningAuthenticationCompany authenticationCompany
            = AuthenticationCompanies.SingleOrDefault(company => company.AuthenticationCompanyId == authenticationCompanyId);

        if (authenticationCompany == null)
        {
            AuthenticationCompanies.Add(new PrivateSigningAuthenticationCompany(authenticationCompanyId,
                                                                                cost,
                                                                                Id));                                        

            return;
        }

        authenticationCompany.Set(cost);
    }

    public void SetPaymentOption(
        int privateSigningPaymentOptionId,
        int privateSigningPaymentMethodId,
        string paymentMethodHandle)
    {
        PaymentOptions ??= [];

        PrivateSigningPaymentOption privateSigningPaymentOption
            = PaymentOptions.SingleOrDefault(option => option.Id == privateSigningPaymentOptionId);

        if (privateSigningPaymentOption == null)
        {
            PaymentOptions.Add(new PrivateSigningPaymentOption(Id, privateSigningPaymentMethodId, paymentMethodHandle));

            return;
        }

        privateSigningPaymentOption.Set(Id, privateSigningPaymentMethodId, paymentMethodHandle);
    }

    public void SetPerson(bool allowInscriptions,
                          decimal? inscriptionCost,
                          int privateSigningPersonId,
                          string note,
                          int personId,
                          string promoterImageFileName,
                          DateOnly? signingDate,
                          int statusId,
                          int? spotsAvailable,
                          int? spotsConfirmed)
    {
        People ??= [];

        PrivateSigningPerson privateSigningPerson
            = People.SingleOrDefault(item => item.Id == privateSigningPersonId);

        if (privateSigningPerson == null)
        {      
            People.Add(new PrivateSigningPerson(allowInscriptions,
                                                inscriptionCost,
                                                note,
                                                personId,
                                                Id,
                                                promoterImageFileName,
                                                signingDate,
                                                statusId,
                                                spotsAvailable,
                                                spotsConfirmed));

            return;
        }

        privateSigningPerson.Set(allowInscriptions,
                                 inscriptionCost,
                                 note,
                                 promoterImageFileName,
                                 signingDate,
                                 statusId,
                                 spotsAvailable,
                                 spotsConfirmed);
    }

    public void SetProvidedItem(int privateSigningPromoterProvidedItemId,
                                decimal cost,
                                int itemTypeId,
                                int promoterId,
                                decimal? shippingCost)
    {
        PromoterProvidedItems ??= [];

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
