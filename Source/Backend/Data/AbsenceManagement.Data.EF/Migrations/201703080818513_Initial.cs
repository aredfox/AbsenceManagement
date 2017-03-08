namespace AbsenceManagement.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
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
                "dbo.Requests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        RequestedAt = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RequestorId = c.Guid(nullable: false),
                        RequesteeId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                        DateModified = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.RequesteeId)
                .ForeignKey("dbo.People", t => t.RequestorId)
                .Index(t => t.RequestorId)
                .Index(t => t.RequesteeId);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        MasterId = c.Guid(nullable: false),
                        SlaveId = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                        DateModified = c.DateTime(nullable: false, defaultValue: DateTime.UtcNow),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.MasterId, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.SlaveId, cascadeDelete: false)
                .Index(t => t.MasterId)
                .Index(t => t.SlaveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relations", "SlaveId", "dbo.People");
            DropForeignKey("dbo.Relations", "MasterId", "dbo.People");
            DropForeignKey("dbo.Requests", "RequestorId", "dbo.People");
            DropForeignKey("dbo.Requests", "RequesteeId", "dbo.People");
            DropIndex("dbo.Relations", new[] { "SlaveId" });
            DropIndex("dbo.Relations", new[] { "MasterId" });
            DropIndex("dbo.Requests", new[] { "RequesteeId" });
            DropIndex("dbo.Requests", new[] { "RequestorId" });
            DropTable("dbo.Relations");
            DropTable("dbo.Requests");
            DropTable("dbo.People");
        }
    }
}
