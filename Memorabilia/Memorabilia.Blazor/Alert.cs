namespace Memorabilia.Blazor;

public class Alert(string message, Severity severity)
{
    public string Message { get; set; }
        = message;

    public Severity Severity { get; set; } 
        = severity;
}
