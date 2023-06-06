using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record GetLevelType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetLevelType, DomainModel>
    {
        private readonly IDomainRepository<LevelType> _levelTypeRepository;

        public Handler(IDomainRepository<LevelType> levelTypeRepository)
        {
            _levelTypeRepository = levelTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetLevelType query)
        {
            return new DomainModel(await _levelTypeRepository.Get(query.Id));
        }
    }
}
