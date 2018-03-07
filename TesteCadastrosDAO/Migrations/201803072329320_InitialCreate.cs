namespace TesteCadastrosDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadastros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCadastro = c.DateTime(),
                        DataNascimento = c.DateTime(),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(nullable: false),
                        Uf = c.String(),
                        Rg = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CadastrosTelefones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Telefone = c.String(nullable: false),
                        Cadastro_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cadastros", t => t.Cadastro_Id)
                .Index(t => t.Cadastro_Id);
            
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uf = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CadastrosTelefones", "Cadastro_Id", "dbo.Cadastros");
            DropIndex("dbo.CadastrosTelefones", new[] { "Cadastro_Id" });
            DropTable("dbo.Configs");
            DropTable("dbo.CadastrosTelefones");
            DropTable("dbo.Cadastros");
        }
    }
}
