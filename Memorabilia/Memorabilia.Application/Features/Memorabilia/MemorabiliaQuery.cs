namespace Memorabilia.Application.Features.Memorabilia
{
    public abstract class MemorabiliaQuery
    {
        protected MemorabiliaQuery(int memorabiliaId)
        {
            MemorabiliaId = memorabiliaId;
        }

        public virtual int MemorabiliaId { get; }
    }
}
