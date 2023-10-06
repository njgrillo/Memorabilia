namespace Memorabilia.Domain.Entities;

public class Role : DomainEntity
{
    public Role() { }

    public Role(string name, string abbreviation) : base(name, abbreviation) { }

    public virtual List<RolePermission> Permissions { get; private set; }
}
