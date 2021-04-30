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
    public class SubjectMaterial
    {
        [Key]
        public int SubjectMaterialID { get; set; }

        public int SubjectID { get; set; }

        public string MaterialFile { get; set; }

        public string MaterialName { get; set; }

        public virtual Subject Subjects { get; set; }
    }
}