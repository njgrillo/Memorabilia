﻿using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes
{
    public class GetItemTypeSize
    {
        public class Handler : QueryHandler<Query, ItemTypeSizeViewModel>
        {
            private readonly IItemTypeSizeRepository _itemTypeSizeRepository;

            public Handler(IItemTypeSizeRepository itemTypeSizeRepository)
            {
                _itemTypeSizeRepository = itemTypeSizeRepository;
            }

            protected override async Task<ItemTypeSizeViewModel> Handle(Query query)
            {
                return new ItemTypeSizeViewModel(await _itemTypeSizeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ItemTypeSizeViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
