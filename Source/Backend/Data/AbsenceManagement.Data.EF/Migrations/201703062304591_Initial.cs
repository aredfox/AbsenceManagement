namespace AbsenceManagement.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up() {
            CreateTable(
                "dbo.People",
                c => new {
                    Id = c.Guid(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Requests",
                c => new {
                    Id = c.Guid(nullable: false),
                    RequestedAt = c.DateTime(),
                    Status = c.Int(nullable: false),
                    Requestee_Id = c.Guid(nullable: false),
                    Requestor_Id = c.Guid(nullable: false),
                    Person_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Requestee_Id, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.Requestor_Id, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Requestee_Id)
                .Index(t => t.Requestor_Id)
                .Index(t => t.Person_Id);

            CreateTable(
                "dbo.Relations",
                c => new {
                    Id = c.Guid(nullable: false),
                    Type = c.Int(nullable: false),
                    Master_Id = c.Guid(nullable: false),
                    Slave_Id = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Master_Id, cascadeDelete: false)
                .ForeignKey("dbo.People", t => t.Slave_Id, cascadeDelete: false)
                .Index(t => t.Master_Id)
                .Index(t => t.Slave_Id);

        }

        public override void Down() {
            DropForeignKey("dbo.Relations", "Slave_Id", "dbo.People");
            DropForeignKey("dbo.Relations", "Master_Id", "dbo.People");
            DropForeignKey("dbo.Requests", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Requests", "Requestor_Id", "dbo.People");
            DropForeignKey("dbo.Requests", "Requestee_Id", "dbo.People");
            DropIndex("dbo.Relations", new[] { "Slave_Id" });
            DropIndex("dbo.Relations", new[] { "Master_Id" });
            DropIndex("dbo.Requests", new[] { "Person_Id" });
            DropIndex("dbo.Requests", new[] { "Requestor_Id" });
            DropIndex("dbo.Requests", new[] { "Requestee_Id" });
            DropTable("dbo.Relations");
            DropTable("dbo.Requests");
            DropTable("dbo.People");
        }
    }
}
