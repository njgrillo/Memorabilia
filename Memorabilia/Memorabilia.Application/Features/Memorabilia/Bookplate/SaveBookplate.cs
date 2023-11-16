namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class SaveBookplate
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetBookplate(command.PersonId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(BookplateEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId
            => editModel.Person?
                        .Id
                        .ToNullableInt() ?? null;
    }
}
