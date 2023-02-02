namespace Memorabilia.Blazor;

public static class JavascriptHelper
{
    public static async Task ScrollToAlert(this IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("scrollToTop");
    }
}
