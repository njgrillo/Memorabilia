using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia
{
    public class MemorabiliaItemsViewModel : ViewModel
    {
        public MemorabiliaItemsViewModel() { }

        public MemorabiliaItemsViewModel(IEnumerable<Domain.Entities.Memorabilia> memorabiliaItems)
        {
            MemorabiliaItems = memorabiliaItems.Select(memorabiliaItem => new MemorabiliaItemViewModel(memorabiliaItem)).ToList();
        }

        public string AddRoute => "Memorabilia/Edit";

        public string AddText => "Add Memorabilia";

        public List<MemorabiliaItemViewModel> MemorabiliaItems { get; set; } = new();

        public override string PageTitle => "Memorabilia";       
    }
}
