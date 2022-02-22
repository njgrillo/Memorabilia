namespace Memorabilia.Domain.Entities
{
    public class Division : Framework.Domain.Entity.DomainEntity
    {
        public Division() { }

        public Division(int? conferenceId, string name, string abbreviation)
        {
            ConferenceId = conferenceId;
            Name = name;
            Abbreviation = abbreviation;
        }

        public string Abbreviation { get; set; }

        public int? ConferenceId { get; set; }

        public string ConferenceName => Constants.Conference.Find(ConferenceId ?? 0)?.Name;

        public string Name { get; set; }        

        public void Set(int? conferenceId, string name, string abbreviation)
        {
            ConferenceId = conferenceId;
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
