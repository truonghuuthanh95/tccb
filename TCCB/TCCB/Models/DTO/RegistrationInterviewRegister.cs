using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCCB.Models.DTO
{
    public class RegistrationInterviewRegister
    {
        [Required]
        public string IdentifyCard { get; set; }
        [Required]
        public string CandidateName { get; set; }       
    }
}