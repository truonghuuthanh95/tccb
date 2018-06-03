namespace TCCB.Models.DAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactInfomation")]
    public partial class ContactInfomation
    {
        public int Id { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Position { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        public int? ManagementUnitId { get; set; }

        public virtual ManagementUnit ManagementUnit { get; set; }
    }
}
