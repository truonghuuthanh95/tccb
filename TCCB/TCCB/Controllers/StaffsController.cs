using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCB.Models.DAO;
using TCCB.Models.DTO;
using TCCB.Repositories.Interfaces;
using TCCB.Respositories.Interfaces;

namespace TCCB.Controllers
{
    public class StaffsController : Controller
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
        ISubjectsRequiredSchoolDegreeRepository subjectsRequiredSchoolDegreeRepository;

        public StaffsController(IRegistrationInterviewRepository registrationInterviewRepository, IProvinceRepository provinceRepository, IDistrictRepository districtRepository, IWardRepository wardRepository, ITrainningCategoryRepository trainningCategoryRepository, IGraduationClassficationRepository graduationClassficationRepository, ISpecializedTrainingRepository specializedTrainingRepository, IHighestLevelEducationRepository highestLevelEducationRepository, IStatusWorikingInEducationRepository statusWorikingInEducationRepository, IInformationTechnologyDegree informationTechnologyDegree, IForeignLanguageRepository foreignLanguageRepository, ISubjectRepository subjectRepository, IDegreeClassificationRepository degreeClassificationRepository, ISchoolDegreeRepository degreeRepository, ISubjectsRequiredSchoolDegreeRepository subjectsRequiredSchoolDegreeRepository)
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
            this.subjectsRequiredSchoolDegreeRepository = subjectsRequiredSchoolDegreeRepository;
        }





        // GET: Staffs
        [Route("raxoathoso", Name = "raxoathoso")]
        [HttpGet]
        public ActionResult Index()
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 4 && usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            return View();
        }
        [Route("canbokiemtramahosohople/{id}")]
        [HttpGet]
        public ActionResult CheckValidIdentifyCard(int id)
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 4 && usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(id);
            if (registrationInterview == null)
            {
                return Json(new ResponseResult(403, "Không tìm thấy hồ sơ, vui lòng kiểm tra lại mã hồ sơ", null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.CreatedAtManagementUnitId != usersession.ManagementUnitId)
            {
                return Json(new ResponseResult(403, "Hồ sơ này không thuộc về " + usersession.ManagementUnit.Name, null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.ReviewedBy != null)
            {
                return Json(new ResponseResult(403, "Hồ sơ này đã được rà xoát", null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year)
            {
                return Json(new ResponseResult(403, "Hồ sơ này thuộc về năm trước đó", null), JsonRequestBehavior.AllowGet);
            }
            else if (registrationInterview.PhoneNumber == null)
            {
                return Json(new ResponseResult(403, "Hồ sơ này chưa hoàn tất cập nhật hồ sơ sau khi đăng kí", null), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResponseResult(200, "Success", null), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("canbocapnhathoso/{id}")]
        [HttpGet]
        public ActionResult ApproveRegistration(int id)
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 4 && usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewByIdWithDetail(id);
            if (registrationInterview == null || registrationInterview.PhoneNumber == null || registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.ReviewedBy != null || registrationInterview.CreatedAtManagementUnitId != usersession.ManagementUnitId)
            {
                return RedirectToRoute("raxoathoso");
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
            List<SubjectRequiredSchoolDegree> subjectRequiredSchoolDegrees = subjectsRequiredSchoolDegreeRepository.GetSubjectRequiredSchoolDegreesBySchoolDegree(registrationInterview.SchoolDegreeIdExpectedTeach);

            CandidateModelInOneView candidateModelInOneView = new CandidateModelInOneView(province, districtsCurrentLiving, wardsCurrentLiving, districtsHouseHold, wardsHouseHold, registrationInterview, trainningCategories, graduationClassfication, highestLevelEducations, specializedTrainings, statusWorikingInEducations, infomationTechnologyDegrees, foreignLanguageCertifications, subjects, degreeClassifications, schoolDegrees);

            return View(candidateModelInOneView);
        }
        [Route("hosohople")]
        [HttpPost]
        public ActionResult IsvalidRegistration(RegistrationInterviewDTO registrationInterviewDTO)
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 4 && usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            registrationInterviewDTO.ReviewedBy = usersession.Id;
            RegistrationInterview registrationInterview = registrationInterviewRepository.UpdateRegistrationInterview(registrationInterviewDTO);
            if (registrationInterview == null)
            {
                return Json(new ResponseResult(403, "Something went wrong when updated", null));
            }
            return Json(new ResponseResult(200, "success", null));
        }
        [Route("hosohople/capnhatthanhcong/{id}")]
        [HttpGet]
        public ActionResult ApprovedRegistration(int id)
        {
            Account usersession = (Account)Session[CommonConstants.USER_SESSION];
            if (usersession == null || usersession.RoleId != 4 && usersession.RoleId != 2)
            {
                Session.RemoveAll();
                return RedirectToRoute("login", null);
            }
            RegistrationInterview registrationInterview = registrationInterviewRepository.GetRegistrationInterviewById(id);
            if (registrationInterview == null || registrationInterview.PhoneNumber == null || registrationInterview.CreatedAt.Value.Year != DateTime.Now.Year || registrationInterview.CreatedAtManagementUnitId != usersession.ManagementUnitId)
            {
                return RedirectToRoute("raxoathoso");
            }
            ViewBag.RegistrationInterviewId = id;
            return View();
        }
    }
}