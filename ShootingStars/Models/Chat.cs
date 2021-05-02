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
    public class Chat
    {
        [Key]
        public int ChatID { get; set; }

        public string StudentEmail { get; set; }

        public int TeacherID { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Student Student { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}