using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetHelmetType, DomainModel>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetHelmetType query)
        {
            return new DomainModel(await _helmetTypeRepository.Get(query.Id));
        }
    }
}
