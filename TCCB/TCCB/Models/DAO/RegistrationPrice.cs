namespace TCCB.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrationPrice")]
    public partial class RegistrationPrice
    {
        public int Id { get; set; }

        public int? Value { get; set; }

        public int? ManagementUnitId { get; set; }

        [StringLength(200)]
        public string CollectContent { get; set; }

        [StringLength(100)]
        public string ValueByWord { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateComeTo { get; set; }

        public virtual ManagementUnit ManagementUnit { get; set; }
    }
}
