﻿using Memorabilia.Application.Features.Admin.Person;
using System.ComponentModel.DataAnnotations;

namespace Memorabilia.Application.Features.Admin.Commissioner
{
    public class SaveCommissionerViewModel : SaveViewModel
    {
        public SaveCommissionerViewModel() { }

        public SaveCommissionerViewModel(CommissionerViewModel viewModel)
        {
            BeginYear = viewModel.BeginYear;
            EndYear = viewModel.EndYear;
            Id = viewModel.Id;
            Person = new PersonViewModel(viewModel.Person);
            SportLeagueLevelId = viewModel.SportLeagueLevelId;
        }

        public int? BeginYear { get; set; }

        public int? EndYear { get; set; }

        public override string ItemTitle => "Commissioner";

        public override string PageTitle => $"{(Id > 0 ? "Edit" : "Add")} {ItemTitle}";

        [Required]
        public PersonViewModel Person { get; set; }

        public override string RoutePrefix => "Commissioners";

        [Required]
        public int SportLeagueLevelId { get; set; }
    }
}
