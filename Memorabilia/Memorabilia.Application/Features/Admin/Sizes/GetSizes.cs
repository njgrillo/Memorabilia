using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public class GetSizes
{
    public class Handler : QueryHandler<Query, SizesViewModel>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<SizesViewModel> Handle(Query query)
        {
            return new SizesViewModel(await _sizeRepository.GetAll());
        }
    }

    public class Query : IQuery<SizesViewModel> { }
}
