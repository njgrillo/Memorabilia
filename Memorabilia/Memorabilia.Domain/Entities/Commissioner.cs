namespace Memorabilia.Domain.Entities
{
    public class Commissioner : Framework.Domain.Entity.DomainEntity
    {
        public Commissioner() { }

        public Commissioner(int sportId, int personId, int? beginYear, int? endYear)
        {
            SportId = sportId;
            PersonId = personId;
            BeginYear = beginYear;
            EndYear = endYear;
        }

        public int? BeginYear { get; private set; }

        public int? EndYear { get; private set; }

        public Person Person { get; set; }

        public int PersonId { get; private set; }

        public Sport Sport { get; set; }

        public int SportId { get; private set; }

        public void Set(int? beginYear, int? endYear)
        {
            BeginYear = beginYear;
            EndYear = endYear;
        }
    }
}
