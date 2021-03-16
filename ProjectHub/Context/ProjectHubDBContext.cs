using ProjectHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectHub.Context
{
    public class ProjectHubDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<ProjectMethod> ProjectMethods { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectPhase> ProjectPhases { get; set; }

        public System.Data.Entity.DbSet<ProjectHub.Models.ProjectActivities> ProjectActivities { get; set; }

        public System.Data.Entity.DbSet<ProjectHub.Models.Milestones> Milestones { get; set; }

        public System.Data.Entity.DbSet<ProjectHub.Models.ExternalCost> ExternalCosts { get; set; }

        public System.Data.Entity.DbSet<ProjectHub.Models.PersonelResources> PersonelResources { get; set; }
    }
}