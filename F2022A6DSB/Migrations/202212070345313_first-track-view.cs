namespace F2022A6DSB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firsttrackview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "AudioContentType", c => c.String(maxLength: 200));
            AddColumn("dbo.Tracks", "Audio", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "Audio");
            DropColumn("dbo.Tracks", "AudioContentType");
        }
    }
}
