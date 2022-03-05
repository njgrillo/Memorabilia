using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate
{
    public class SaveBookplateViewModel : SaveViewModel
    {
        public SaveBookplateViewModel() { }

        public SaveBookplateViewModel(BookplateViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;

            if (viewModel.People.Any())
                Person = new SavePersonViewModel(new PersonViewModel(viewModel.People.First().Person));
        }

        public bool HasPerson => Person?.Id > 0;

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayBookplateType && BookplateType != null)
                //{
                //    return $"{path}{BookplateType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}Bookplate.jpg";
            }
        }

        public ItemType ItemType => ItemType.Bookplate;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Bookplate.Name} Details";

        public SavePersonViewModel Person { get; set; }
    }
}
