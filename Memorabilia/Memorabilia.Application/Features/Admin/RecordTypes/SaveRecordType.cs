using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.RecordTypes;

public record SaveRecordType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveRecordType>
    {
        private readonly IDomainRepository<RecordType> _recordTypeRepository;

        public Handler(IDomainRepository<RecordType> recordTypeRepository)
        {
            _recordTypeRepository = recordTypeRepository;
        }

        protected override async Task Handle(SaveRecordType request)
        {
            RecordType recordType;

            if (request.ViewModel.IsNew)
            {
                recordType = new RecordType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _recordTypeRepository.Add(recordType);

                return;
            }

            recordType = await _recordTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _recordTypeRepository.Delete(recordType);

                return;
            }

            recordType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _recordTypeRepository.Update(recordType);
        }
    }
}
