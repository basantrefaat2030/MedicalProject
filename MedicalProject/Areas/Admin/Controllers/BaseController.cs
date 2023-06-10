using MedicalProject.Application.Services;
using MedicalProject.Infrastructure.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MedicalProject.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        private readonly IAttachmentServices _attachmentServices;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BaseController(IAttachmentServices attachmentServices, IWebHostEnvironment webHostEnvironment)
        {
            _attachmentServices = attachmentServices;
            _webHostEnvironment = webHostEnvironment; 
        }

        [HttpPost]
        public IActionResult UploadFile()
        {
            try
            {
                var files = Request.Form.Files;
                IFormFile file = files.FirstOrDefault();

                if (file.Length > 0)
                {
                    string FolderName = "Attachments";
                    string src = "";
                    string fullPath = "";
                    string attachmentsName = "";

                    string _extension = Path.GetExtension(file.FileName);

                    var attachment = new Attachments { Extention = _extension , CreationDate = DateTime.Now, Title = Path.GetFileName(file.FileName) };
                    _attachmentServices.Add(attachment);
                    _attachmentServices.Save();
                    string _FileName = Path.GetFileName(file.FileName);

                    string PathName = "/" + FolderName + "/" + attachment.AttachmentsId.ToString() + _extension;
                    string upload = Path.Combine(_webHostEnvironment.WebRootPath, FolderName);
                    //string fullPath = Path.Combine(upload, attachment.AttachmentId.ToString() + _extension);

                    if (_extension == ".pdf")
                    {
                        src = "/admin/dist/img/pdf.png";
                    }
                    else if (_extension == ".xlsx" || _extension == ".xls")
                    {
                        src = "/admin/dist/img/exel.png";
                    }
                    else if (_extension == ".pptx" || _extension == ".ppt")
                    {
                        src = "/admin/dist/img/power.png";
                    }
                    else
                    {
                        src = "/Attachments/" + attachment.AttachmentsId.ToString() + _extension;  
                    }

                    fullPath = Path.Combine(upload, attachment.AttachmentsId.ToString() + _extension);
                    file.CopyTo(new FileStream(fullPath, FileMode.Create));

                    return Json(new
                    {
                        status = "success",
                        path = PathName,
                        id = attachment.AttachmentsId.ToString(),
                        src = src,
                        name = _FileName,
                        attachmentsName = attachment.AttachmentsId.ToString() + _extension,
                        date = DateTime.Now.ToString("yyyy-MM-dd"),
                    });
                }
                return Json(new { status = "Faild", message = "Sorry No File To Upload .." });
            }
            catch (Exception ex)
            {
                return Json(new { status = "Faild", message = "Sorry Can't Upload Your File .." + ex.Message });
            }
        }
    }
}
