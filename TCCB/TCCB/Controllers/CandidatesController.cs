using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Models.DTO;
using TCCB.Repositories.Interfaces;

namespace TCCB.Controllers
{
    [RoutePrefix("hosoungtuyen")]
    public class CandidatesController : Controller
    {
        IRegistrationInterviewRepository registrationInterviewRepository;
        IProvinceRepository provinceRepository;
        IDistrictRepository districtRepository;
        IWardRepository wardRepository;
        ITrainningCategoryRepository trainningCategoryRepository;
        IGraduationClassficationRepository graduationClassficationRepository;
        ISpecializedTrainingRepository specializedTrainingRepository;
        IHighestLevelEducationRepository highestLevelEducationRepository;
        IStatusWorikingInEducationRepository statusWorikingInEducationRepository;
        IInformationTechnologyDegree informationTechnologyDegree;
        IForeignLanguageRepository foreignLanguageRepository;
        ISubjectRepository subjectRepository;
        IDegreeClassificationRepository degreeClassificationRepository;
        ISchoolDegreeRepository degreeRepository;

        public CandidatesController(IRegistrationInterviewRepository registrationInterviewRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, ITrainningCategoryRepository trainningCategoryRepository, IGraduationClassficationRepository graduationClassficationRepository, ISpecializedTrainingRepository specializedTrainingRepository, IHighestLevelEducationRepository highestLevelEducationRepository, IStatusWorikingInEducationRepository statusWorikingInEducationRepository, IInformationTechnologyDegree informationTechnologyDegree, IForeignLanguageRepository foreignLanguageRepository, ISubjectRepository subjectRepository, IDegreeClassificationRepository degreeClassificationRepository, ISchoolDegreeRepository degreeRepository)
        {
            this.registrationInterviewRepository = registrationInterviewRepository;
            this.provinceRepository = provinceRepository;
            this.districtRepository = districtRepository;
            this.wardRepository = wardRepository;
            this.trainningCategoryRepository = trainningCategoryRepository;
            this.graduationClassficationRepository = graduationClassficationRepository;
            this.specializedTrainingRepository = specializedTrainingRepository;
            this.highestLevelEducationRepository = highestLevelEducationRepository;
            this.statusWorikingInEducationRepository = statusWorikingInEducationRepository;
            this.informationTechnologyDegree = informationTechnologyDegree;
            this.foreignLanguageRepository = foreignLanguageRepository;
            this.subjectRepository = subjectRepository;
            this.degreeClassificationRepository = degreeClassificationRepository;
            this.degreeRepository = degreeRepository;
        }






        // GET: Candidates
        [Route("", Name = "hosoungtuyen")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("kiemtrahople/{registrationId}/{identifyCard}")]
        [HttpGet]
        public ActionResult IsValidToUpdate(int registrationId, string identifyCard)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdAndIdentifyCard(registrationId, identifyCard);

            if (registrationInterview == null)
            {
                return Json(new ResponseResult(403, "Không tìm thấy ứng viên. Vui lòng kiểm tra lại số CMND hoặc mã hồ sơ", null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.ReviewedBy != null)
            {
                return Json(new ResponseResult(403, "Hết hạn để sửa thông tin ứng tuyển", null), JsonRequestBehavior.AllowGet);
            }
            var registrationInterviewJson = JsonConvert.SerializeObject(registrationInterview,
            Formatting.None,
            new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Json(new ResponseResult(200, "success", null), JsonRequestBehavior.AllowGet);
        }
        [Route("capnhat/{registrationId}/{identifyCard}")]
        [HttpGet]        
        public ActionResult UpdateRegistrationInterview(int registrationId, string identifyCard)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdAndIdentifyCard(registrationId, identifyCard);
            if (registrationInterview == null || registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.ReviewedBy != null)
            {
                return RedirectToRoute("hosoungtuyen");
            }
            List<Province> province = provinceRepository.GetProvinceByCountryId(237);
            List<District> districtsCurrentLiving = districtRepository.GetDistrictByProvinceId(79);
            List<Ward> wardsCurrentLiving = wardRepository.GetWardByDistrictId(registrationInterview.CurrentLivingAddress.Ward.DistrictID);
            List<District> districtsHouseHold = districtRepository.GetDistrictByProvinceId(registrationInterview.HouseHold.Ward.District.ProvinceId);
            List<Ward> wardsHouseHold = wardRepository.GetWardByDistrictId(registrationInterview.HouseHold.Ward.DistrictID);
            List<TrainningCategory> trainningCategories = trainningCategoryRepository.GetTrainningCategories();
            List<GraduationClassfication> graduationClassfication = graduationClassficationRepository.GetGraduationClassfications();
            List<SpecializedTraining> specializedTrainings = specializedTrainingRepository.GetSpecializedTrainings();
            List<HighestLevelEducation> highestLevelEducations = highestLevelEducationRepository.GetHighestLevelEducations();
            List<StatusWorikingInEducation> statusWorikingInEducations = statusWorikingInEducationRepository.GetStatusWorikingInEducations();
            List<InfomationTechnologyDegree> infomationTechnologyDegrees = informationTechnologyDegree.GetAllInfomationTechnologyDegree();
            List<ForeignLanguageCertification> foreignLanguageCertifications = foreignLanguageRepository.GetAllForeignLanguageCertification();
            List<Subject> subjects = subjectRepository.GetSubjects();
            List<DegreeClassification> degreeClassifications = degreeClassificationRepository.GetDegreeClassifications();
            List<SchoolDegree> schoolDegrees = degreeRepository.GetSchoolDegrees();
            

            CandidateModelInOneView candidateModelInOneView = new CandidateModelInOneView(province, districtsCurrentLiving, wardsCurrentLiving, districtsHouseHold, wardsHouseHold, registrationInterview, trainningCategories, graduationClassfication, highestLevelEducations, specializedTrainings, statusWorikingInEducations, infomationTechnologyDegrees,foreignLanguageCertifications, subjects, degreeClassifications, schoolDegrees);
           
            return View(candidateModelInOneView);
        }
        [Route("postcapnhat")]
        [HttpPost]
        public ActionResult PostCapNhat(RegistrationInterviewDTO registrationInterviewDTO)
        {            
            RegistrationInterview registrationInterview = registrationInterviewRepository.UpdateRegistrationInterview(registrationInterviewDTO);
            if (registrationInterview == null)
            {
                return Json(new ResponseResult(403, "Something went wrong when updated", null));
            }                      
            return Json(new ResponseResult(200, "success", null));
        }
        [Route("inhoso/{id}")]
        [HttpGet]
        public ActionResult PrintRegistrationInterview(int id)
        {
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdWithDetail(id);
            return View(registrationInterview);
        }
    }
}
