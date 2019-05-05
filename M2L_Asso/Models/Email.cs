using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace M2L_Asso.Models
{
    public class Email
    {
        [Required, Display(Name = "Votre Nom")]
        public string FromName { get; set; }
        [Required, Display(Name = "Votre Mail"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }

    }
}