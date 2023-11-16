namespace Memorabilia.Application.Features.Memorabilia.Poster;

public class SavePoster
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPoster(command.BrandId,
                                  command.Matted,
                                  command.OrientationId,
                                  command.PersonIds,
                                  command.SizeId,
                                  command.SportIds,
                                  command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(PosterEditModel editModel) 
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

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
