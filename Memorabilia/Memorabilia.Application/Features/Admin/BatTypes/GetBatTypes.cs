using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatTypes() : IQuery<BatTypesViewModel>
{
    public class Handler : QueryHandler<GetBatTypes, BatTypesViewModel>
    {
        private readonly IDomainRepository<BatType> _batTypeRepository;

        public Handler(IDomainRepository<BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<BatTypesViewModel> Handle(GetBatTypes query)
        {
            return new BatTypesViewModel(await _batTypeRepository.GetAll());
        }
    }
}
