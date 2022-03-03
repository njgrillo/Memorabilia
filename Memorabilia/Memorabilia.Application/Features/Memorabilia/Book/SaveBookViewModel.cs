using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Book
{
    public class SaveBookViewModel : SaveViewModel
    {
        public SaveBookViewModel() { }

        public SaveBookViewModel(BookViewModel viewModel)
        {
            Edition = viewModel.Book?.Edition; 
            HardCover = viewModel.Book?.HardCover ?? true;
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            Publisher = viewModel.Book?.Publisher;
            SportIds = viewModel.Sports.Select(x => x.Id).ToList();
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
            Title = viewModel.Book?.Title;
        }

        public string Edition { get; set; }

        public bool HardCover { get; set; }
        
        public bool HasPerson => People.Any();

        public bool HasSport => SportIds.Any();

        public bool HasTeam => Teams.Any();

        public ItemType ItemType => ItemType.Book;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Book.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        public string Publisher { get; set; }

        public List<int> SportIds { get; set; } = new();

        public List<SaveTeamViewModel> Teams { get; set; } = new();

        public string Title { get; set; }
    }
}
