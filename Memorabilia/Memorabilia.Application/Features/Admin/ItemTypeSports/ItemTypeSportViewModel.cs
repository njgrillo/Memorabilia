﻿using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class ItemTypeSportViewModel
{
    private readonly ItemTypeSport _itemTypeSport;

    public ItemTypeSportViewModel() { }

    public ItemTypeSportViewModel(ItemTypeSport itemTypeSport)
    {
        _itemTypeSport = itemTypeSport;
    }

    public string DeleteText => $"Delete {AdminDomainItem.ItemTypeSports.Item}";

    public int Id => _itemTypeSport.Id;

    public int ItemTypeId => _itemTypeSport.ItemTypeId;

    public string ItemTypeName => Constant.ItemType.Find(ItemTypeId).Name;

    public int SportId => _itemTypeSport.SportId;

    public string SportName => Constant.Sport.Find(SportId).Name;
}
