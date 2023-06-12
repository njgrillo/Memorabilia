namespace Memorabilia.Application.Features.Autograph.Spot;

public class SpotModel
{
    private readonly Entity.Autograph _autograph;

    public SpotModel() { }

    public SpotModel(Entity.Autograph autograph)
    {
        _autograph = autograph;
    }

    public int AutographId 
        => _autograph.Id;

    public int ItemTypeId 
        => _autograph.Memorabilia.ItemTypeId;

    public int MemorabiliaId 
        => _autograph.Memorabilia.Id;

    public string[] MemorabiliaImageNames 
        => _autograph.Memorabilia
                     .Images
                     .Select(image => image.FileName)
                     .ToArray();   

    public int SpotId 
        => _autograph?.Spot?.SpotId ?? 0;

    public int UserId 
        => _autograph?.Memorabilia?.UserId ?? 0;
}
