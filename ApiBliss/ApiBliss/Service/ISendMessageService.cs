namespace ApiBliss.Service;

public interface ISendMessageService
{
    Task SendEmailAsync(string email, string message);
}
