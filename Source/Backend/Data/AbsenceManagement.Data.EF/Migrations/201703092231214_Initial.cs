namespace AbsenceManagement.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "identity.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("identity.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "identity.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        PersonId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("app.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "identity.ExternalLogins",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("identity.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "identity.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "identity.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("identity.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("identity.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("app.Relations", "SlaveId", "app.People");
            DropForeignKey("app.Relations", "MasterId", "app.People");
            DropForeignKey("identity.Claims", "UserId", "identity.Users");
            DropForeignKey("app.RoleUsers", "User_Id", "identity.Users");
            DropForeignKey("app.RoleUsers", "Role_Id", "identity.Roles");
            DropForeignKey("identity.Users", "PersonId", "app.People");
            DropForeignKey("app.Requests", "RequestorId", "app.People");
            DropForeignKey("app.Requests", "RequesteeId", "app.People");
            DropForeignKey("identity.ExternalLogins", "UserId", "identity.Users");
            DropIndex("app.RoleUsers", new[] { "User_Id" });
            DropIndex("app.RoleUsers", new[] { "Role_Id" });
            DropIndex("app.Relations", new[] { "SlaveId" });
            DropIndex("app.Relations", new[] { "MasterId" });
            DropIndex("app.Requests", new[] { "RequesteeId" });
            DropIndex("app.Requests", new[] { "RequestorId" });
            DropIndex("identity.ExternalLogins", new[] { "UserId" });
            DropIndex("identity.Users", new[] { "PersonId" });
            DropIndex("identity.Claims", new[] { "UserId" });
            DropTable("app.RoleUsers");
            DropTable("app.Relations");
            DropTable("identity.Roles");
            DropTable("app.Requests");
            DropTable("app.People");
            DropTable("identity.ExternalLogins");
            DropTable("identity.Users");
            DropTable("identity.Claims");
        }
    }
}
