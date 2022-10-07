﻿namespace Memorabilia.Application.Features.Admin.People;

public class GetPeople
{
    public class Handler : QueryHandler<Query, PeopleViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PeopleViewModel> Handle(Query query)
        {
            return new PeopleViewModel(await _personRepository.GetAll(query.SportId));
        }
    }

    public class Query : IQuery<PeopleViewModel> 
    { 
        public Query(int? sportId = null)
        {
            SportId = sportId;
        }

        public int? SportId { get; }
    }
}
