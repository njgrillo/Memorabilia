using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FootballTypes;

public record GetFootballType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetFootballType, DomainModel>
    {
        private readonly IDomainRepository<FootballType> _footballTypeRepository;

        public Handler(IDomainRepository<FootballType> footballTypeRepository)
        {
            _footballTypeRepository = footballTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetFootballType query)
        {
            return new DomainModel(await _footballTypeRepository.Get(query.Id));
        }
    }
}
