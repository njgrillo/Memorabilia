namespace Memorabilia.Application.Features.Admin;

public class DomainQuery : IQuery<DomainModel>
{
    public DomainQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
