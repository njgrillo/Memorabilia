﻿using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Memorabilia.Shoe
{
    public class GetShoe
    {
        public class Handler : QueryHandler<Query, ShoeViewModel>
        {
            private readonly IMemorabiliaRepository _memorabiliaRepository;

            public Handler(IMemorabiliaRepository memorabiliaRepository)
            {
                _memorabiliaRepository = memorabiliaRepository;
            }

            protected override async Task<ShoeViewModel> Handle(Query query)
            {
                return new ShoeViewModel(await _memorabiliaRepository.Get(query.MemorabiliaId).ConfigureAwait(false));
            }
        }

        public class Query : MemorabiliaQuery, IQuery<ShoeViewModel>
        {
            public Query(int memorabiliaId) : base(memorabiliaId) { }
        }
    }
}
