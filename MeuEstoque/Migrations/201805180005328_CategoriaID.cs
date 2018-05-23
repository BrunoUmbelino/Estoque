namespace MeuEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriaID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Produto", name: "Categoria_Id", newName: "CategoriaId");
            RenameIndex(table: "dbo.Produto", name: "IX_Categoria_Id", newName: "IX_CategoriaId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Produto", name: "IX_CategoriaId", newName: "IX_Categoria_Id");
            RenameColumn(table: "dbo.Produto", name: "CategoriaId", newName: "Categoria_Id");
        }
    }
}
