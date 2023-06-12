namespace Memorabilia.Application.Features.Admin.PhotoTypes;

public record GetPhotoType(int Id) : IQuery<Entity.PhotoType>
{
    public class Handler : QueryHandler<GetPhotoType, Entity.PhotoType>
    {
        private readonly IDomainRepository<Entity.PhotoType> _photoTypeRepository;

        public Handler(IDomainRepository<Entity.PhotoType> photoTypeRepository)
        {
            _photoTypeRepository = photoTypeRepository;
        }

        protected override async Task<Entity.PhotoType> Handle(GetPhotoType query)
            => await _photoTypeRepository.Get(query.Id);
    }
}
