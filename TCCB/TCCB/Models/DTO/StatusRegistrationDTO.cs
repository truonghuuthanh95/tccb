using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCB.Models.DTO
{
    public class StatusRegistrationDTO
    {
        public int Registed { get; set; }
        public int Completed { get; set; }
        public int Inprocess { get; set; }
        public int Reviewed { get; set; }

        public StatusRegistrationDTO(int registed, int completed, int inprocess, int reviewed)
        {
            Registed = registed;
            Completed = completed;
            Inprocess = inprocess;
            Reviewed = reviewed;
        }
    }
}