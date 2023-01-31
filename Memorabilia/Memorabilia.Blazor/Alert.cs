namespace Memorabilia.Blazor;

public class Alert
{
    public string Message { get; set; }

    public Severity Severity { get; set; }

    public Alert(string message, Severity severity)
    {
        Message = message;
        Severity = severity;
    }
}
