namespace Memorabilia.Application.Features.Memorabilia.PlayingCard;

public class SavePlayingCard 
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetPlayingCard(command.PersonId,
                                       command.SizeId,
                                       command.SportId,
                                       command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(PlayingCardEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int SizeId 
            => editModel.SizeId;

        public int? SportId
            => editModel.SportId.ToNullableInt();

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
