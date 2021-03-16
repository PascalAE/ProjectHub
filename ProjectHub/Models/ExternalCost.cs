using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class ExternalCost
    {
        public int ID { get; set; }

        [Display(Name = "Kostenart")]
        public string CostType { get; set; }

        [Display(Name = "Budgetierte Kosten")]
        public string BudgetCost{ get; set; }

        [Display(Name = "Effektive Kosten")]
        public string ActualCost { get; set; }

        [Display(Name = "Abweichungen mit Begründung")]
        public string Abweichungen { get; set; }


        [Display(Name = "Projektaktivität ID")]
        public int ProjectActivitiesID { get; set; }


        public virtual ProjectActivities ProjectActivities { get; set; }
    }
}