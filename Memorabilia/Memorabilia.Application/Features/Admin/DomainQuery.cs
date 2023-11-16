namespace Memorabilia.Application.Features.Admin;

public class DomainQuery(int id) : IQuery<DomainModel>
{
    public int Id { get; }
        = id;
}
