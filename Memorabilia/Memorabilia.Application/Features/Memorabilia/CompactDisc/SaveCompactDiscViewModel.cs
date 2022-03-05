using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc
{
    public class SaveCompactDiscViewModel : SaveViewModel
    {
        public SaveCompactDiscViewModel() { }

        public SaveCompactDiscViewModel(CompactDiscViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
        }

        public bool HasPerson => People.Any();

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayCompactDiscType && CompactDiscType != null)
                //{
                //    return $"{path}{CompactDiscType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}CompactDisc.jpg";
            }
        }

        public ItemType ItemType => ItemType.CompactDisc;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.CompactDisc.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();
    }
}
