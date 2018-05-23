namespace MeuEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCompleto = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.Int(nullable: false),
                        SenhaConfirmada = c.Int(nullable: false),
                        NivelDeAcesso = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
