using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShootingStars.Models
{
    public class English4
    {
        [Key]
        public string English4Id { get; set; }
        [Display(Name ="English Subject Name")]
        public string English4title { get; set; }
        [Display(Name ="English Subject Description")]
        public string English4Descr { get; set; }
        [Display(Name ="English Document")]
        public string English4Doc { get; set; }
        [Display(Name = "English Image")]
        public string English4Image { get; set; }
        [Display(Name ="English Teacher Name")]
        public string English4Teacher { get; set; }
        [Display(Name ="English Teacher Photo")]
        public string English4TeacherImg { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}