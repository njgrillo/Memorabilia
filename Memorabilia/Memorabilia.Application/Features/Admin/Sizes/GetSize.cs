using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSize(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetSize, DomainViewModel>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetSize query)
        {
            return new DomainViewModel(await _sizeRepository.Get(query.Id));
        }
    }
}
