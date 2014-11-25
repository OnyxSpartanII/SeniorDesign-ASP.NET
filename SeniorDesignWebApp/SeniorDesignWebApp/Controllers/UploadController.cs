using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorDesignWebApp.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            var model = new SeniorDesignWebApp.Models.upload();
            return View(model);
        }
        /** Uploading File feature */
        [HttpPost]
        public ActionResult Index(SeniorDesignWebApp.Models.upload model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            byte[] uploadedFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            // now you could pass the byte array to your model and store wherever 
            // you intended to store it

            return Content("Thanks for uploading the file");
        }
    }
}