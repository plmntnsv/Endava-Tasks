namespace BlogSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostNumberOfLikesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "NumberOfLikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "NumberOfLikes");
        }
    }
}
