namespace Memorabilia.Application.Features.Admin.WritingInstruments;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveWritingInstrument(DomainEditModel WritingInstrument) : ICommand
{
    public class Handler : CommandHandler<SaveWritingInstrument>
    {
        private readonly IDomainRepository<Entity.WritingInstrument> _writingInstrumentRepository;

        public Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository)
        {
            _writingInstrumentRepository = writingInstrumentRepository;
        }

        protected override async Task Handle(SaveWritingInstrument request)
        {
            Entity.WritingInstrument writingInstrument;

            if (request.WritingInstrument.IsNew)
            {
                writingInstrument = new Entity.WritingInstrument(request.WritingInstrument.Name, 
                                                                 request.WritingInstrument.Abbreviation);

                await _writingInstrumentRepository.Add(writingInstrument);

                return;
            }

            writingInstrument = await _writingInstrumentRepository.Get(request.WritingInstrument.Id);

            if (request.WritingInstrument.IsDeleted)
            {
                await _writingInstrumentRepository.Delete(writingInstrument);

                return;
            }

            writingInstrument.Set(request.WritingInstrument.Name, 
                                  request.WritingInstrument.Abbreviation);

            await _writingInstrumentRepository.Update(writingInstrument);
        }
    }
}
