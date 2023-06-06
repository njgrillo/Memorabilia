namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public interface IGalleryService
{
    string GetDescription(Entity.Memorabilia memorabilia);

    string GetSubtitle(Entity.Memorabilia memorabilia);

    string GetTitle(Entity.Memorabilia memorabilia);
}
