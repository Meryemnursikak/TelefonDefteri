namespace TelefonDefteri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(),
                       
                    })
                .PrimaryKey(t => t.KategoriId);
            
            CreateTable(
                "dbo.Kisis",
                c => new
                    {
                        KisiId = c.Int(nullable: false, identity: true),
                        KisiAdi = c.String(),
                        Soyadi = c.String(),
                        Telefon = c.String(),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KisiId)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .Index(t => t.KategoriId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisis", "KategoriId", "dbo.Kategoris");
            DropIndex("dbo.Kisis", new[] { "KategoriId" });
            DropTable("dbo.Kisis");
            DropTable("dbo.Kategoris");
        }
    }
}
