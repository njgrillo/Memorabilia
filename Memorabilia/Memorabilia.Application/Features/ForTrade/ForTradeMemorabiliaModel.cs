namespace Memorabilia.Application.Features.ForTrade;

public class ForTradeMemorabiliaModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public ForTradeMemorabiliaModel() { }

    public ForTradeMemorabiliaModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int Id
        => _memorabilia.Id;

    public string ImageDisplayCount
    {
        get
        {
            if (!_memorabilia.Images.Any())
                return "No Images Found";

            if (_memorabilia.Images.Count == 1)
                return "1 Image";

            return $"{_memorabilia.Images.Count} Images";
        }
    }

    public string ItemTypeName
        => _memorabilia.ItemType?.Name;

    public string MemorabiliaPrimaryImage
        => !_memorabilia.Images.Any()
            ? Constant.ImageFileName.ImageNotAvailable
            : _memorabilia.Images.FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?.FileName
              ?? _memorabilia.Images.First().FileName;

    public int UserId
        => _memorabilia.UserId;
}
