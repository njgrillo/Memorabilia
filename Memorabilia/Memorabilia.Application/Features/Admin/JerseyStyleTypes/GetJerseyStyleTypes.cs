namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleTypes() : IQuery<Entity.JerseyStyleType[]>
{
    public class Handler : QueryHandler<GetJerseyStyleTypes, Entity.JerseyStyleType[]>
    {
        private readonly IDomainRepository<Entity.JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<Entity.JerseyStyleType[]> Handle(GetJerseyStyleTypes query)
            => await _jerseyStyleTypeRepository.GetAll();
    }
}
