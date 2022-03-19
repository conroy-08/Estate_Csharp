namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            assignmentbuildings = new HashSet<assignmentbuilding>();
            assignmentcustomers = new HashSet<assignmentcustomer>();
            transactions = new HashSet<transaction>();
        }


        public HttpPostedFileBase imageFile { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string username { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string fullname { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string role { get; set; }

        public int status { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        [StringLength(255)]
        public string createdby { get; set; }

        [StringLength(255)]
        public string modifiedby { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignmentbuilding> assignmentbuildings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<assignmentcustomer> assignmentcustomers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaction> transactions { get; set; }
    }
}
