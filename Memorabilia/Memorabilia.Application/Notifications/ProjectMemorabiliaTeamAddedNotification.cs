namespace Memorabilia.Application.Notifications;

public record ProjectMemorabiliaTeamAddedNotification(int ProjectId,
                                                      int TeamId,
                                                      int? Rank) 
    : INotification
{
}
