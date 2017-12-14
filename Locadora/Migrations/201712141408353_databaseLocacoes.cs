namespace Locadora.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseLocacoes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacaos", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Locacaos", "FilmeID", "dbo.Filmes");
            DropIndex("dbo.Locacaos", new[] { "ClienteID" });
            DropIndex("dbo.Locacaos", new[] { "FilmeID" });
            CreateTable(
                "dbo.LocacaoClientes",
                c => new
                    {
                        Locacao_LocacaoID = c.Int(nullable: false),
                        Cliente_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Locacao_LocacaoID, t.Cliente_ID })
                .ForeignKey("dbo.Locacaos", t => t.Locacao_LocacaoID, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ID, cascadeDelete: true)
                .Index(t => t.Locacao_LocacaoID)
                .Index(t => t.Cliente_ID);
            
            CreateTable(
                "dbo.FilmeLocacaos",
                c => new
                    {
                        Filme_FilmeID = c.Int(nullable: false),
                        Locacao_LocacaoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Filme_FilmeID, t.Locacao_LocacaoID })
                .ForeignKey("dbo.Filmes", t => t.Filme_FilmeID, cascadeDelete: true)
                .ForeignKey("dbo.Locacaos", t => t.Locacao_LocacaoID, cascadeDelete: true)
                .Index(t => t.Filme_FilmeID)
                .Index(t => t.Locacao_LocacaoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmeLocacaos", "Locacao_LocacaoID", "dbo.Locacaos");
            DropForeignKey("dbo.FilmeLocacaos", "Filme_FilmeID", "dbo.Filmes");
            DropForeignKey("dbo.LocacaoClientes", "Cliente_ID", "dbo.Clientes");
            DropForeignKey("dbo.LocacaoClientes", "Locacao_LocacaoID", "dbo.Locacaos");
            DropIndex("dbo.FilmeLocacaos", new[] { "Locacao_LocacaoID" });
            DropIndex("dbo.FilmeLocacaos", new[] { "Filme_FilmeID" });
            DropIndex("dbo.LocacaoClientes", new[] { "Cliente_ID" });
            DropIndex("dbo.LocacaoClientes", new[] { "Locacao_LocacaoID" });
            DropTable("dbo.FilmeLocacaos");
            DropTable("dbo.LocacaoClientes");
            CreateIndex("dbo.Locacaos", "FilmeID");
            CreateIndex("dbo.Locacaos", "ClienteID");
            AddForeignKey("dbo.Locacaos", "FilmeID", "dbo.Filmes", "FilmeID", cascadeDelete: true);
            AddForeignKey("dbo.Locacaos", "ClienteID", "dbo.Clientes", "ID", cascadeDelete: true);
        }
    }
}
