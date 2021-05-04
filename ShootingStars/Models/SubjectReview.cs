using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ShootingStars.Models
{
    public class SubjectReview
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Did the quality of the notes meet all your expectations?")]
        public string Question1 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Were the notes well structured?")]
        public string Question2 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Did the notes explain the concepts clearly?")]
        public string Question3 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Did the tests compliment the notes adequately?")]
        public string Question4 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Were all the resources up to date in your personal opinion?")]
        public string Question5 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others. :)")]
        [Display(Name = "Were there enough examples that explained all the concepts covered ?")]
        public string Question6 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of  the content on this site for you and others. :)")]
        [Display(Name = "Would you recommend Shooting Stars to a friend based of your experience?")]
        public string Question7 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving the quality of the content on this site for you and others :)")]
        [Display(Name = "Did each set of notes give you the outcome you expected ?")]
        public string Question8 { get; set; }
        [Required(ErrorMessage = "Please select an option as this helps in improving of the quality of the content on this site for you and others :)")]
        [Display(Name = "Did the notes and time allocation that was set per section help you to achieve your goals in the subject?")]
        public string Question9 { get; set; }
        [Display(Name = "Please add any comment you may have in regard to the subject, in order for us to provide nothing but the best expirience and content for you.")]
        public string Question10 { get; set; }
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}