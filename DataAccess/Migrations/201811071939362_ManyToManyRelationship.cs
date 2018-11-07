namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Owner_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Agenda_Usuario",
                c => new
                    {
                        AgendaID = c.Guid(nullable: false),
                        UsuarioID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.AgendaID, t.UsuarioID })
                .ForeignKey("dbo.Agenda", t => t.AgendaID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.AgendaID)
                .Index(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Agenda_Usuario", "UsuarioID", "dbo.Users");
            DropForeignKey("dbo.Agenda_Usuario", "AgendaID", "dbo.Agenda");
            DropIndex("dbo.Agenda_Usuario", new[] { "UsuarioID" });
            DropIndex("dbo.Agenda_Usuario", new[] { "AgendaID" });
            DropIndex("dbo.Agenda", new[] { "Owner_Id" });
            DropTable("dbo.Agenda_Usuario");
            DropTable("dbo.Users");
            DropTable("dbo.Agenda");
        }
    }
}
