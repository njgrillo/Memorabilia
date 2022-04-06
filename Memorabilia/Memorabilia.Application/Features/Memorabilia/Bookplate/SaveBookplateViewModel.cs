using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate
{
    public class SaveBookplateViewModel : SaveItemViewModel
    {
        public SaveBookplateViewModel() { }

        public SaveBookplateViewModel(BookplateViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
        }

        public override string BackNavigationPath => $"Memorabilia/Edit/{MemorabiliaId}";

        public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

        public override string ExitNavigationPath => "Memorabilia/Items";

        public bool HasPerson => Person?.Id > 0;

        public override string ImagePath => "images/bookplate.jpg";

        public override ItemType ItemType => ItemType.Bookplate;

        public override string PageTitle => $"{(EditModeType == EditModeType.Update ? "Edit" : "Add")} {ItemType.Bookplate.Name} Details";

        public SavePersonViewModel Person { get; set; }
    }
}
