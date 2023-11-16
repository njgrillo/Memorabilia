namespace Memorabilia.Application.Features.ThroughTheMail;

public record GetThroughTheMail(int Id) : IQuery<Entity.ThroughTheMail>
{
    public class Handler(IThroughTheMailRepository throughTheMailRepository) 
        : QueryHandler<GetThroughTheMail, Entity.ThroughTheMail>
    {
        protected override async Task<Entity.ThroughTheMail> Handle(GetThroughTheMail query)
            => await throughTheMailRepository.Get(query.Id);
    }
}
