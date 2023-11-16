namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public class SaveForumTopic
{
    public class Handler(IForumTopicRepository forumTopicRepository) :
        CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.ForumTopic forumTopic;

            if (command.IsNew)
            {
                forumTopic = new(command.CreatedDate,
                                 command.CreatedByUserId,
                                 command.ForumCategoryId,
                                 command.SportId,
                                 command.Subject);

                forumTopic.AddEntry(command.Message, command.CreatedDate, command.CreatedByUserId);

                await forumTopicRepository.Add(forumTopic);

                command.Id = forumTopic.Id;

                return;
            }

            forumTopic = await forumTopicRepository.Get(command.Id);

            forumTopic.AddEntry(command.AddedEntry.Message, 
                                command.AddedEntry.CreatedDate, 
                                command.AddedEntry.CreatedByUserId);           

            await forumTopicRepository.Update(forumTopic);  
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly ForumTopicEditModel _forumTopicEditModel;

        public Command(ForumTopicEditModel forumTopicEditModel)
        {
            _forumTopicEditModel = forumTopicEditModel;

            Id = _forumTopicEditModel.Id;
        }

        public ForumEntryEditModel AddedEntry
            => _forumTopicEditModel.Entry;

        public int CreatedByUserId
            => _forumTopicEditModel.CreatedByUser.Id;

        public DateTime CreatedDate
            => DateTime.UtcNow;

        public int ForumCategoryId
            => _forumTopicEditModel.ForumCategory?.Id ?? 0;

        public int ForumEntryId
            => _forumTopicEditModel.Entry.Id;

        public int Id { get; set; }            

        public bool IsModified
            => _forumTopicEditModel.IsModified;

        public bool IsNew
            => _forumTopicEditModel.IsNew;

        public string Message
            => _forumTopicEditModel.Entry.Message;

        public DateTime ModifiedDate
            => DateTime.UtcNow;

        public int Rank
            => _forumTopicEditModel.Entry.Rank;

        public int? SportId
            => _forumTopicEditModel.Sport?.Id;

        public string Subject
            => _forumTopicEditModel.Subject;
    }
}
