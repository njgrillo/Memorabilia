using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSizes() : IQuery<SizesViewModel>
{
    public class Handler : QueryHandler<GetSizes, SizesViewModel>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<SizesViewModel> Handle(GetSizes query)
        {
            return new SizesViewModel(await _sizeRepository.GetAll());
        }
    }
}
