using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia;

public class SelectMemorabiliaItemViewModel
{
    public SelectMemorabiliaItemViewModel() { }

    public SelectMemorabiliaItemViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        Autographs = memorabilia.Autographs
                                .Select(autograph => new AutographViewModel(autograph));
    }

    public IEnumerable<AutographViewModel> Autographs { get; private set; } 
        = Enumerable.Empty<AutographViewModel>();
}
