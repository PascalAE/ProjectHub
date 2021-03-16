namespace ProjectHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExternalCosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CostType = c.String(),
                        BudgetCost = c.String(),
                        ActualCost = c.String(),
                        Abweichungen = c.String(),
                        ProjectActivitiesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectActivities", t => t.ProjectActivitiesID, cascadeDelete: true)
                .Index(t => t.ProjectActivitiesID);
            
            CreateTable(
                "dbo.ProjectActivities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ActualStartDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        Progress = c.String(),
                        DocumentsLink = c.String(),
                        ProjectPhaseID = c.Int(nullable: false),
                        ResponsiblePerson_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ResponsiblePerson_ID)
                .ForeignKey("dbo.ProjectPhases", t => t.ProjectPhaseID, cascadeDelete: true)
                .Index(t => t.ProjectPhaseID)
                .Index(t => t.ResponsiblePerson_ID);
            
            CreateTable(
                "dbo.PersonelResources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResourceFunction = c.String(),
                        BudgetTime = c.String(),
                        ActualTime = c.String(),
                        Abweichungen = c.String(),
                        ProjectActivitesID = c.Int(nullable: false),
                        ProjectActivities_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectActivities", t => t.ProjectActivities_ID)
                .Index(t => t.ProjectActivities_ID);
            
            CreateTable(
                "dbo.ProjectPhases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        ActualStartDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        ReviewDate = c.DateTime(),
                        ActualReviewDate = c.DateTime(),
                        Status = c.String(),
                        Progress = c.String(),
                        ReleaseDate = c.DateTime(),
                        Visum = c.String(),
                        DocumentsLink = c.String(),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Milestones",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(),
                        ProjectPhaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectPhases", t => t.ProjectPhaseId, cascadeDelete: true)
                .Index(t => t.ProjectPhaseId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        Priority = c.String(nullable: false),
                        Status = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ActualStartDate = c.DateTime(),
                        ActualEndDate = c.DateTime(),
                        Progress = c.String(),
                        DocumentsLink = c.String(),
                        ProjectLeaderID = c.Int(nullable: false),
                        ProjectMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ProjectLeaderID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectMethods", t => t.ProjectMethodID, cascadeDelete: true)
                .Index(t => t.ProjectLeaderID)
                .Index(t => t.ProjectMethodID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        EmpNumber = c.String(),
                        Workload = c.String(),
                        Department = c.String(),
                        Functions = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectMethods",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Method = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Phases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProjectMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectMethods", t => t.ProjectMethodID, cascadeDelete: true)
                .Index(t => t.ProjectMethodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectActivities", "ProjectPhaseID", "dbo.ProjectPhases");
            DropForeignKey("dbo.ProjectPhases", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectMethodID", "dbo.ProjectMethods");
            DropForeignKey("dbo.Phases", "ProjectMethodID", "dbo.ProjectMethods");
            DropForeignKey("dbo.Projects", "ProjectLeaderID", "dbo.People");
            DropForeignKey("dbo.ProjectActivities", "ResponsiblePerson_ID", "dbo.People");
            DropForeignKey("dbo.Milestones", "ProjectPhaseId", "dbo.ProjectPhases");
            DropForeignKey("dbo.PersonelResources", "ProjectActivities_ID", "dbo.ProjectActivities");
            DropForeignKey("dbo.ExternalCosts", "ProjectActivitiesID", "dbo.ProjectActivities");
            DropIndex("dbo.Phases", new[] { "ProjectMethodID" });
            DropIndex("dbo.Projects", new[] { "ProjectMethodID" });
            DropIndex("dbo.Projects", new[] { "ProjectLeaderID" });
            DropIndex("dbo.Milestones", new[] { "ProjectPhaseId" });
            DropIndex("dbo.ProjectPhases", new[] { "ProjectID" });
            DropIndex("dbo.PersonelResources", new[] { "ProjectActivities_ID" });
            DropIndex("dbo.ProjectActivities", new[] { "ResponsiblePerson_ID" });
            DropIndex("dbo.ProjectActivities", new[] { "ProjectPhaseID" });
            DropIndex("dbo.ExternalCosts", new[] { "ProjectActivitiesID" });
            DropTable("dbo.Phases");
            DropTable("dbo.ProjectMethods");
            DropTable("dbo.People");
            DropTable("dbo.Projects");
            DropTable("dbo.Milestones");
            DropTable("dbo.ProjectPhases");
            DropTable("dbo.PersonelResources");
            DropTable("dbo.ProjectActivities");
            DropTable("dbo.ExternalCosts");
        }
    }
}
