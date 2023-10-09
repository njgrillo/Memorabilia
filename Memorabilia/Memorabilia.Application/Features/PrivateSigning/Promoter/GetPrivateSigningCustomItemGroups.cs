namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPrivateSigningCustomItemGroups() : IQuery<Entity.PrivateSigningCustomItemGroup[]>
{
    public class Handler : QueryHandler<GetPrivateSigningCustomItemGroups, Entity.PrivateSigningCustomItemGroup[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IPrivateSigningCustomItemGroupRepository _privateSigningCustomItemGroupRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IPrivateSigningCustomItemGroupRepository privateSigningCustomItemGroupRepository)
        {
            _applicationStateService = applicationStateService;
            _privateSigningCustomItemGroupRepository = privateSigningCustomItemGroupRepository;            
        }

        protected override async Task<Entity.PrivateSigningCustomItemGroup[]> Handle(GetPrivateSigningCustomItemGroups query)
            => (await _privateSigningCustomItemGroupRepository.GetAll(_applicationStateService.CurrentUser.Id))
                   .OrderBy(collection => collection.Name)
                   .ToArray();
    }
}
