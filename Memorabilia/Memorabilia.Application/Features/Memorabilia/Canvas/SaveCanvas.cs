namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class SaveCanvas
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetCanvas(command.BrandId,
                                  command.Matted,
                                  command.OrientationId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.Stretched,
                                  command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(CanvasEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public bool Matted 
            => editModel.Matted;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int OrientationId 
            => editModel.OrientationId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int[] SportIds 
            => editModel.SportIds.ToArray();

        public bool Stretched 
            => editModel.Stretched;

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
