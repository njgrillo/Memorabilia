namespace Memorabilia.Blazor;

public static class JavascriptHelper
{
    public static async Task InitializeMultiLineAddressAutocomplete(this IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("initializeMultiLineAddressAutocomplete");
    }

    public static async Task InitializeSingleLineAddressAutocomplete(this IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("initializeSingleLineAddressAutocomplete");
    }

    public static async Task ScrollToAlert(this IJSRuntime jsRuntime)
    {
        await jsRuntime.InvokeVoidAsync("scrollToTop");
    }

    public static async Task SetWindowLocation(this IJSRuntime jsRuntime, string url)
    {
        await jsRuntime.InvokeVoidAsync("setWindowLocation", url);
    }
}
