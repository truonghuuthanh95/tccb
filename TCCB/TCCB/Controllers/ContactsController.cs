using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Repositories.Interfaces;

namespace TCCB.Controllers
{
    public class ContactsController : Controller
    {
        IContactInfomationRepository contactInfomationRepository;

        public ContactsController(IContactInfomationRepository contactInfomationRepository)
        {
            this.contactInfomationRepository = contactInfomationRepository;
        }

        // GET: Contacts
        [Route("lienhe")]
        public ActionResult Index()
        {
            List<ContactInfomation> contactInfomations = contactInfomationRepository.GetContactInfomations();
            return View(contactInfomations);
        }
    }
}