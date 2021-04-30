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
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        public string TeacherName { get; set; }

        public string TeacherEmail { get; set; }

        public string TeacherPhoneNo { get; set; }

        public List<Chat> Chats { get; set; }
    }
}