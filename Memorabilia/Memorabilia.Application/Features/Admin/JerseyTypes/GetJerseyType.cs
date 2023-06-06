using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetJerseyType, DomainModel>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetJerseyType query)
        {
            return new DomainModel(await _jerseyTypeRepository.Get(query.Id));
        }
    }
}
