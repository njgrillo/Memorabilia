namespace Memorabilia.Blazor.Services.Interfaces;

public interface IApplicationStateService
{
    Entity.User CurrentUser { get; set; }

    Task Load(int userId);
}
