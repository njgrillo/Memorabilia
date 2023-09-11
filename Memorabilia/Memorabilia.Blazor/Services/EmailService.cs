namespace Memorabilia.Blazor.Services;

public class EmailService
{
    private readonly IEmailSettings _emailSettings;

	public EmailService(IEmailSettings emailSettings)
	{
        _emailSettings = emailSettings;
    }

    public void SendEmailMessage(string receiverName,
                                 string receiverEmail,  
                                 string subject,    
                                 string body,
                                 CancellationToken cancellationToken = default)
    {
        try
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.Username));
            email.To.Add(new MailboxAddress(receiverName, receiverEmail));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect(_emailSettings.Server, _emailSettings.Port, cancellationToken: cancellationToken);

            smtp.Authenticate(_emailSettings.Username, _emailSettings.Password, cancellationToken);

            smtp.Send(email);
            smtp.Disconnect(true, cancellationToken);
        }
        catch (Exception ex)
        {
            var test = ex;
        }        
    }
}
