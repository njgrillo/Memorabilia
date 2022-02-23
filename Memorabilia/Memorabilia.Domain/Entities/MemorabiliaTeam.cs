namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaTeam : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaTeam() { }

        public MemorabiliaTeam(int memorabiliaId, int teamId)
        {
            MemorabiliaId = memorabiliaId;
            TeamId = teamId;
        }

        public int MemorabiliaId { get; private set; }

        public Team Team { get; private set; }

        public int TeamId { get; private set; }

        public void Set(int teamId)
        {
            TeamId = teamId;
        }
    }
}
