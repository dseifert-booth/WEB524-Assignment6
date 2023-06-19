namespace F2022A6DSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstalbumview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumBaseViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlAlbum = c.String(nullable: false, maxLength: 512),
                        Name = c.String(nullable: false, maxLength: 100),
                        ReleaseDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false),
                        Background = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AlbumBaseViewModels");
        }
    }
}
