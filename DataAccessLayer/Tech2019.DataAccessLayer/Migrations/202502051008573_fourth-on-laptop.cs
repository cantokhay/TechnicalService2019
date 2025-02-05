namespace Tech2019.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthonlaptop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        AboutDescription = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderName = c.String(nullable: false, maxLength: 50),
                        SenderMail = c.String(nullable: false, maxLength: 100),
                        MessageTitle = c.String(nullable: false, maxLength: 50),
                        MessageContent = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        DataStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
            DropTable("dbo.Abouts");
        }
    }
}
