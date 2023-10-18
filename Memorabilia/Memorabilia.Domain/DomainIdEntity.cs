namespace Memorabilia.Domain;

public abstract class DomainIdEntity
{
    public DomainIdEntity() { }

    public DomainIdEntity(int id) 
    { 
        Id = id;
    } 

    public int Id { get; set; } 
}
