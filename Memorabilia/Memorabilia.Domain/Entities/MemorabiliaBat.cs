namespace Memorabilia.Domain.Entities;

public class MemorabiliaBat : Entity
{
    public MemorabiliaBat() { }

    public MemorabiliaBat(int memorabiliaId, int? batTypeId, int? colorId, int? length)
    {
        MemorabiliaId = memorabiliaId;
        BatTypeId = batTypeId;
        ColorId = colorId;
        Length = length;
    }

    public int? BatTypeId { get; private set; }

    public int? ColorId { get; private set; }

    public int? Length { get; private set; }

    public int MemorabiliaId { get; private set; }

    public void Set(int? batTypeId, int? colorId, int? length)
    {
        BatTypeId = batTypeId;
        ColorId = colorId;
        Length = length;
    }
}
