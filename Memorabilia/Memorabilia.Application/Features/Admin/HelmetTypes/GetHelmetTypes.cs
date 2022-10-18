using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetTypes() : IQuery<HelmetTypesViewModel>
{
    public class Handler : QueryHandler<GetHelmetTypes, HelmetTypesViewModel>
    {
        private readonly IDomainRepository<HelmetType> _helmetTypeRepository;

        public Handler(IDomainRepository<HelmetType> helmetTypeRepository)
        {
            _helmetTypeRepository = helmetTypeRepository;
        }

        protected override async Task<HelmetTypesViewModel> Handle(GetHelmetTypes query)
        {
            return new HelmetTypesViewModel(await _helmetTypeRepository.GetAll());
        }
    }
}
