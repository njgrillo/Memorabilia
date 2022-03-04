﻿using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Person
{
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
                var persons = (await _personRepository.GetAll(query.SportId).ConfigureAwait(false)).OrderBy(person => person.DisplayName);

                var viewModel = new PeopleViewModel(persons);

                return viewModel;
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
}
