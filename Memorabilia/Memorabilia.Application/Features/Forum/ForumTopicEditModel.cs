namespace Memorabilia.Application.Features.Forum;

public class ForumTopicEditModel : EditModel
{
	public ForumTopicEditModel() { }

	public ForumTopicEditModel(Entity.ForumTopic forumTopic)
	{
		Bookmarks = forumTopic.Bookmarks;
		CreatedByUser = forumTopic.CreatedByUser;
		CreatedDate = forumTopic.CreatedDate;
		ForumCategory = Constant.ForumCategory.Find(forumTopic.ForumCategoryId);
		ForumCategoryId = forumTopic.ForumCategoryId;
		Id = forumTopic.Id;
		ModifiedDate = forumTopic.ModifiedDate;
		Sport = Constant.Sport.Find(forumTopic.SportId ?? 0);
		SportId = forumTopic.SportId;
		Subject = forumTopic.Subject;

		Entries = forumTopic.Entries
							.Select(entry => new ForumEntryEditModel(entry))
							.ToList();
	}

	public List<Entity.ForumTopicUserBookmark> Bookmarks { get; set; }
        = new();

	public Entity.User CreatedByUser { get; set; }

	public DateTime CreatedDate { get; set; }

	public List<ForumEntryEditModel> Entries { get; set; }
		= new();

    public ForumEntryEditModel Entry { get; set; }
		= new();

    public Constant.ForumCategory ForumCategory { get; set; }

    public int ForumCategoryId { get; set; }

	public string ForumCategoryTitle
		=> Sport != null && !Sport.Name.IsNullOrEmpty()
		? $"{ForumCategory?.Name} - {Sport?.Name}"
        : $"{ForumCategory?.Name}";


    public DateTime? ModifiedDate { get; set; }

	public ForumEntryEditModel OriginalEntry
		=> Entries.OrderBy(entry => entry.CreatedDate)
				  .FirstOrDefault();

    public Constant.Sport Sport { get; set; }

    public int? SportId { get; set; }

	public string Subject { get; set; }
}
