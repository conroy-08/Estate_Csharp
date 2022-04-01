using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstateProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class contact
    {

        public int id { get; set; }

        public int? user_id { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string fullname { get; set; }

        [Required]
        [StringLength(255)]
        public string phone { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        [Required]
        [StringLength(255)]
        public string status { get; set; }

        [Required]
        public string messages { get; set; }
        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }

        public virtual user user { get; set; }

    }
}