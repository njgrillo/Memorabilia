﻿namespace Memorabilia.Application.Features.Collection;

[AuthorizeByPermission(Enum.Permission.Collection)]
public record GetCollection(int Id) : IQuery<Entity.Collection>
{
    public class Handler : QueryHandler<GetCollection, Entity.Collection>
    {
        private readonly ICollectionRepository _collectionRepository;

        public Handler(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        protected override async Task<Entity.Collection> Handle(GetCollection query)
            => await _collectionRepository.Get(query.Id);
    }
}
