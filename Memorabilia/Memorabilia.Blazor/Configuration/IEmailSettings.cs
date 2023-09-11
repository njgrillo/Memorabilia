namespace Memorabilia.Blazor.Configuration;

public interface IEmailSettings
{
    int Port { get; set; }

    string Password { get; set; }

    string SenderEmail { get; set; }

    string SenderName { get; set; }

    string Server { get; set; }

    string Username { get; set; }
}
