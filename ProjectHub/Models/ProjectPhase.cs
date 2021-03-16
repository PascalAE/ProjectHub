using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class ProjectPhase
    {
        public int ID { get; set; }

        [Display(Name = "Projektphase Name")]
        public string Name { get; set; }

        [Display(Name = "Geplantes Startdatum")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Geplantes Enddatum")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Effektives Startdatum")]
        public DateTime? ActualStartDate { get; set; }

        [Display(Name = "Effektives Enddatum")]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Geplantes Review Datum")]
        public DateTime? ReviewDate { get; set; }

        [Display(Name = "Effektives Review Datum")]
        public DateTime? ActualReviewDate { get; set; }

        [Display(Name = "Status der Phase")]
        public string Status { get; set; }

        [Display(Name = "Phasenfortschritt")]
        public string Progress { get; set; }

        [Display(Name = "Freigabe Datum")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Visum")]
        public string Visum { get; set; }

        [Display(Name = "Link zu Dokumentablage")]
        public string DocumentsLink { get; set; }

        [Display(Name = "Projekt ID")]
        public int ProjectID { get; set; }



        public virtual Project Project { get; set; }

        [Display(Name = "Projektaktivitäten")]
        public virtual ICollection<ProjectActivities> ProjectActivities { get; set; }

        [Display(Name = "ProjektMeilensteine")]
        public virtual ICollection<Milestones> Milestones { get; set; }

    }
}