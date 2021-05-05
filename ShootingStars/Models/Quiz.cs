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
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; }

        public List<string> Questions { get; set; }

        public List<string> Answers { get; set; }

        public string QuizName { get; set; }

        public int SubjectID { get; set; }

        public virtual Subject Subject { get; set; }

        public List<StudentQuiz> StudentQuizzes { get; set; }

    }
}