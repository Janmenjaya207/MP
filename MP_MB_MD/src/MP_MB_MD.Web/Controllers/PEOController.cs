using CA.SharedKernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP_MB_MD.Core.Abstract;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using MP_MB_MD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Controllers
{
    public class PEOController : Controller
    {

        private readonly IRepository repositoryInterface;
        AppDbContext con;
        public PEOController(IRepository _repositoryInterface, AppDbContext obj)
        {
            this.repositoryInterface = _repositoryInterface;
            this.con = obj;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult Grievance(int? id=0)
        {
            if(id!=0)
            {
                var data = con.Grievance.Where(x => x.Id == id).FirstOrDefault();
                return View(data);

            }
            else
            {
                return View();
            }
           
        }
        [HttpPost]

        public async Task<IActionResult> Grievance(Grievance ZZ, IFormFile attachment,string Attachmentview)
        {
            if (attachment != null)
            {
                FileInfo fi = new FileInfo(attachment.FileName);
                string img = MainModel.FileUpload(attachment, fi.Extension, "FileUpload");
                ZZ.Attachment = img;
            }
            else
            {
                ZZ.Attachment = Attachmentview;
            }

            int count = repositoryInterface.Grievance(ZZ);
            if (count == 1)
            {
                TempData["Gmsg"] = "Grievance Created Sucessfully";
                return RedirectToAction("Grievance");
            }
            if(count==2)
            {
                TempData["Gmsg"] = "Grievance Updated Sucessfully";
                return RedirectToAction("Grievance_list");
            }
            else
            {
                TempData["WGmsg"] = "Something Went Wrong";
                return RedirectToAction("Grievance");
            }

        }

        public IActionResult Grievance_list()
        {
            List<Grievance> g = new List<Grievance>();
            g = con.Grievance.Where(x=>x.IsActive==true).ToList();


            return View(g);
        }

        public async Task<IActionResult> DeleteGrivance(int id)
        {
            var data = con.Grievance.Where(x => x.Id == id).FirstOrDefault();
            data.IsActive = false;
            con.SaveChanges();
            TempData["Delete"] = "TrainingPlace Details Delete Successfully";
            return RedirectToAction("Grievance_list");

        }

    }
}
