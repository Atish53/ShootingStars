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
    public class StudentQuiz
    {
        [Key]
        public int StudentQuizID { get; set; }

        public string StudentEmail { get; set; }

        public int QuizID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime Duration { get; set; }

        public int Mark { get; set; }

        public virtual Student Student { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}

