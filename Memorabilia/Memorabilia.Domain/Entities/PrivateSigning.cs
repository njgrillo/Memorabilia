using Memorabilia.Domain.Constants;

namespace Memorabilia.Domain.Entities;

public class PrivateSigning : Framework.Library.Domain.Entity.DomainEntity
{
    public PrivateSigning() { }

    public PrivateSigning(DateTime createdDate,
                          int createdUserId,
                          string note,
                          bool selfAddressedStampedEnvelopeAccepted,
                          DateTime signingDate,
                          DateTime submissionDeadlineDate)
    {
        CreatedDate = createdDate;
        CreatedUserId = createdUserId;
        Note = note;
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
        Note = privateSigning.Note;
        People = privateSigning.People;
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

    public virtual List<PrivateSigningPromoterProvidedItem> PromoterProvidedItems { get; private set; }

    public bool SelfAddressedStampedEnvelopeAccepted { get; private set; }

    public DateTime SigningDate { get; private set; }

    public DateTime SubmissionDeadlineDate { get; private set; }

    public void Set(string note,
                    bool selfAddressedStampedEnvelopeAccepted,    
                    DateTime signingDate,
                    DateTime submissionDeadlineDate)
    {
        Note = note;
        SelfAddressedStampedEnvelopeAccepted = selfAddressedStampedEnvelopeAccepted;
        SigningDate = signingDate;
        SubmissionDeadlineDate = submissionDeadlineDate;
    }

    public void SetAuthenticationCompany(int privateSigningAuthenticationCompanyId,
                                         int authenticationCompanyId,
                                         decimal cost)
    {
        PrivateSigningAuthenticationCompany authenticationCompany
            = AuthenticationCompanies.SingleOrDefault(company => company.Id == privateSigningAuthenticationCompanyId);

        if (authenticationCompany == null)
        {
            AuthenticationCompanies ??= new();

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
        PrivateSigningPerson privateSigningPerson
            = People.SingleOrDefault(person => person.Id == privateSigningPersonId);

        if (privateSigningPerson == null)
        {
            People ??= new();

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
}
