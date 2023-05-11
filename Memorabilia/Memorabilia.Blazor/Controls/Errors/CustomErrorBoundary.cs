namespace Memorabilia.Blazor.Controls.Errors;

public class CustomErrorBoundary : ErrorBoundary
{
    [Parameter]
    public EventCallback<Exception> ErrorHasOccurred { get; set; }

    protected override async Task OnErrorAsync(Exception exception)
    {
        await ErrorHasOccurred.InvokeAsync(exception);
    }
}
