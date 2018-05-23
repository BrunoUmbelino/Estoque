namespace MeuEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoECategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Peso = c.Single(nullable: false),
                        Quantide = c.Int(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        Categoria_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_Id, cascadeDelete: true)
                .Index(t => t.Categoria_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Categoria_Id", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}
