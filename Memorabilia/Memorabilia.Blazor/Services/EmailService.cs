namespace Memorabilia.Blazor.Services;

public class EmailService(IEmailSettings emailSettings)
{
    public void SendEmailMessage(string receiverName,
                                 string receiverEmail,  
                                 string subject,    
                                 string body,
                                 CancellationToken cancellationToken = default)
    {
        try
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(emailSettings.SenderName, emailSettings.Username));
            email.To.Add(new MailboxAddress(receiverName, receiverEmail));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect(emailSettings.Server, emailSettings.Port, cancellationToken: cancellationToken);

            smtp.Authenticate(emailSettings.Username, emailSettings.Password, cancellationToken);

            smtp.Send(email);
            smtp.Disconnect(true, cancellationToken);
        }
        catch (Exception ex)
        {
            //TODO
            var test = ex;
        }        
    }
}
