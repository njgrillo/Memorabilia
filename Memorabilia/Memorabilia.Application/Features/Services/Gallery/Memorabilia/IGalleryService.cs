namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public interface IGalleryService
{
    string GetDescription(Domain.Entities.Memorabilia memorabilia);

    string GetSubtitle(Domain.Entities.Memorabilia memorabilia);

    string GetTitle(Domain.Entities.Memorabilia memorabilia);
}
