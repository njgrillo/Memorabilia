namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class SaveDrum
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetDrum(command.BrandId, command.PersonIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(DrumEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();
    }
}
