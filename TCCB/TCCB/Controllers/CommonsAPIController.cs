using Newtonsoft.Json;
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
    
    public class CommonsAPIController : Controller
    {
        IWardRepository wardRepository;
        IDistrictRepository districtRepository;

        public CommonsAPIController(IWardRepository wardRepository, IDistrictRepository districtRepository)
        {
            this.wardRepository = wardRepository;
            this.districtRepository = districtRepository;
        }

        [Route("getWardByDistrictId/{id}")]
        [HttpGet]
        // GET: CommonsAPI
        public ActionResult GetWardByDistrictId(int id)
        {
            List<Ward> wards = wardRepository.GetWardByDistrictId(id);
            var wardsJson = JsonConvert.SerializeObject(wards,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(new ResponseResult(200, "success", wardsJson), JsonRequestBehavior.AllowGet);
        }

        [Route("getDistrictByProvinceId/{id}")]
        [HttpGet]
        public ActionResult GetDistrictByProvinceId(int id)
        {
            List<District> districts = districtRepository.GetDistrictByProvinceId(id);
            var districtsJson = JsonConvert.SerializeObject(districts,
          Formatting.None,
          new JsonSerializerSettings()
          {
              ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          });
            return Json(new ResponseResult(200, "success", districtsJson), JsonRequestBehavior.AllowGet);
        }
    }
}