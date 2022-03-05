using Memorabilia.Application.Features.Admin.Person;
using Memorabilia.Application.Features.Admin.Team;
using Memorabilia.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Document
{
    public class SaveDocumentViewModel : SaveViewModel
    {
        public SaveDocumentViewModel() { }

        public SaveDocumentViewModel(DocumentViewModel viewModel)
        {
            MemorabiliaId = viewModel.MemorabiliaId;
            People = viewModel.People.Select(person => new SavePersonViewModel(new PersonViewModel(person.Person))).ToList();
            SizeId = viewModel.Size.SizeId;
            Teams = viewModel.Teams.Select(team => new SaveTeamViewModel(new TeamViewModel(team.Team))).ToList();
        }

        public bool HasPerson => People.Any();

        public bool HasTeam => Teams.Any();

        public string ImagePath
        {
            get
            {
                var path = "images/";

                //if (DisplayDocumentType && DocumentType != null)
                //{
                //    return $"{path}{DocumentType.Name.Replace(" ", "")}.jpg";
                //}

                return $"{path}Document.jpg";
            }
        }

        public ItemType ItemType => ItemType.Document;

        [Required]
        public int MemorabiliaId { get; set; }

        public override string PageTitle => $"{(MemorabiliaId > 0 ? "Edit" : "Add")} {ItemType.Document.Name} Details";

        public List<SavePersonViewModel> People { get; set; } = new();

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        public List<SaveTeamViewModel> Teams { get; set; } = new();
    }
}
