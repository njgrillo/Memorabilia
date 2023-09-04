namespace Memorabilia.Application.Features.Admin.RecordTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveRecordType(DomainEditModel RecordType) : ICommand
{
    public class Handler : CommandHandler<SaveRecordType>
    {
        private readonly IDomainRepository<Entity.RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<Entity.RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task Handle(SaveRecordType request)
        {
            Entity.RecordType recordType;

            if (request.RecordType.IsNew)
            {
                recordType = new Entity.RecordType(request.RecordType.Name, 
                                                   request.RecordType.Abbreviation);

                await _recordTypeRepository.Add(recordType);

                return;
            }

            recordType = await _recordTypeRepository.Get(request.RecordType.Id);

            if (request.RecordType.IsDeleted)
            {
                await _recordTypeRepository.Delete(recordType);

                return;
            }

            recordType.Set(request.RecordType.Name, 
                           request.RecordType.Abbreviation);

            await _recordTypeRepository.Update(recordType);
        }
    }
}
