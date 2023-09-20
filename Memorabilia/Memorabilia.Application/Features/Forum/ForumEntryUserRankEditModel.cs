namespace Memorabilia.Application.Features.Forum;

public class ForumEntryUserRankEditModel : EditModel
{
	public ForumEntryUserRankEditModel() { }

	public ForumEntryUserRankEditModel(int forumEntryId, int userId)
	{
        ForumEntryId = forumEntryId;
        UserId = userId;
    }

	public ForumEntryUserRankEditModel(Entity.ForumEntryUserRank forumEntryUserRank)
	{
		ForumEntryId = forumEntryUserRank.ForumEntryId;
		Id = forumEntryUserRank.Id;
		UserId = forumEntryUserRank.UserId;
	}

	public int ForumEntryId { get; set; }

	public int UserId { get; set; }
}
