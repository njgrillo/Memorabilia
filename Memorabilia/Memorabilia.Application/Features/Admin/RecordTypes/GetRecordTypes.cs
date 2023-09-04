namespace Memorabilia.Application.Features.Admin.RecordTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetRecordTypes() : IQuery<Entity.RecordType[]>
{
    public class Handler : QueryHandler<GetRecordTypes, Entity.RecordType[]>
    {
        private readonly IDomainRepository<Entity.RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<Entity.RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task<Entity.RecordType[]> Handle(GetRecordTypes query)
            => await _recordTypeRepository.GetAll();
    }
}
