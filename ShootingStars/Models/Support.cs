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
    public class Support
    {
        [Key]
        public int SupportID { get; set; }

        public string SupportName { get; set; }

        public string SupportEmail { get; set; }

        public string PhoneNo { get; set; }
    }
}