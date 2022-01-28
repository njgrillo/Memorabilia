using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class GetBaseball
    {
        public class Handler : QueryHandler<Query, BaseballViewModel>
        {
            private readonly IItemTypeBrandRepository _brandRepository;
            private readonly ICommissionerRepository _commissionerRepository;
            private readonly IMemorabiliaRepository _memorabiliaRepository;
            private readonly IPersonRepository _personRepository;
            private readonly IItemTypeSizeRepository _sizeRepository;
            private readonly ITeamRepository _teamRepository;

            public Handler(IItemTypeBrandRepository brandRepository, 
                           ICommissionerRepository commissionerRepository,
                           IMemorabiliaRepository memorabiliaRepository,
                           IPersonRepository personRepository,
                           IItemTypeSizeRepository sizeRepository,
                           ITeamRepository teamRepository)
            {
                _brandRepository = brandRepository;
                _commissionerRepository = commissionerRepository;
                _memorabiliaRepository = memorabiliaRepository;
                _personRepository = personRepository;
                _sizeRepository = sizeRepository;
                _teamRepository = teamRepository;
            }

            protected override async Task<BaseballViewModel> Handle(Query query)
            {                
                var memorabilia = await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false);

                var itemTypeId = Domain.Constants.ItemType.Baseball.Id;
                var brands = await _brandRepository.GetAll(itemTypeId).ConfigureAwait(false);
                var commissioners = await _commissionerRepository.GetAll(Domain.Constants.Sport.Baseball.Id).ConfigureAwait(false);
                var people = await _personRepository.GetAll().ConfigureAwait(false);
                var sizes = await _sizeRepository.GetAll(itemTypeId).ConfigureAwait(false);   
                var teams = await _teamRepository.GetAll().ConfigureAwait(false);

                var viewModel = new BaseballViewModel(memorabilia, brands, commissioners, people, sizes, teams);

                return viewModel;
            }
        }

        public class Query : IQuery<BaseballViewModel>
        {
            public Query(int memorabiliaId)
            {
                MemorabiliaId = memorabiliaId;
            }

            public int MemorabiliaId { get; }
        }
    }
}
