﻿#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public class ItemTypeEntityDropDown<T> : DropDown<T, int> where T : class, IWithName, IWithValue<int>
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public ItemType ItemType { get; set; }
}
