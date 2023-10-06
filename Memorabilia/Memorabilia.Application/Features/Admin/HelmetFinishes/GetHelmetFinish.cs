namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinish(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetHelmetFinish, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetHelmetFinish query)
            => await _helmetFinishRepository.Get(query.Id);
    }
}
