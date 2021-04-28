using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShootingStars.Models
{
    public class English5
    {
        [Key]
        public string English5Id { get; set; }
        [Display(Name = "English Subject Name")]
        public string English5title { get; set; }
        [Display(Name = "English Subject Description")]
        public string English5Descr { get; set; }
        [Display(Name = "English Document")]
        public string English5Doc { get; set; }
        [Display(Name = "English Image")]
        public string English5Image { get; set; }
        [Display(Name = "English Teacher Name")]
        public string English5Teacher { get; set; }
        [Display(Name = "English Teacher Photo")]
        public string English5TeacherImg { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}