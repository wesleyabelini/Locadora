namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        IdCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Locacao_IdLocacao = c.Int(),
                    })
                .PrimaryKey(t => t.IdCliente)
                .ForeignKey("dbo.Locacaos", t => t.Locacao_IdLocacao)
                .Index(t => t.Locacao_IdLocacao);
            
            CreateTable(
                "dbo.Filmes",
                c => new
                    {
                        IdFilme = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        IdGenero = c.Int(nullable: false),
                        isLocated = c.Boolean(nullable: false),
                        Locacao_IdLocacao = c.Int(),
                    })
                .PrimaryKey(t => t.IdFilme)
                .ForeignKey("dbo.Locacaos", t => t.Locacao_IdLocacao)
                .Index(t => t.Locacao_IdLocacao);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        IdGenero = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Filme_IdFilme = c.Int(),
                    })
                .PrimaryKey(t => t.IdGenero)
                .ForeignKey("dbo.Filmes", t => t.Filme_IdFilme)
                .Index(t => t.Filme_IdFilme);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        IdLocacao = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        IdFilme = c.Int(nullable: false),
                        DateLocacao = c.DateTime(nullable: false),
                        DateEntrega = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdLocacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filmes", "Locacao_IdLocacao", "dbo.Locacaos");
            DropForeignKey("dbo.Clientes", "Locacao_IdLocacao", "dbo.Locacaos");
            DropForeignKey("dbo.Generoes", "Filme_IdFilme", "dbo.Filmes");
            DropIndex("dbo.Generoes", new[] { "Filme_IdFilme" });
            DropIndex("dbo.Filmes", new[] { "Locacao_IdLocacao" });
            DropIndex("dbo.Clientes", new[] { "Locacao_IdLocacao" });
            DropTable("dbo.Locacaos");
            DropTable("dbo.Generoes");
            DropTable("dbo.Filmes");
            DropTable("dbo.Clientes");
        }
    }
}
