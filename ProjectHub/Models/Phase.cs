using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class Phase
    {
        public int ID { get; set; }

        [Display(Name = "Phasen Name")]
        public string Name { get; set; }

        [Display(Name = "Vorgehensmodell ID")]
        public int ProjectMethodID { get; set; }


        public virtual ProjectMethod ProjectMethod { get; set; }
    }
}