namespace Memorabilia.Domain;

public abstract class Entity
{
    public Entity() { }

    public Entity(int id) 
    { 
        Id = id;
    } 

    public int Id { get; set; } 
}
