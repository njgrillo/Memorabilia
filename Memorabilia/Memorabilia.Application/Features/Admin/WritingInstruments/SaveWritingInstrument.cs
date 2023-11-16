namespace Memorabilia.Application.Features.Admin.WritingInstruments;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveWritingInstrument(DomainEditModel WritingInstrument) : ICommand
{
    public class Handler(IDomainRepository<Entity.WritingInstrument> writingInstrumentRepository) 
        : CommandHandler<SaveWritingInstrument>
    {
        protected override async Task Handle(SaveWritingInstrument request)
        {
            Entity.WritingInstrument writingInstrument;

            if (request.WritingInstrument.IsNew)
            {
                writingInstrument = new Entity.WritingInstrument(request.WritingInstrument.Name, 
                                                                 request.WritingInstrument.Abbreviation);

                await writingInstrumentRepository.Add(writingInstrument);

                return;
            }

            writingInstrument = await writingInstrumentRepository.Get(request.WritingInstrument.Id);

            if (request.WritingInstrument.IsDeleted)
            {
                await writingInstrumentRepository.Delete(writingInstrument);

                return;
            }

            writingInstrument.Set(request.WritingInstrument.Name, 
                                  request.WritingInstrument.Abbreviation);

            await writingInstrumentRepository.Update(writingInstrument);
        }
    }
}
