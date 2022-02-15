namespace Memorabilia.Application.Features
{
    public abstract class ViewModel
    {     
        public virtual string ItemTitle { get; }

        public virtual string PageTitle { get; }

        public virtual string RoutePrefix { get; }
    }
}
