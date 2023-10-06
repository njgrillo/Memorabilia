namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetPhotoType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetPhotoType query)
            => await _photoTypeRepository.Get(query.Id);
    }
}
