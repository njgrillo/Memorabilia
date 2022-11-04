﻿#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Baseball;

public partial class ViewCareerRecords : CommandQuery
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string PersonImageRootPath { get; set; }

    private CareerRecordsViewModel _viewModel = new();    

    protected string GetImage(string imagePath)
    {
        var path = imagePath == ImagePath.ImageNotAvailable
                ? imagePath
                : Path.Combine(PersonImageRootPath, imagePath);

        return $"data:image/jpg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
    }

    protected override async Task OnInitializedAsync()
    {
        _viewModel = await QueryRouter.Send(new GetCareerRecords(Sport.Baseball.Id));
    }
}