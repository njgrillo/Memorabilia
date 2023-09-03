namespace Memorabilia.Application.Notifications;

public record ProjectPersonAddedNotification(int ProjectId,
    int PersonId, 
    int? Rank) : INotification
{
}
