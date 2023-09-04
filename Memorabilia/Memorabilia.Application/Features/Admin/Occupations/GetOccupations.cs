﻿namespace Memorabilia.Application.Features.Admin.Occupations;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetOccupations() : IQuery<Entity.Occupation[]>
{
    public class Handler : QueryHandler<GetOccupations, Entity.Occupation[]>
    {
        private readonly IDomainRepository<Entity.Occupation> _occupationRepository;

        public Handler(IDomainRepository<Entity.Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<Entity.Occupation[]> Handle(GetOccupations query)
            => await _occupationRepository.GetAll();
    }
}
