using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Projekt Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Projekt Beschreibung")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Bewilligungsdatum")]
        public DateTime ApprovalDate { get; set; }

        [Required]
        [Display(Name = "Priorität")]
        public string Priority { get; set; }

        [Display(Name = "Status des Projektes")]
        public string Status { get; set; }

        [Display(Name = "Geplantes Startdatum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Geplantes Enddatum")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Effektives Startdatum")]
        public DateTime? ActualStartDate { get; set; }

        [Display(Name = "Effektives Enddatum")]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Projektfortschritt")]
        public string Progress { get; set; }

        [Display(Name = "Link zu Dokumentablage")]
        public string DocumentsLink { get; set; }


        [Display(Name = "Projektleiter ID")]
        public int ProjectLeaderID { get; set; }

        [Display(Name = "Vorgehensmodell ID")]
        public int ProjectMethodID { get; set; }


        [Display(Name = "Projektleiter")]
        public virtual Person ProjectLeader { get; set; }

        [Display(Name = "Vorgehensmodell")]
        public virtual ProjectMethod ProjectMethod { get; set; }

        [Display(Name = "Projektphasen")]
        public virtual ICollection<ProjectPhase> ProjectPhases { get; set; }

    }
}