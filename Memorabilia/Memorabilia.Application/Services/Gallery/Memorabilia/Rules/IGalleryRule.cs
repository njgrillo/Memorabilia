namespace Memorabilia.Application.Services.Gallery.Memorabilia.Rules;

public interface IGalleryRule
{
    bool Applies(Constant.ItemType itemType);

    string GetDescription(Entity.Memorabilia memorabilia);

    string GetSubtitle(Entity.Memorabilia memorabilia);

    string GetTitle(Entity.Memorabilia memorabilia);
}
