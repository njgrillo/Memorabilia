namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

public interface IGalleryRule
{
    bool Applies(Domain.Constants.ItemType itemType);

    string GetDescription(Domain.Entities.Memorabilia memorabilia);

    string GetSubtitle(Domain.Entities.Memorabilia memorabilia);

    string GetTitle(Domain.Entities.Memorabilia memorabilia);
}
