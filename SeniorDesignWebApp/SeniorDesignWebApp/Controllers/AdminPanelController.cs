using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic.FileIO; 

namespace SeniorDesignWebApp.Controllers
{
    public class AdminPanelController : Controller
    {

        // GET: Upload
        public ActionResult Index()
        {
            var model = new SeniorDesignWebApp.Models.AdminPanel();
            return View("Index", "_Layout", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
        /** Uploading File feature */
        [HttpPost]
        public ActionResult Index(SeniorDesignWebApp.Models.AdminPanel model)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "/upload.csv";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            byte[] uploadedFile = new byte[model.File.InputStream.Length];
            model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
            System.IO.File.WriteAllBytes(path, uploadedFile);

            // now you could pass the byte array to your model and store wherever 
            // you intended to store it

            DataTableReader dtr = ConstructDataTableReader(path);
            string content = "";
            int index = 0;
            while (dtr.Read())
            {
                for (int i = 0; i < dtr.FieldCount; i++)
                {
                    if (index >= 2) content += dtr[i] + ", ";
                }
                if (index >= 2) content += "ENDLINE";
                index++;
            }

            return Content("Upload complete:<br>" + content);
        }

        protected DataTableReader ConstructDataTableReader(string pathname)
        {
            DataTable dt = new DataTable();
            bool isFirstRowHeader = true;
            string[] colf = new string[] { "" };
            using (TextFieldParser parser = new TextFieldParser(pathname))
            {
                parser.TrimWhiteSpace = true;
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                if (isFirstRowHeader)
                {
                    colf = parser.ReadFields();
                    foreach (string sds in colf)
                    {
                        DataColumn year = new DataColumn(sds.Trim().ToLower(), Type.GetType("System.String"));
                        dt.Columns.Add(year);
                    }
                }
                while (true)
                {
                    if (!isFirstRowHeader)
                    {
                        string[] parts = parser.ReadFields();
                        if (parts == null)
                        {
                            break;
                        }
                        System.Diagnostics.Debug.Write(parts);
                        dt.Rows.Add(parts);
                    }
                    isFirstRowHeader = false;
                }
            }
            return new DataTableReader(dt);
        }
    }
}