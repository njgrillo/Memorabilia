namespace Memorabilia.Application.Features.Forum;

public record UpdateForumEntryRank(int ForumEntryId, int UserId, bool IncreaseRank)
    : ICommand
{
    public class Handler : CommandHandler<UpdateForumEntryRank>
    {
        private readonly IForumEntryRepository _forumEntryRepository;

        public Handler(IForumEntryRepository forumEntryRepository)
        {
            _forumEntryRepository = forumEntryRepository;
        }

        protected override async Task Handle(UpdateForumEntryRank command)
        {
            Entity.ForumEntry forumEntry
                = await _forumEntryRepository.Get(command.ForumEntryId);

            if (command.IncreaseRank)
                forumEntry.IncreaseRank(command.UserId);
            else
                forumEntry.DecreaseRank(command.UserId);

            await _forumEntryRepository.Update(forumEntry);
        }
    }
}
