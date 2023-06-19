namespace F2022A6DSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trackeditview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrackEditAudioFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AudioUpload = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrackEditAudioFormViewModels");
        }
    }
}
