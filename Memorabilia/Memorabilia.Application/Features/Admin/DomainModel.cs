namespace Memorabilia.Application.Features.Admin;

public class DomainModel
{
    private readonly Entity.DomainEntity _domainEntity;

    public DomainModel() { }

    public DomainModel(Entity.DomainEntity domainEntity)
    {
        _domainEntity = domainEntity;
    }

    public string Abbreviation 
        => _domainEntity.Abbreviation;

    public int Id 
        => _domainEntity.Id;

    public string Name 
        => _domainEntity.Name;
}
