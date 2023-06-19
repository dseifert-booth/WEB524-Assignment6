namespace F2022A6DSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firsttrackviewforreal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackBaseViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Composers = c.String(nullable: false, maxLength: 500),
                        Genre = c.String(nullable: false),
                        Clerk = c.String(nullable: false, maxLength: 200),
                        AudioContentType = c.String(maxLength: 200),
                        Audio = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackBaseViewModels");
        }
    }
}
