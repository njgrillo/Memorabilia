namespace Memorabilia.Application.Features.Admin.RecordTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveRecordType(DomainEditModel RecordType) : ICommand
{
    public class Handler(IDomainRepository<Entity.RecordType> recordTypeRepository) 
        : CommandHandler<SaveRecordType>
    {
        protected override async Task Handle(SaveRecordType request)
        {
            Entity.RecordType recordType;

            if (request.RecordType.IsNew)
            {
                recordType = new Entity.RecordType(request.RecordType.Name, 
                                                   request.RecordType.Abbreviation);

                await recordTypeRepository.Add(recordType);

                return;
            }

            recordType = await recordTypeRepository.Get(request.RecordType.Id);

            if (request.RecordType.IsDeleted)
            {
                await recordTypeRepository.Delete(recordType);

                return;
            }

            recordType.Set(request.RecordType.Name, 
                           request.RecordType.Abbreviation);

            await recordTypeRepository.Update(recordType);
        }
    }
}
