using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Models.DTO;
using TCCB.Repositories.Interfaces;

namespace TCCB.Controllers
{
    public class CashiersController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;
        IRegistrationPriceRepository registrationPriceRepository;
        IManagementUnitRepository managementUnitRepository;

        public CashiersController(IRegistrationInterviewRepository registrationInterviewRepository, IRegistrationPriceRepository registrationPriceRepository, IManagementUnitRepository managementUnitRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
            this.registrationPriceRepository = registrationPriceRepository;
            this.managementUnitRepository = managementUnitRepository;
        }



        // GET: Cashiers
        [Route("xuathoadon")]
        public ActionResult Index()
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 3)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            
            RegistrationPrice registrationPrice = registrationPriceRepository.GetRegistrationPriceByManagementUnitId(usersession.ManagementUnitId);
            ManagementUnit managementUnit = managementUnitRepository.GetManagementById(usersession.ManagementUnitId);
            Session.Add(CommonConstants.REGISTRATION_PRICE, registrationPrice);
            Session.Add(CommonConstants.MANAGEMENTUNIT, managementUnit);
            return View(registrationPrice);
        }

        // GET: Cashiers/Details/5
        [Route("kiemtracmnd")]
        [HttpGet]
        public ActionResult IsValidToRegistrationInterview(string identifyCard)
        {
            Account account = (Account)Session[CommonConstants.USER_SESSION];
            List<RegistrationInterview> registrationInterviews = registrationInterviewRepository.GetRegistrationInterviewByIdentidfyCardAndManagementUnitId(identifyCard, account.ManagementUnitId);
            if (registrationInterviews.Any())
            {
                foreach (RegistrationInterview item in registrationInterviews)
                {
                    int year = item.CreatedAt.Value.Year;
                    if (item.IsPass == true)
                    {
                        return Json( new ResponseResult(403, "Ứng viên này đã đậu ở kì thi tuyển năm " + item.CreatedAt.Value.Year + ", và đã được phân đơn vị công tác", null), JsonRequestBehavior.AllowGet) ;                       
                    }
                    else if (year == DateTime.Now.Year)
                    {

                        return Json( new ResponseResult(403, "Ứng viên này đã đăng kí trước đó. Mã đăng kí là " + item.Id.ToString(), null), JsonRequestBehavior.AllowGet);
                    }
                }
            }

            return Json(new ResponseResult(200, "valid", null), JsonRequestBehavior.AllowGet);
        }
        [Route("taomoiungvien")]
        [HttpGet]
        public ActionResult PostRegistrationInterview(RegistrationInterviewRegister registrationInterviewRegister)
        {             
            Account account = (Account)Session[CommonConstants.USER_SESSION];
            if (account == null || account.RoleId != 3)
            {
                return RedirectToRoute("login");
            }
            RegistrationPrice registrationPrice = (RegistrationPrice)Session[CommonConstants.REGISTRATION_PRICE];

            RegistrationInterview registrationInterview = registrationInterviewRepository.CreateRegistrationInterview(registrationInterviewRegister.CandidateName, registrationInterviewRegister.IdentifyCard, account.ManagementUnitId, registrationPrice.Value, account.Id);
            Session.Add(CommonConstants.REGISTED_INTERVIEW, registrationInterview);
            return RedirectToRoute("inhoadon");

        }

        [Route("inhoadon", Name ="inhoadon")]
        [HttpGet]
        public ActionResult ExportBill()
        {
            Account account = (Account)Session[CommonConstants.USER_SESSION];
            if (account == null || account.RoleId != 3)
            {
                return RedirectToRoute("login");
            }
        
            return View();

        }
        // POST: Cashiers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cashiers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cashiers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cashiers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cashiers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
