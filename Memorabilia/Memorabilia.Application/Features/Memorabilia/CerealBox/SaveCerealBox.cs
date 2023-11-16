namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class SaveCerealBox
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetCerealBox(command.BrandId,
                                     command.CerealTypeId,
                                     command.LevelTypeId,
                                     command.PersonIds,
                                     command.SportIds,
                                     command.TeamIds);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(CerealBoxEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public int? CerealTypeId 
            => editModel.CerealTypeId.ToNullableInt();

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int[] SportIds 
            => editModel.SportIds.ToArray();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();
    }
}
