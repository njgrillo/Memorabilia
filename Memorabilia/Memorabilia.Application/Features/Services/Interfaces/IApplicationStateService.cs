namespace Memorabilia.Application.Features.Services.Interfaces;

public interface IApplicationStateService
{
    Entity.User CurrentUser { get; set; }

    Task Load(int userId);

    void Set(Entity.User user);
}
