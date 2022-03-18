namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class transaction
    {
        public int id { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        [StringLength(255)]
        public string note { get; set; }

        public int? customerid { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        [StringLength(255)]
        public string createdby { get; set; }

        [StringLength(255)]
        public string modifiedby { get; set; }

        public int? staffid { get; set; }

        public virtual customer customer { get; set; }

        public virtual user user { get; set; }
    }
}
