
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using Traversal_Rezervasyon.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    [Route("PasswordChange")]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "furkanturker.dev@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişikliği Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("furkanturker.dev@gmail.com", "tblv oyrp bmyu jgtw");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

        [HttpGet("ResetPassword")]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetModelViewModel resetPasswordViewModel)
        {
            // ÖNCE FORM'DAN AL (Hidden input'tan geliyor)
            var userid = Request.Form["UserId"].ToString();
            var token = Request.Form["Token"].ToString();
            
            // Eğer form'da yoksa TempData'dan dene
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(token))
            {
                userid = TempData["userid"]?.ToString();
                token = TempData["token"]?.ToString();
            }
            
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(token))
            {
                ViewBag.Error = "Geçersiz istek. Lütfen mail'inizdeki linki tekrar kullanın.";
                return View();
            }
            
            var user = await _userManager.FindByIdAsync(userid);
            
            if (user == null)
            {
                ViewBag.Error = "Kullanıcı bulunamadı.";
                return View();
            }
            
            var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordViewModel.Password);
            
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            
            // Hataları göster
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            
            return View();
        }
    }
}