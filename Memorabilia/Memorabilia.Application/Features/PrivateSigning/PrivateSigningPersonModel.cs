namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonModel
{
    private readonly Entity.PrivateSigningPerson _privateSigningPerson;

    public PrivateSigningPersonModel() { }

    public PrivateSigningPersonModel(Entity.PrivateSigningPerson privateSigningPerson)
    {
        _privateSigningPerson = privateSigningPerson;
    }

    public bool AllowInscriptions
        => _privateSigningPerson.AllowInscriptions;

    public int CreatedUserId
        => _privateSigningPerson.PrivateSigning.CreatedUserId;

    public PrivateSigningPersonExcludeItemTypeModel[] ExcludedItems
        => _privateSigningPerson.ExcludedItems
                                .Select(item => new PrivateSigningPersonExcludeItemTypeModel(item))
                                .ToArray();

    public int Id
        => _privateSigningPerson.Id;

    public decimal? InscriptionCost
        => _privateSigningPerson.InscriptionCost;

    public string Note
        => _privateSigningPerson.Note;

    public PersonModel Person
        => new(_privateSigningPerson.Person);

    public PrivateSigningPersonDetailModel[] Pricing
        => _privateSigningPerson.Pricing
                                .Select(price => new PrivateSigningPersonDetailModel(price))
                                .ToArray();

    public int PrivateSigningId
        => _privateSigningPerson.PrivateSigningId;

    public string PromoterImageFileName
        => _privateSigningPerson.PromoterImageFileName;

    public int? SpotsAvailable
        => _privateSigningPerson.SpotsAvailable;

    public int? SpotsConfirmed
        => _privateSigningPerson.SpotsConfirmed;

    public int? SpotsReserved
        => _privateSigningPerson.SpotsReserved;
}
