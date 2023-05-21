using CA.SharedKernel;
using MP_MB_MD.Core.Abstract;
using MP_MB_MD.Core.Modal;
using MP_MB_MD.Core.ProjectAggregate.Entity;
using MP_MB_MD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MP_MB_MD.Infrastructure.Concreate
{
    public class Repository: IRepository
    {
        public bool SendMail(string to, string subject, string body)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.From = new MailAddress("transactiondomain@gmail.com");
            mail.Subject = subject;
            string Body = body;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("transactiondomain@gmail.com", "zaienkklwnmholof"); // Enter seders User name and password       
            smtp.EnableSsl = true;
            smtp.Send(mail);

            return true;
        }
        AppDbContext con;

        public Repository(AppDbContext obj)
        {
            this.con = obj;
        }
 
        public int Grievance(Grievance ee)
        {
            using (var transaction = con.Database.BeginTransaction())
            {
                try
                {
                    if(ee.Id!=0)
                    {
                        var grievance = con.Grievance.Where(x => x.Id == ee.Id).FirstOrDefault();
                        grievance.User_Id = ee.User_Id;
                        grievance.Name_Of_Applicant = ee.Name_Of_Applicant;
                        grievance.FatherOrHusbandName = ee.FatherOrHusbandName;
                        grievance.MobileNo = ee.MobileNo;
                        grievance.Email_Id = ee.Email_Id;
                        grievance.VillageName = ee.VillageName;
                        grievance.Post_Office_Name = ee.Post_Office_Name;
                        grievance.Pincode = ee.Post_Office_Name;
                        grievance.Attachment = ee.Attachment;
                        grievance.Details_Of_Consern = ee.Details_Of_Consern;
                        grievance.CreatedOn = DateTime.Now;
                        grievance.Attachment = ee.Attachment;
                        con.SaveChanges();
                        transaction.Commit();
                        return 2;
                       
                    }
                    else
                    {
                        Grievance grievance = new Grievance();
                        grievance.User_Id = ee.User_Id;
                        grievance.Name_Of_Applicant = ee.Name_Of_Applicant;
                        grievance.FatherOrHusbandName = ee.FatherOrHusbandName;
                        grievance.MobileNo = ee.MobileNo;
                        grievance.Email_Id = ee.Email_Id;
                        grievance.VillageName = ee.VillageName;
                        grievance.Post_Office_Name = ee.Post_Office_Name;
                        grievance.Pincode = ee.Post_Office_Name;
                        grievance.Attachment = ee.Attachment;
                        grievance.Details_Of_Consern = ee.Details_Of_Consern;
                        grievance.CreatedOn = DateTime.Now;
                        grievance.Attachment = ee.Attachment;
                        grievance.IsActive = true;
                        grievance.IsDelete = false;
                        con.Grievance.Add(grievance);
                        con.SaveChanges();
                        transaction.Commit();
                        return 1;
                        
                    }
                 
                 

                  
                  
                  

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public int SaveMangeUser(Manage_UserModel adminModel)
        {
            Manage_User mnguser = new Manage_User();
            mnguser.Name = adminModel.Name;
            mnguser.Email_Id = adminModel.Email_Id;
            mnguser.Mobile_no = adminModel.Mobile_no;
            mnguser.User_Type = adminModel.User_Type;
            mnguser.Block = adminModel.Block;
            mnguser.Grampanchayat = adminModel.Grampanchayat;
            mnguser.Password = MainModel.EncodeBase64(adminModel.Password);
            mnguser.User_name = adminModel.User_name;
            con.Manage_User.Add(mnguser);
            con.SaveChanges();
           
            string sub = "Username & Password Credential";
            var body = new StringBuilder();
            body.AppendFormat("Dear {0}\n", mnguser.Name + ",");
            //body.AppendFormat("Dear Candidate,");
            body.AppendLine("<br/>");

            body.AppendLine(@"Your User Name Is" + ": " + "" + mnguser.User_name + " & Password Is:" + MainModel.DecodeBase64(mnguser.Password) + ".");
            body.AppendLine("<br/>");
            body.AppendLine(@"Use This Login Credential For LogIn Purpose");
            body.AppendLine("<br/>");
            body.AppendLine(@"<a href =''></a>");
            body.AppendLine("<br/>");
            body.AppendLine("<br/>");
            body.AppendLine("<br/>");
            body.Append("<b>");
            body.Append("Regards,");
            body.AppendLine("<br/>");
            body.Append("APICOL");
            body.Append("</b>");

            body.AppendLine("<br/>");


            string mailbodyy = body.ToString();
            SendMail(mnguser.Email_Id, sub, body.ToString());
            return 1;
        }

    }
}
