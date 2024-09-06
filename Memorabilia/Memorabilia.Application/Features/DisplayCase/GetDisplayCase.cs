namespace Memorabilia.Application.Features.DisplayCase;

public record GetDisplayCase(int Id) : IQuery<Entity.DisplayCase>
{
    public class Handler(IDisplayCaseRepository displayCaseRepository)
        : QueryHandler<GetDisplayCase, Entity.DisplayCase>
    {
        protected override async Task<Entity.DisplayCase> Handle(GetDisplayCase query)
            => await displayCaseRepository.Get(query.Id);
    }
}
