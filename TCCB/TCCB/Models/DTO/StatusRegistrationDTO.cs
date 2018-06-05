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

        public StatusRegistrationDTO(int registed, int completed, int inprocess)
        {
            Registed = registed;
            Completed = completed;
            Inprocess = inprocess;
        }
    }
}