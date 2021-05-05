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
    public class QuestionAnswer
    {
        [Key]
        public int QuestionAnswerID { get; set; }

        public int QuizID { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}