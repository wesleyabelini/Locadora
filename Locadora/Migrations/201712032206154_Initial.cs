namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        LocacaoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        FilmeID = c.Int(nullable: false),
                        DateLocacao = c.DateTime(nullable: false),
                        DateEntrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocacaoID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Filmes", t => t.FilmeID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.FilmeID);
            
            CreateTable(
                "dbo.Filmes",
                c => new
                    {
                        FilmeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        GeneroID = c.Int(nullable: false),
                        isLocated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FilmeID)
                .ForeignKey("dbo.Generoes", t => t.GeneroID, cascadeDelete: true)
                .Index(t => t.GeneroID);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        GeneroID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.GeneroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "FilmeID", "dbo.Filmes");
            DropForeignKey("dbo.Filmes", "GeneroID", "dbo.Generoes");
            DropForeignKey("dbo.Locacaos", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Filmes", new[] { "GeneroID" });
            DropIndex("dbo.Locacaos", new[] { "FilmeID" });
            DropIndex("dbo.Locacaos", new[] { "ClienteID" });
            DropTable("dbo.Generoes");
            DropTable("dbo.Filmes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Clientes");
        }
    }
}
