using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using ApiBliss.Service;

namespace ApiBliss.Controllers;

[Route("[controller]")]
[ApiController]
public class EmailsController : ControllerBase
{
    private readonly ISendMessageService _sendMessageService;
    private const string SUBJECT = "API Bliss Test";

    public EmailsController(ISendMessageService sendMessageService)
    {
        _sendMessageService = sendMessageService;
    }    

    [HttpPost("{emailAddressTo}/{body}")]
    public ActionResult SendEmail(string emailAddressTo, string body)
    {
        try
        {
            if (!CheckEmailValide(emailAddressTo))
                return BadRequest();

            _sendMessageService.SendEmailAsync(emailAddressTo, body);

            return Ok("Email Ok");
        }
        catch (Exception)
        {
            return RedirectToAction("Email Fail");
        }
        
    }

    private bool CheckEmailValide(string emailAddress)
    {
        if(emailAddress.Contains("@"))
            return true;

        return false;
    }
}
