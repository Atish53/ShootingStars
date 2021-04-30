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
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(80, MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Please enter your E-mail address.")]
        [StringLength(120)]
        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Please enter your phone number. ")]
        [StringLength(10)]
        public string StudentPhoneNumber { get; set; }

        public List<StudentQuiz> StudentQuizzes { get; set; }

        public List<Chat> Chats { get; set; }

        public List<Query> Queries { get; set; }
    }
}