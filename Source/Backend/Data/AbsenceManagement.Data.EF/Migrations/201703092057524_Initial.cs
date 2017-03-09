namespace AbsenceManagement.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.People",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DataSource = c.String(nullable: false),
                        DataSourceId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "app.Requests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RequestedAt = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RequestorId = c.Guid(nullable: false),
                        RequesteeId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("app.People", t => t.RequesteeId)
                .ForeignKey("app.People", t => t.RequestorId)
                .Index(t => t.RequestorId)
                .Index(t => t.RequesteeId);
            
            CreateTable(
                "app.Relations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MasterId = c.Guid(nullable: false),
                        SlaveId = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("app.People", t => t.MasterId)
                .ForeignKey("app.People", t => t.SlaveId)
                .Index(t => t.MasterId)
                .Index(t => t.SlaveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("app.Relations", "SlaveId", "app.People");
            DropForeignKey("app.Relations", "MasterId", "app.People");
            DropForeignKey("app.Requests", "RequestorId", "app.People");
            DropForeignKey("app.Requests", "RequesteeId", "app.People");
            DropIndex("app.Relations", new[] { "SlaveId" });
            DropIndex("app.Relations", new[] { "MasterId" });
            DropIndex("app.Requests", new[] { "RequesteeId" });
            DropIndex("app.Requests", new[] { "RequestorId" });
            DropTable("app.Relations");
            DropTable("app.Requests");
            DropTable("app.People");
        }
    }
}
