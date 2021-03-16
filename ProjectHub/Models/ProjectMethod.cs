using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class ProjectMethod
    {
        public int ID { get; set; }

        [Display(Name = "Vorgehensmodell Name")]
        public string Method { get; set; }


        public virtual ICollection<Phase> Phases { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}