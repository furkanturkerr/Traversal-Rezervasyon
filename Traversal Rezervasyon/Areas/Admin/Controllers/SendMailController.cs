using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Areas.Admin.Controllers;
[Area("Admin")]
public class SendMailController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(MailRequest mail)
    {
        MimeMessage mimeMessage = new MimeMessage();
        
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "mail");
        mimeMessage.From.Add(mailboxAddressFrom);
        
        MailboxAddress mailboxAddressTo = new MailboxAddress("User", mail.RecieverMail);
        mimeMessage.To.Add(mailboxAddressTo);
        
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mail.Body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        
        mimeMessage.Subject = mail.Subject;
        
        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("mail", "şifre");
        client.Send(mimeMessage);
        client.Disconnect(true);
        
        return View();
    }
}