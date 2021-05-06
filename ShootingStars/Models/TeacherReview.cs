using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShootingStars.Models
{
    public class TeacherReview
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select your grade ")]
        public string Grade { get; set; }
        [Display(Name = "Subject Name:")]
        [Required(ErrorMessage = "Please enter the subject that you are reviewing")]
        public string Class { get; set; }
        [Display(Name = "Teacher's Name:")]
        [Required(ErrorMessage = "Please enter your teachers name")]
        public string Name { get; set; }
        [Display(Name = "Treats pupils with respect?")]
        public string Q1 { get; set; }
        [Display(Name = "Capable of answering questions correctly?")]
        public string Q2 { get; set; }
        [Display(Name = "Communicates the work clearly?")]
        public string Q3 { get; set; }
        [Display(Name = "Assigns relevant homework?")]
        public string Q4 { get; set; }
        [Display(Name = "Allows sufficient time to complete homework and assignments?")]
        public string Q5 { get; set; }
        [Display(Name = "Provides constructive feedback on graded material?")]
        public string Q6 { get; set; }
        [Display(Name = "Keeps pupils informed about their marks and progress?")]
        public string Q7 { get; set; }
        [Display(Name = "Are you satisfied with your teacher's overall performance?")]
        public string Q8 { get; set; }
        [Display(Name = "Is there anything that you are unhappy about with regards to your teacher?")]
        public string Q9 { get; set; }
        [Display(Name = "Do you have any suggestion on how your teacher can improve on their teaching skills?")]
        public string Q10 { get; set; }
    }
}