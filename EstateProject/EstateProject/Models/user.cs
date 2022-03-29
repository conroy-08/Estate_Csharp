namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
<<<<<<< HEAD
            buildings = new HashSet<building>();
        }

=======
//<<<<<<< HEAD

            contacts = new HashSet<contact>();

        

//=======
            buildings = new HashSet<building>();
        }

//>>>>>>> 54f713d321f3dd6aeaf917aaebcbf82785796931
>>>>>>> c93ae29b451475b8effce04c46f8fa22c88e52c9
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

        [StringLength(255)]
        public string image { get; set; }

<<<<<<< HEAD
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<building> buildings { get; set; }
=======

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contact> contacts { get; set; }
//=======
        public virtual ICollection<building> buildings { get; set; }
//>>>>>>> 54f713d321f3dd6aeaf917aaebcbf82785796931
>>>>>>> c93ae29b451475b8effce04c46f8fa22c88e52c9
    }
}
