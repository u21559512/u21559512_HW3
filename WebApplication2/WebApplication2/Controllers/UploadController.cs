using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UploadController : Controller
    {



        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult AboutMe()
        {
            return View();
        }

  //Code to upload 
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, string answer)
        {



            try
            {

                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path;

                    if (answer == "Document")
                    {
                        _path = Path.Combine(Server.MapPath("~/Media/Doc"), _FileName);
                        file.SaveAs(_path);
                    }
                    else if (answer == "Image")
                    {
                        _path = Path.Combine(Server.MapPath("~/Media/Images"), _FileName);
                        file.SaveAs(_path);
                    }
                    else
                    {
                        _path = Path.Combine(Server.MapPath("~/Media/Vid"), _FileName);
                        file.SaveAs(_path);
                    }





                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();


            }
            catch
            {
                ViewBag.Message = "File upload failed!!" + answer;
                return View();
            }


        }
        //Action to display the document 
        public ActionResult Doc()
        {

            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Doc"));
            List<Files> Fil = new List<Files>();
            foreach (string filepath in filepaths)
            {
                Fil.Add(new Files { FileName = Path.GetFileName(filepath) });
            }
            return View(Fil);
        }
        //Action to download the file 
        public FileResult Downloadfile(string filename)
        {
            string path = Server.MapPath("~/Media/Doc/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filename);

        }

        //Action to delete the file 
        public ActionResult DeleteFile(string filename)
        {
            string path = Server.MapPath("~/Media/Doc/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            
            System.IO.File.Delete(path);
            return RedirectToAction("UploadFile");
        }
        //Action to display the image 
        public ActionResult Image()
        {
            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Images"));
            List<Files> Fil = new List<Files>();
            foreach (string filepath in filepaths)
            {
                Fil.Add(new Files { FileName = Path.GetFileName(filepath) });
            }
            return View(Fil);
        }
        //Action to download the image
        public FileResult DownloadImage(string filename)
        {
            string path = Server.MapPath("~/Media/Images/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filename);

        }
        //Action to delete the image

        public ActionResult DeleteImage(string filename)
        {
            string path = Server.MapPath("~/Media/Images/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);
            return RedirectToAction("UploadFile");
        }
        //Action to display the videos 
        public ActionResult Vid()
        {

            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Vid"));
            List<Files> Fil = new List<Files>();
            foreach (string filepath in filepaths)
            {
                Fil.Add(new Files { FileName = Path.GetFileName(filepath) });
            }
            return View(Fil);
        }
        //Action to download the videos
        public FileResult DownloadVid(string filename)
        {
            string path = Server.MapPath("~/Media/Vid/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", filename);

        }
        //Delete vidoes
        public ActionResult DeleteVid(string filename)
        {
            string path = Server.MapPath("~/Media/Vid/") + filename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);
            return RedirectToAction("UploadFile");
        }

    }
    
     }