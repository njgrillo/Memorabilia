﻿namespace Memorabilia.Application.Features.Forum;

public class ForumEntryEditModel : EditModel
{
	public ForumEntryEditModel() { }

	public ForumEntryEditModel(int createdByUserId)
	{
		CreatedByUserId = createdByUserId;
		CreatedDate = DateTime.UtcNow;
	}

	public ForumEntryEditModel(Entity.ForumEntry forumEntry)
	{
		CreatedByUser = forumEntry.CreatedByUser;
		CreatedByUserId = forumEntry.CreatedByUserId;
		CreatedDate = forumEntry.CreatedDate;
		ForumTopicId = forumEntry.ForumTopicId;
		Id = forumEntry.Id;
		Message = forumEntry.Message;
		ModifiedDate = forumEntry.ModifiedDate;
		Rank = forumEntry.Rank;
		RankedUsers = forumEntry.RankedUsers;		
	}

	public Entity.User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; set; }

	public DateTime CreatedDate { get; set; }

	public int ForumTopicId { get; set; }

    public string Message { get; set; }

	public DateTime? ModifiedDate { get; set; }

	public int Rank { get; set; }

	public List<Entity.ForumEntryUserRank> RankedUsers { get; set; }
		= new();
}
