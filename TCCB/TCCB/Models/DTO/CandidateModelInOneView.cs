using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCB.Models.DAO;

namespace TCCB.Models.DTO
{
    public class CandidateModelInOneView
    {
        public List<Province> Provinces { get; set; }
        public List<District> DistrictsCurrentLiving { get; set; }
        public List<Ward> WardsCurrentLiving { get; set; }
        public List<District> DistrictsHouseHold { get; set; }
        public List<Ward> WardsHouseHold { get; set; }

        public RegistrationInterview RegistrationInterview { get; set; }
       
        public List<TrainningCategory> TrainningCategory { get; set; }
       
        public List<GraduationClassfication> GraduationClassfication { get; set; }
        
      
        public List<HighestLevelEducation> HighestLevelEducation { get; set; }
        
        public List<SpecializedTraining> SpecializedTraining { get; set; }
       
        public List<StatusWorikingInEducation> StatusWorikingInEducation { get; set; }
       
        public List<InfomationTechnologyDegree> InfomationTechnologyDegree { get; set; }
        
        public List<ForeignLanguageCertification> ForeignLanguageCertification { get; set; }
       
        public List<Subject> Subject { get; set; }
       
        public List<DegreeClassification> DegreeClassification { get; set; }
        public List<SchoolDegree> SchoolDegrees { get; set; }

        public CandidateModelInOneView(List<Province> provinces, List<District> districtsCurrentLiving, List<Ward> wardsCurrentLiving, List<District> districtsHouseHold, List<Ward> wardsHouseHold, RegistrationInterview registrationInterview, List<TrainningCategory> trainningCategory, List<GraduationClassfication> graduationClassfication, List<HighestLevelEducation> highestLevelEducation, List<SpecializedTraining> specializedTraining, List<StatusWorikingInEducation> statusWorikingInEducation, List<InfomationTechnologyDegree> infomationTechnologyDegree, List<ForeignLanguageCertification> foreignLanguageCertification, List<Subject> subject, List<DegreeClassification> degreeClassification, List<SchoolDegree> schoolDegrees)
        {
            Provinces = provinces;
            DistrictsCurrentLiving = districtsCurrentLiving;
            WardsCurrentLiving = wardsCurrentLiving;
            DistrictsHouseHold = districtsHouseHold;
            WardsHouseHold = wardsHouseHold;
            RegistrationInterview = registrationInterview;
            TrainningCategory = trainningCategory;
            GraduationClassfication = graduationClassfication;
            HighestLevelEducation = highestLevelEducation;
            SpecializedTraining = specializedTraining;
            StatusWorikingInEducation = statusWorikingInEducation;
            InfomationTechnologyDegree = infomationTechnologyDegree;
            ForeignLanguageCertification = foreignLanguageCertification;
            Subject = subject;
            DegreeClassification = degreeClassification;
            SchoolDegrees = schoolDegrees;
        }
    }
}