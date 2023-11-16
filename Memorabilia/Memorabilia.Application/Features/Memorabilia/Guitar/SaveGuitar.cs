namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class SaveGuitar
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetGuitar(command.BrandId,
                                  command.PersonIds,
                                  command.SizeId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(GuitarEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;
    }
}
