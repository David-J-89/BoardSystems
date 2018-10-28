namespace BoardSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Created = c.DateTime(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "TopicId", "dbo.Topics");
            DropIndex("dbo.Replies", new[] { "TopicId" });
            DropTable("dbo.Topics");
            DropTable("dbo.Replies");
        }
    }
}
