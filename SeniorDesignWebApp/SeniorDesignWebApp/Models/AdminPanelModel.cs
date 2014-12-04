using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorDesignWebApp.Models
{
    public class AdminPanelModel
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}