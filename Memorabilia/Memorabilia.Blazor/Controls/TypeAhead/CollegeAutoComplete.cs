﻿namespace Memorabilia.Blazor.Controls.TypeAhead;

public class CollegeAutoComplete : DomainEntityAutoComplete<College>
{
    [Parameter]
    public College[] Colleges { get; set; } 
        = [];

    protected override void OnInitialized()
    {
        Label = "College";
        Placeholder = "Search by college...";
        ResetValueOnEmptyText = true;
        Items = Colleges.Length != 0 ? Colleges : College.All;
    }

    public override async Task<IEnumerable<College>> Search(string searchText)
        => !searchText.IsNullOrEmpty()
            ? await Task.FromResult(Items.Where(item => item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) || 
                                                        (!item.Abbreviation.IsNullOrEmpty() && item.Abbreviation.Contains(searchText, StringComparison.OrdinalIgnoreCase))))
            : Array.Empty<College>();
}
