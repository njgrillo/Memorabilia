namespace Memorabilia.MinimalAPI.Models.Admin;

public abstract class DomainItemRequest : IHttpRequest
{
    public int Id { get; set; }
}
