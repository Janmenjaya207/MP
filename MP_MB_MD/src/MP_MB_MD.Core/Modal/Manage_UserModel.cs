using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.Modal
{
  public   class Manage_UserModel
    {
        public int User_Id { get; set; }
        public int User_Type { get; set; }
        public string Name { get; set; }
        public string Mobile_no { get; set; }
        public string Email_Id { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public int Block { get; set; }
        public int Grampanchayat { get; set; }

        public int Department_Id { get; set; }
        public string Department_Desc { get; set; }
        public string Blockname { get; set; }
            public string grampanchayatnaME { get;set;}
        public string Departmentname { get; set; }
    }
}
