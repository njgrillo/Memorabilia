namespace Memorabilia.Application.Features.Admin.Colleges;

public record GetCollege(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetCollege, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.College> _collegeRepository;

        public Handler(IDomainRepository<Entity.College> collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetCollege query)
            => await _collegeRepository.Get(query.Id);
    }
}
