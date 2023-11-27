using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //Burası Kimden Gidicek
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotalierAdmin", "melih.karakus1818@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);
            //Burası Kime Gidicek 
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);
            //Burası Mesajın İçeriği
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();
            //Burası Mesajın Başlığı
            mimeMessage.Subject = adminMailViewModel.Subject;
            //smtp bağlantı 
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("melih.karakus1818@gmail.com", "gpekxsfsvyxykzkv");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
