using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Servis()
        {
            return View();
        }

        public IActionResult Galeri()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Iletisim(Mail m)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com",587);
                client.Credentials = new NetworkCredential("hayaliperest09@gmail.com", "Hayali0909*");
                client.EnableSsl = true;

                MailMessage msj = new MailMessage();
                msj.From= new MailAddress(m.Email, m.Adi +" "+ m.Soyadi);
                msj.To.Add("hayaliperest09@gmail.com");
                msj.Subject = m.Konu+" "+ m.Email;
                msj.Body = m.Mesaj;

                client.Send(msj);

                MailMessage msj1 = new MailMessage();
                msj1.From = new MailAddress("hayaliperest09@gmail.com","Rent A Car");
                msj1.To.Add(m.Email);
                msj1.Subject = "Mailinize Cevap";
                msj1.Body = "Teşekkürler Size En Kısa Sürede Geri Dönüş Yapılacaktır.";
                client.Send(msj1);

                ViewBag.Succes = "Teşekkürler Mail Başarılı Bir Şekilde Gönderildi.";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Error = "Mail Gönderilirken Bir Hata Oluştu";
                return View();
            }
        }
    }
}