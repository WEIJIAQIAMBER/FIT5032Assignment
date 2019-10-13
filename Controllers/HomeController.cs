using FIT5032Assignment.Models;
using FIT5032Assignment.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032Assignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles ="admin")]
        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    HttpPostedFileBase Attachments = model.Attachments;
                    String AttachmentAddress;
                    EmailSender es = new EmailSender();
                    if (Attachments == null)
                    {
                        es.Send(toEmail, subject, contents,null,null);
                    }
                    else
                    {
                       
                        String AttachmentPath = Server.MapPath("~/Uploads/");
                        if (!Directory.Exists(AttachmentPath))
                        {
                            Directory.CreateDirectory(AttachmentPath);
                        }
                        String AttachmentName = Path.GetFileName(Attachments.FileName);
                        AttachmentAddress = AttachmentPath + AttachmentName;
                        Attachments.SaveAs(AttachmentAddress);
                        ViewBag.Message = "Attachment uploaded successfully";
                        es.Send(toEmail, subject, contents, AttachmentAddress, AttachmentName);
                    }

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }
                return View();
            }
        
        }
}