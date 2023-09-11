namespace Memorabilia.Blazor.Configuration;

public class EmailSettings : IEmailSettings
{
    public int Port { get; set; }

    public string Password { get; set; }

    public string SenderEmail { get; set; }

    public string SenderName { get; set; }

    public string Server { get; set; }

    public string Username { get; set; }
}
