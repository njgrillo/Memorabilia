using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetBaseballType, DomainModel>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetBaseballType query)
        {
            return new DomainModel(await _baseballTypeRepository.Get(query.Id));
        }
    }
}
