namespace Memorabilia.Application.Features.DisplayCases;

[AuthorizeByPermission(Enum.Permission.DisplayCases)]
public record GetDisplayCase(int Id) : IQuery<Entity.DisplayCase>
{
    public class Handler(IDisplayCaseRepository displayCaseRepository)
        : QueryHandler<GetDisplayCase, Entity.DisplayCase>
    {
        protected override async Task<Entity.DisplayCase> Handle(GetDisplayCase query)
            => await displayCaseRepository.Get(query.Id);
    }
}
