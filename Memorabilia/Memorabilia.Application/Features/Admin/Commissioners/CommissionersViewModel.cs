﻿using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.Commissioners;

public class CommissionersViewModel : Model
{
    public CommissionersViewModel() { }

    public CommissionersViewModel(IEnumerable<Domain.Entities.Commissioner> commissioners)
    {
        Commissioners = commissioners.Select(commissioner => new CommissionerViewModel(commissioner))
                                     .OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                     .ThenByDescending(commissioner => commissioner.BeginYear)
                                     .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<CommissionerViewModel> Commissioners { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.Commissioners.Item;

    public override string PageTitle => AdminDomainItem.Commissioners.Title;

    public override string RoutePrefix => AdminDomainItem.Commissioners.Page;
}
