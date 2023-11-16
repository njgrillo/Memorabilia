namespace Memorabilia.Application.Features.Memorabilia.Card;

public class SaveCard
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetCard(command.BrandId,
                                command.Custom,
                                command.LevelTypeId,
                                command.Licensed,
                                command.OrientationId,
                                command.PersonIds,
                                command.SizeId,
                                command.SportIds,
                                command.TeamIds,
                                command.Year);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(CardEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int BrandId 
            => editModel.BrandId;

        public bool Custom 
            => editModel.Custom;

        public int LevelTypeId 
            => editModel.LevelTypeId;

        public bool Licensed 
            => editModel.Licensed;

        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int OrientationId 
            => editModel.OrientationId;

        public int[] PersonIds 
            => editModel.People.ActiveIds();

        public int SizeId 
            => editModel.SizeId;

        public int[] SportIds 
            => editModel.SportIds
                        .ToArray();

        public int[] TeamIds 
            => editModel.Teams.ActiveIds();

        public int? Year 
            => editModel.Year;
    }
}
