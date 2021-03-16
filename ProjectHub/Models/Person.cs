using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectHub.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Display(Name = "Vorname")]
        public string Name { get; set; }

        [Display(Name = "Nachname")]
        public string Surname { get; set; }

        [Display(Name = "Mitarbeiter Nummer")]
        public string EmpNumber { get; set; }

        [Display(Name = "Arbeitspensum")]
        public string Workload { get; set; }

        [Display(Name = "Abteilung")]
        public string Department { get; set; }

        [Display(Name = "Funktionen")]
        public string Functions { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ProjectActivities> ProjectActivities { get; set; }

    }
}