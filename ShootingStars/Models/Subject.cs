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
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }

        public int SubjectGrade { get; set; }

        public string SubjectDescription { get; set; }

        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }

        public List<SubjectMaterial> SubjectMaterials { get; set; }

        public List<Quiz> Quizzes { get; set; }
    }
}