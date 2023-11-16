namespace Memorabilia.Application.Features.Memorabilia.Magazine;

public class SaveMagazine
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetMagazine(command.BrandId,
                                    command.Date,
                                    command.Framed,
                                    command.Matted,
                                    command.OrientationId,
                                    command.PersonIds,
                                    command.SizeId,
                                    command.SportIds,
                                    command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(MagazineEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public DateTime? Date 
            => editModel.Date;

        public bool Framed 
            => editModel.Framed;

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
