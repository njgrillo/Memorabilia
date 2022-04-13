using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AccomplishmentTypes
{
    public class GetAccomplishmentTypes
    {
        public class Handler : QueryHandler<Query, AccomplishmentTypesViewModel>
        {
            private readonly IAccomplishmentTypeRepository _accomplishmentTypeRepository;

            public Handler(IAccomplishmentTypeRepository accomplishmentTypeRepository)
            {
                _accomplishmentTypeRepository = accomplishmentTypeRepository;
            }

            protected override async Task<AccomplishmentTypesViewModel> Handle(Query query)
            {
                return new AccomplishmentTypesViewModel(await _accomplishmentTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AccomplishmentTypesViewModel> { }
    }
}
