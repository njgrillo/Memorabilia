namespace Memorabilia.Application.Features.Memorabilia.Document;

public class SaveDocument
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetDocument(command.PersonIds,
                                    command.SizeId,
                                    command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(DocumentEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
