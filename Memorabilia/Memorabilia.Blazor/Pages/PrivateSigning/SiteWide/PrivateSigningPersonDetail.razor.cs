﻿namespace Memorabilia.Blazor.Pages.PrivateSigning.SiteWide;

public partial class PrivateSigningPersonDetail
{
    [Parameter]
    public PrivateSigningPersonModel PrivateSigningPerson { get; set; }
        = new();
}
