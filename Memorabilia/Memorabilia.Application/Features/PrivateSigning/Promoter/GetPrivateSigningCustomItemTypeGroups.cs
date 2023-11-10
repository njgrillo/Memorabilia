namespace Memorabilia.Application.Features.PrivateSigning.Promoter;

[AuthorizeByPermission(Enum.Permission.PrivateSigning)]
public record GetPrivateSigningCustomItemTypeGroups() : IQuery<Entity.PrivateSigningCustomItemTypeGroup[]>
{
    public class Handler : QueryHandler<GetPrivateSigningCustomItemTypeGroups, Entity.PrivateSigningCustomItemTypeGroup[]>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IPrivateSigningCustomItemTypeGroupRepository _privateSigningCustomItemTypeGroupRepository;

        public Handler(IApplicationStateService applicationStateService,
                       IPrivateSigningCustomItemTypeGroupRepository privateSigningCustomItemTypeGroupRepository)
        {
            _applicationStateService = applicationStateService;
            _privateSigningCustomItemTypeGroupRepository = privateSigningCustomItemTypeGroupRepository;
        }

        protected override async Task<Entity.PrivateSigningCustomItemTypeGroup[]> Handle(GetPrivateSigningCustomItemTypeGroups query)
            => (await _privateSigningCustomItemTypeGroupRepository.GetAll(_applicationStateService.CurrentUser.Id))
                   .ToArray();
    }
}
