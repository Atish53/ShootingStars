using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ShootingStars.Models
{
   
    public class Query
    {
        [Key]
        public int QueryID { get; set; }

        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Please enter a valid query.")]
        [StringLength(300)]
        public string Message { get; set; }

        [Required(ErrorMessage = "Please select the type of issue you are experiencing")]
        [Display(Name = "Type Of Query.")]
        public string QueryType { get; set; }

        public string Response { get; set; }

        public DateTime DateCreated { get; set; }

        public bool CompletionStatus { get; set; }

        public virtual Student Student { get; set; }
    }
}