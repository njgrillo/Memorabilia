using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public record GetSize(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetSize, DomainModel>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<DomainModel> Handle(GetSize query)
        {
            return new DomainModel(await _sizeRepository.Get(query.Id));
        }
    }
}
