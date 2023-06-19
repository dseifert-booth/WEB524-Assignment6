namespace F2022A6DSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstartistview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtistBaseViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlArtist = c.String(nullable: false, maxLength: 512),
                        Executive = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 100),
                        BirthName = c.String(maxLength: 100),
                        BirthOrStartDate = c.DateTime(nullable: false),
                        Genre = c.String(nullable: false),
                        Portrayal = c.String(),
                        NumAlbums = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArtistBaseViewModels");
        }
    }
}
