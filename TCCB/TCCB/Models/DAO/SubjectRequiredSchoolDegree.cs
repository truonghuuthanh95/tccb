namespace TCCB.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubjectRequiredSchoolDegree")]
    public partial class SubjectRequiredSchoolDegree
    {
        public int Id { get; set; }

        public int? SchoolDegreeId { get; set; }

        public int? SubjectId { get; set; }

        public virtual SchoolDegree SchoolDegree { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
