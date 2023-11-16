namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class SaveJerseyNumber
{
    public class Handler(IMemorabiliaItemRepository memorabiliaRepository) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.Memorabilia memorabilia = await memorabiliaRepository.Get(command.MemorabiliaId);

            memorabilia.SetJerseyNumber(command.Number,
                                        command.PersonId, 
                                        command.SportId, 
                                        command.TeamId);

            await memorabiliaRepository.Update(memorabilia);
        }
    }

    public class Command(JerseyNumberEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int MemorabiliaId 
            => editModel.MemorabiliaId;

        public int? Number 
            => editModel.Number;

        public int? PersonId 
            => editModel.Person?.Id.ToNullableInt() ?? null;

        public int? SportId 
            => editModel.SportId.ToNullableInt();

        public int? TeamId 
            => editModel.Team?.Id.ToNullableInt() ?? null;
    }
}
