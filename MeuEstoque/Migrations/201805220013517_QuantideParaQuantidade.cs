namespace MeuEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuantideParaQuantidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Produto", "Quantide");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Quantide", c => c.Int(nullable: false));
            DropColumn("dbo.Produto", "Quantidade");
        }
    }
}
