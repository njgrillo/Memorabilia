using Memorabilia.Application.Features.Services.Gallery.Memorabilia.Rules;

namespace Memorabilia.Application.Features.Services.Gallery.Memorabilia;

public interface IGalleryRuleFactory
{
    List<IGalleryRule> Rules { get; }
}
