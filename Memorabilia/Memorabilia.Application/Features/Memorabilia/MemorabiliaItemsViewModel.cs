using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class MemorabiliaItemsViewModel : ViewModel
    {
        public MemorabiliaItemsViewModel() { }

        public MemorabiliaItemsViewModel(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new MemorabiliaItemViewModel(memorabiliaItem));
        }

        public IEnumerable<MemorabiliaItemViewModel> MemorabiliaItems { get; set; } = Enumerable.Empty<MemorabiliaItemViewModel>();

        public override string PageTitle => "Memorabilia";       
    }
}
