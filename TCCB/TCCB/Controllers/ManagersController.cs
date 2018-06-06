using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Models.DTO;
using TCCB.Repositories.Interfaces;
using System.Net;
using System.IO;
using System.Net.Http.Headers;

namespace TCCB.Controllers
{
    [RoutePrefix("quanly")]
    public class ManagersController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;

        public ManagersController(IRegistrationInterviewRepository registrationInterviewRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
        }



        [Route("", Name = "quanly")]
        [HttpGet]
        public ActionResult Index()
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetAllRegistrationInterviewByManagementUnitId(usersession.ManagementUnitId);
            int completeRegistration = 0;
            int inprocessRegistration = 0;
            int validRegistration = 0;
            foreach (var item in registrationInterviews)
            {
                if (item.PhoneNumber != null)
                {
                    completeRegistration += 1;
                }
                else
                {
                    inprocessRegistration += 1;
                }
                if (item.ReviewedBy != null)
                {
                    validRegistration += 1;
                }
            }
            
            StatusRegistrationDTO statusRegistrationDTO = new StatusRegistrationDTO(registrationInterviews.Count, completeRegistration, inprocessRegistration, validRegistration);

            return View(statusRegistrationDTO);
        }
       
       [Route("xuatexcel/{id}")]
       [HttpGet]
        public async Task<ActionResult> ExportExcel(int id)
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }



            if (id == 2)
            {
                List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewsByManagementUnitIdCompleted(usersession.ManagementUnitId);
                string fileName = string.Concat("ds-hoanthanh.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Excel/" + fileName);
                await Utils.ExportExcel.GenerateXLSRegistrationCompleted(registrationInterviews, filePath);

                return File(filePath, "application/vnd.ms-excel", fileName);
            }
            else if (id == 3)
            {
                List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewsByManagementUnitIdInProcess(id);
                string fileName = string.Concat("ds-chuahoanthanh.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Excel/" + fileName);
                await Utils.ExportExcel.GenerateXLSRegistrationInprocess(registrationInterviews, filePath);

                return File(filePath, "application/vnd.ms-excel", fileName);
            }
            else if (id == 1)
            {
                List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetAllRegistrationInterviewByManagementUnitId(id);
                string fileName = string.Concat("ds-dangky.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Excel/" + fileName);
                await Utils.ExportExcel.GenerateXLSRegistrationRegisted(registrationInterviews, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }

            else
            {
                List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetAllRegistrationInterviewByManagementUnitIdValidRegistration(id);

                string fileName = string.Concat("ds-hoplehoso.xlsx");
                string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Utils/Excel/" + fileName);
                await Utils.ExportExcel.GenerateXLSRegistrationRegisted(registrationInterviews, filePath);
                return File(filePath, "application/vnd.ms-excel", fileName);
            }
                   

        }
    }
}