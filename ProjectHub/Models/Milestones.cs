using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class Milestones
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }

        [Display(Name = "Projekt Phase ID")]
        public int ProjectPhaseId { get; set; }

        public virtual ProjectPhase ProjectPhase { get; set; }
    }
}