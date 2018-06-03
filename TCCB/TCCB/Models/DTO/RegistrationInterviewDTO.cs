using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB.Models.DTO
{
    public class RegistrationInterviewDTO
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string CandidateFirstName { get; set; }
        [StringLength(50)]
        public string CandidateLastName { get; set; }
        public DateTime? DOB { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        public int? CreatedAtManagementUnitId { get; set; }

        public int? Aspirations01DistrictId { get; set; }

        public int? Aspirations02DistrictId { get; set; }

        public int? Aspirations03DistrictId { get; set; }

        public bool? IsPass { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? SubjectToInterviewId { get; set; }

        public int? ForeignLanguageDegreeId { get; set; }

        public int? InfomationTechnologyDegreeId { get; set; }

        public bool? IsMale { get; set; }

        public int? DegreeClassificationId { get; set; }

        public short? GraduatedAtYear { get; set; }

        public int? CurrentLivingAddressId { get; set; }
        public string CurrentLivingAddressHouseNumber { get; set; }
        public int? HouseHoldId { get; set; }

        public string HouseHoldHouseNumber { get; set; }

        public int? SchoolDegreeIdExpectedTeach { get; set; }

        public int? Price { get; set; }

        public int? SpecializedTranningId { get; set; }

        public bool? IsNienChe { get; set; }

        public double? GPA { get; set; }

        public double? CaptionProjectPoint { get; set; }

        public int? TrainningCatergoryId { get; set; }

        public int? HighestLevelEducationId { get; set; }

        public int? ReviewedBy { get; set; }

        public int? UniversityLocation { get; set; }

        [StringLength(200)]
        public string UniversityName { get; set; }

        public int? GraduationClassficationId { get; set; }

        public bool? IsHadNghiepVuSupham { get; set; }

        public int? StatusWorkingInEducationId { get; set; }
        public string NamVaoNghanh { get; set; } = "Không có";

        [StringLength(50)]
        public string MaNgach { get; set; } = "Không có";

        [StringLength(50)]
        public string HeSoLuong { get; set; } = "Không có";

        [StringLength(50)]
        public string MocNangLuongLansau { get; set; } = "Không có";
    }
}