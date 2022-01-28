namespace Memorabilia.Application.Features.Admin
{
    public class DomainViewModel
    {
        private readonly Domain.Entities.DomainEntity _domainEntity;

        public DomainViewModel() { }

        public DomainViewModel(Domain.Entities.DomainEntity domainEntity)
        {
            _domainEntity = domainEntity;
        }

        public string Abbreviation => _domainEntity.Abbreviation;

        public int Id => _domainEntity.Id;

        public string Name => _domainEntity.Name;
    }
}
