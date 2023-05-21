using CA.SharedKernel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using MP_MB_MD.Infrastructure.Data;
using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Controllers
{
    public class LogInController : Controller
    {
        AppDbContext con;
        private readonly IRepository<Manage_User> mUser;
        public LogInController(IRepository<Manage_User> mUser, AppDbContext obj)
        {
            this.mUser = mUser;
            this.con = obj;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            //return RedirectToAction("LoginUser");
            return RedirectToAction("LoginUser", "LogIn");
        }
        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(string Username,string password)
        {
          

            var userdata = await mUser.ListAsync();


            var user = userdata.Where(x => x.User_name == Username && x.Password == MainModel.EncodeBase64(password)).FirstOrDefault();


            if (user != null && user.Isdelete == false)
            {
               
                HttpContext.Session.SetString("UserType", user.User_Type.ToString());

                HttpContext.Session.SetString("UserId", user.User_Id.ToString());
                HttpContext.Session.SetString("UserName", user.User_name);
                if (user.User_Type.ToString() == "1")
                {
                    
                    return RedirectToAction("DashBoard", "Admin");
                }
                else if (user.User_Type.ToString() == "2")
                {
                    HttpContext.Session.SetString("Panchayat", user.Grampanchayat.ToString());
                    HttpContext.Session.SetString("Block", user.Block.ToString());
     

                    return RedirectToAction("DashBoard", "PEO");
                }
                else if (user.User_Type.ToString() == "3")
                {
                    HttpContext.Session.SetString("Block", user.Block.ToString());
                    return RedirectToAction("DashBoard", "BDO");
                }
               
                else if (user.User_Type.ToString() == "4")
                {
                    HttpContext.Session.SetString("Block", user.Block.ToString());
                    
                    return RedirectToAction("DashBoard", "NodalOff");
                }
                else if (user.User_Type.ToString() == "5")
                {
                   
                    HttpContext.Session.SetString("DeptId", user.Department_Id.ToString());
                    HttpContext.Session.SetString("DeptName", user.Department_NameDescription.ToString());
                    return RedirectToAction("DashBoard", "LDO");
                }
                else if (user.User_Type.ToString() == "6")
                {

                    return RedirectToAction("DashBord", "Collector");
                }
                else {  return RedirectToAction("LoginUser", "LogIn"); }

            }
            else if (user != null && user.Isdelete == true)
            {
                TempData["warning"] = "user doesn't exist";
                return View();
            }
            else
            {
                TempData["warning"] = "Invalid Username or Password ";
                return View();
            }

        }

    }
}
