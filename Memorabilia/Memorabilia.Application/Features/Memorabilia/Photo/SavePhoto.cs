namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class SavePhoto
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPhoto(command.BrandId,
                                 command.Matted,
                                 command.OrientationId,
                                 command.PersonIds,
                                 command.PhotoTypeId,
                                 command.SizeId,
                                 command.SportIds,
                                 command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(PhotoEditModel editModel) 
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

        public int? PhotoTypeId 
            => editModel.PhotoTypeId.ToNullableInt();

        public int SizeId 
            => editModel.SizeId;

        public int[] SportIds 
            => editModel.SportIds.ToArray();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
