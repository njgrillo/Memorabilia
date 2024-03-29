﻿using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class ItemTypeLevelsViewModel : ViewModel
    {
        public ItemTypeLevelsViewModel() { }

        public ItemTypeLevelsViewModel(IEnumerable<Domain.Entities.ItemTypeLevel> itemTypeLevels)
        {
            ItemTypeLevels = itemTypeLevels.Select(itemTypeLevel => new ItemTypeLevelViewModel(itemTypeLevel)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeLevelViewModel> ItemTypeLevels { get; set; } = new();

        public override string ItemTitle => "Item Type Level";

        public override string PageTitle => "Item Type Levels";

        public override string RoutePrefix => "ItemTypeLevels";
    }
}
