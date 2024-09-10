namespace Memorabilia.Domain.Entities;

public class Collection : Entity, IWithName
{
    public Collection() { }

    public Collection(string name,
        string description,
        int userId,
        int[] memorabiliaIds)
    {
        Name = name;
        Description = description;
        UserId = userId;

        if (memorabiliaIds.Length == 0)
            return;

        foreach (int memorabiliaId in memorabiliaIds)
        {
            Memorabilia.Add(new CollectionMemorabilia(Id, memorabiliaId));
        }
    }

    public string Description { get; set; }

    public virtual List<CollectionMemorabilia> Memorabilia { get; set; } 
        = [];

    public string Name { get; set; }

    public int UserId { get; set; }

    public void Set(string name,
        string description,
        int[] memorabiliaIds)
    {
        Name = name;
        Description = description;

        SetMemorabilia(memorabiliaIds);
    }

    public void RemoveMemorabilia(int[] memorabiliaIds)
    {
        if (memorabiliaIds.Length == 0)
            return;

        Memorabilia = Memorabilia.Where(item => !memorabiliaIds.Contains(item.MemorabiliaId)).ToList();
    }

    public void SetMemorabilia(int[] memorabiliaIds)
    {
        if (memorabiliaIds.Length == 0)
        {
            Memorabilia = [];
            return;
        }

        foreach (int memorabiliaId in memorabiliaIds)
        {
            if (Memorabilia.Any(item => item.MemorabiliaId == memorabiliaId))
                continue;

            Memorabilia.Add(new CollectionMemorabilia(Id, memorabiliaId));
        }
    }
}
