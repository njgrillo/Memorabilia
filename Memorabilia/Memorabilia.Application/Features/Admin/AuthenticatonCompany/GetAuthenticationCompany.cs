﻿using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.AuthenticationCompany
{
    public class GetAuthenticationCompany
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IAuthenticationCompanyRepository _authenticationCompanyRepository;

            public Handler(IAuthenticationCompanyRepository authenticationCompanyRepository)
            {
                _authenticationCompanyRepository = authenticationCompanyRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var authenticationCompany = await _authenticationCompanyRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(authenticationCompany);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
