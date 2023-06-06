using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetBatType, DomainModel>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetBatType query)
        {
            return new DomainModel(await _batTypeRepository.Get(query.Id));
        }
    }
}
