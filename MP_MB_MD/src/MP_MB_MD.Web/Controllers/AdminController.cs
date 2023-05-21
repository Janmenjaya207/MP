using CA.SharedKernel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MP_MB_MD.Core.Abstract;
using MP_MB_MD.Core.Modal;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using MP_MB_MD.Infrastructure.Data;
using MP_MB_MD.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MB_MD.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository<Manage_User> Userr;
        private readonly IRepository<Block_Ulb> block;
        private readonly IRepository<Gram_Panchayat> grampanchayat;
        private readonly IRepository<Department_Table> departmenttable;
        private readonly IRepository<Mst_UserType> usertype;
        private readonly IRepository repositoryInterface;
        AppDbContext con;
        public AdminController(IRepository _repositoryInterface, AppDbContext obj, IRepository<Manage_User> _User, IRepository<Block_Ulb> _block, IRepository<Gram_Panchayat> _grampanchayat,
            IRepository<Department_Table> _departmenttable, IRepository<Mst_UserType> _usertype)
        {
            this.repositoryInterface = _repositoryInterface;
            this.con = obj;
            this.Userr = _User;
            this.block = _block;
            this.grampanchayat = _grampanchayat;
            this.departmenttable = _departmenttable;
            this.usertype = _usertype;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }
      
        public IActionResult Manager_User(int id)
        {
            if (id != 0)
            {
                
                var data = con.Mst_UserType.ToList();
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data)
                {
                    li1.Add(new SelectListItem
                    {
                        Text = item.User_Type,
                        Value = item.User_Type_Id.ToString(),
                    });
                }

                ViewBag.usertype = li1;


                var data1 = con.Block_Ulb.Where(x => x.District_Id == 9).ToList();
                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data1)
                {
                    li2.Add(new SelectListItem
                    {
                        Text = item.Block_Ulb_Name,
                        Value = item.Block_Ulb_Id.ToString(),
                    });
                }

                ViewBag.block = li2;


                var data2 = con.Gram_Panchayat.Where(x => x.DistrictId == 9).ToList();
                List<SelectListItem> li3 = new List<SelectListItem>();
                li3.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data2)
                {
                    li3.Add(new SelectListItem
                    {
                        Text = item.GRAM_PANCHAYAT_Name,
                        Value = item.GarmPanchayat_Id.ToString(),
                    });
                }

                ViewBag.Grampanchayat = li3;

                var data3 = con.Department_Table.ToList();
                List<SelectListItem> li4 = new List<SelectListItem>();
                li4.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data3)
                {
                    li4.Add(new SelectListItem
                    {
                        Text = item.Department,
                        Value = item.Id.ToString(),
                    });
                }

                ViewBag.department = li4;

                var data33 = con.Manage_User.Where(x => x.User_Id == id).FirstOrDefault();
                Manage_UserModel obj = new Manage_UserModel();
                obj.User_Type = data33.User_Type;
                obj.User_Id = data33.User_Id;
                obj.Name = data33.Name;
                obj.Email_Id = data33.Email_Id;
                obj.User_name = data33.User_name;
                obj.Mobile_no = data33.Mobile_no;
                obj.Password = MainModel.DecodeBase64(data33.Password) ;
                obj.Grampanchayat=Convert.ToInt32( data33.Grampanchayat);
                obj.Block = Convert.ToInt32(data33.Block);
                obj.Department_Id= Convert.ToInt32(data33.Department_Id);
                obj.Department_Desc= data33.Department_NameDescription;
                return View(obj);

            }
            else
            {
                var data = con.Mst_UserType.ToList();
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data)
                {
                    li1.Add(new SelectListItem
                    {
                        Text = item.User_Type,
                        Value = item.User_Type_Id.ToString(),
                    });
                }

                ViewBag.usertype = li1;


                var data1 = con.Block_Ulb.Where(x => x.District_Id == 9).ToList();
                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data1)
                {
                    li2.Add(new SelectListItem
                    {
                        Text = item.Block_Ulb_Name,
                        Value = item.Block_Ulb_Id.ToString(),
                    });
                }

                ViewBag.block = li2;


                var data2 = con.Gram_Panchayat.Where(x => x.DistrictId == 9).ToList();
                List<SelectListItem> li3 = new List<SelectListItem>();
                li3.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data2)
                {
                    li3.Add(new SelectListItem
                    {
                        Text = item.GRAM_PANCHAYAT_Name,
                        Value = item.GarmPanchayat_Id.ToString(),
                    });
                }

                ViewBag.Grampanchayat = li3;

                var data3 = con.Department_Table.ToList();
                List<SelectListItem> li4 = new List<SelectListItem>();
                li4.Add(new SelectListItem { Text = "--Select--", Value = "0", });
                foreach (var item in data3)
                {
                    li4.Add(new SelectListItem
                    {
                        Text = item.Department,
                        Value = item.Id.ToString(),
                    });
                }

                ViewBag.department = li4;
                return View();
            }
        }



        [HttpPost]
        public async Task<IActionResult> Manager_User(Manage_UserModel Model)
        {
            try
            {
                int count = repositoryInterface.SaveMangeUser(Model);
                if (count== 1)
                {
                    TempData["msg"] = "<script>alert('Manage User Created Successfully')</script>";
                    return RedirectToAction("ManagerUserDetails", "Admin");

                }
                else
                {
                    TempData["msg"] = "<script>alert('Manage User updated Successfully')</script>";
                    return RedirectToAction("ManagerUserDetails", "Admin");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

        public async Task<IActionResult> ManagerUserDetails()
        {
            var listManageUser = con.Manage_User.ToList();
 
            var blockk = await block.ListAsync();
            var grampanchayatt = await grampanchayat.ListAsync();
            var departmenttablee = await departmenttable.ListAsync();
            var usertypee = await usertype.ListAsync();
            listManageUser = listManageUser.Where(x => x.IsActive == true).ToList();
            var appDtl = (from c in listManageUser
                          select new Manage_UserModel
                          {
                              User_Id = c.User_Id,
                              Name = c.Name,
                              Email_Id = c.Email_Id,
                              Mobile_no = c.Mobile_no,
                              User_name = c.User_name,

                              Blockname = blockk.Where(y => y.Block_Ulb_Id == c.Block).Select(y => y.Block_Ulb_Name).FirstOrDefault(),
                              grampanchayatnaME = grampanchayatt.Where(y => y.GarmPanchayat_Id == c.Grampanchayat).Select(y => y.GRAM_PANCHAYAT_Name).FirstOrDefault(),
                              Departmentname = departmenttablee.Where(y => y.Id == c.Department_Id).Select(y => y.Department).FirstOrDefault(),
                              User_Type = c.User_Type,
                              UserTypename= usertypee.Where(x=>x.User_Type_Id==c.User_Type).Select(y=>y.User_Type).FirstOrDefault()
                          }).OrderByDescending(x => x.User_Id).ToList();


            return View(appDtl);
        }

        [HttpPost]
        public JsonResult GetGrampanchayats(int blockId)
        {
            var data3 = con.Gram_Panchayat.Where(x => x.Block_Ulb_Id == blockId).ToList();
            List<SelectListItem> li4 = new List<SelectListItem>();

            foreach (var item in data3)
            {
                li4.Add(new SelectListItem
                {
                    Text = item.GRAM_PANCHAYAT_Name,
                    Value = item.GarmPanchayat_Id.ToString(),
                });
            }

            var options = li4.Select(x => new { value = x.Value, text = x.Text });
            return Json(options);
        }
    }
}
