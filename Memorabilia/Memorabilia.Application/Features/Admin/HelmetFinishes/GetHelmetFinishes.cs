namespace Memorabilia.Application.Features.Admin.HelmetFinishes;

public record GetHelmetFinishes() : IQuery<Entity.HelmetFinish[]>
{
    public class Handler : QueryHandler<GetHelmetFinishes, Entity.HelmetFinish[]>
    {
        private readonly IDomainRepository<Entity.HelmetFinish> _helmetFinishRepository;

        public Handler(IDomainRepository<Entity.HelmetFinish> helmetFinishRepository)
        {
            _helmetFinishRepository = helmetFinishRepository;
        }

        protected override async Task<Entity.HelmetFinish[]> Handle(GetHelmetFinishes query)
            => (await _helmetFinishRepository.GetAll())
                    .ToArray();
    }
}
