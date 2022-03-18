namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("assignmentbuilding")]
    public partial class assignmentbuilding
    {
        public int id { get; set; }

        public int? staffid { get; set; }

        public int? buildingid { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        [StringLength(255)]
        public string createdby { get; set; }

        [StringLength(255)]
        public string modifiedby { get; set; }

        public virtual building building { get; set; }

        public virtual user user { get; set; }
    }
}
