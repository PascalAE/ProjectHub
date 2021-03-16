using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class PersonelResources
    {
        public int ID { get; set; }

        [Display(Name = "Funktion")]
        public string ResourceFunction { get; set; }

        [Display(Name = "Budgetierte Zeit")]
        public string BudgetTime { get; set; }

        [Display(Name = "Effektive Zeit")]
        public string ActualTime { get; set; }

        [Display(Name = "Abweichungen mit Begründung")]
        public string Abweichungen { get; set; }


        [Display(Name = "Projektaktivität ID")]
        public int ProjectActivitesID { get; set; }


        public virtual  ProjectActivities ProjectActivities { get; set; }
    }
}