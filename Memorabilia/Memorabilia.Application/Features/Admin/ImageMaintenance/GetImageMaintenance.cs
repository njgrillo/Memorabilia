namespace Memorabilia.Application.Features.Admin.ImageMaintenance;

public record GetImageMaintenance(string MemorabiliaImageRootPath, 
                                  string PersonImageRootPath) 
    : IQuery<ImageMaintenanceModel>
{
    public class Handler : QueryHandler<GetImageMaintenance, ImageMaintenanceModel>
    {
        private readonly IAutographImageRepository _autographImageRepository;
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;
        private readonly IDomainRepository<Entity.Person> _personRepository;

        public Handler(IAutographImageRepository autographImageRepository,
                       IMemorabiliaImageRepository memorabiliaImageRepository, 
                       IDomainRepository<Entity.Person> personRepository)
        {
            _autographImageRepository = autographImageRepository;
            _memorabiliaImageRepository = memorabiliaImageRepository;
            _personRepository = personRepository;
        }

        protected override async Task<ImageMaintenanceModel> Handle(GetImageMaintenance query)
        {
            IEnumerable<Entity.AutographImage> autographImages = await _autographImageRepository.GetAll();
            IEnumerable<Entity.MemorabiliaImage> memorabiliaImages = await _memorabiliaImageRepository.GetAll();
            IEnumerable<Entity.Person> people = await _personRepository.GetAll();   

            return new ImageMaintenanceModel(query.MemorabiliaImageRootPath, 
                                             query.PersonImageRootPath, 
                                             autographImages, 
                                             memorabiliaImages, 
                                             people);
        }
    }
}
