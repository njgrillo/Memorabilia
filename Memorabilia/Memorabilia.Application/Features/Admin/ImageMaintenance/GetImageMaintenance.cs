using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ImageMaintenance;

public record GetImageMaintenance(string MemorabiliaImageRootPath, string PersonImageRootPath) : IQuery<ImageMaintenanceViewModel>
{
    public class Handler : QueryHandler<GetImageMaintenance, ImageMaintenanceViewModel>
    {
        private readonly IAutographImageRepository _autographImageRepository;
        private readonly IMemorabiliaImageRepository _memorabiliaImageRepository;
        private readonly IDomainRepository<Person> _personRepository;

        public Handler(IAutographImageRepository autographImageRepository,
                       IMemorabiliaImageRepository memorabiliaImageRepository, 
                       IDomainRepository<Person> personRepository)
        {
            _autographImageRepository = autographImageRepository;
            _memorabiliaImageRepository = memorabiliaImageRepository;
            _personRepository = personRepository;
        }

        protected override async Task<ImageMaintenanceViewModel> Handle(GetImageMaintenance query)
        {
            var autographImages = await _autographImageRepository.GetAll();
            var memorabiliaImages = await _memorabiliaImageRepository.GetAll();
            var people = await _personRepository.GetAll();   

            return new ImageMaintenanceViewModel(query.MemorabiliaImageRootPath, 
                                                 query.PersonImageRootPath, 
                                                 autographImages, 
                                                 memorabiliaImages, 
                                                 people);
        }
    }
}
