using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class ProjectActivities
    {
        public int ID { get; set; }

        [Display(Name = "Projektaktivität Name")]
        public string Name { get; set; }
        [Display(Name = "Geplantes Startdatum")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Geplantes Enddatum")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Effektives Startdatum")]
        public DateTime? ActualStartDate { get; set; }

        [Display(Name = "Effektives Enddatum")]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Aktivitätsfortschritt")]
        public string Progress { get; set; }

        [Display(Name = "Link zu Dokumentablage")]
        public string DocumentsLink { get; set; }


        [Display(Name = "Projektphase ID")]
        public int ProjectPhaseID { get; set; }


        [Display(Name = "Verantwortliche Person")]
        public virtual Person ResponsiblePerson { get; set; }

        [Display(Name = "Projektphase ID")]
        public virtual ProjectPhase ProjectPhase { get; set; }

        

        [Display(Name = "Externe Kosten")]
        public virtual ICollection<ExternalCost> ExternalCosts { get; set; }

        [Display(Name = "Personelle Resources")]
        public virtual ICollection<PersonelResources> PersonelResources { get; set; }



    }
}