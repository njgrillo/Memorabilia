using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetJerseyStyleType, DomainModel>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetJerseyStyleType query)
        {
            return new DomainModel(await _jerseyStyleTypeRepository.Get(query.Id));
        }
    }
}
