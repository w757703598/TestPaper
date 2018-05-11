namespace TestPaper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalculateQuestion",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Answer = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestPaperInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CheckQuestion",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Options = c.String(),
                        Answer = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChoiceQuestion",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Answer = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FillQuestion",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestPaperInfoCalculateQuestion",
                c => new
                    {
                        TestPaperInfo_Id = c.Int(nullable: false),
                        CalculateQuestion_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestPaperInfo_Id, t.CalculateQuestion_Id })
                .ForeignKey("dbo.TestPaperInfo", t => t.TestPaperInfo_Id, cascadeDelete: true)
                .ForeignKey("dbo.CalculateQuestion", t => t.CalculateQuestion_Id, cascadeDelete: true)
                .Index(t => t.TestPaperInfo_Id)
                .Index(t => t.CalculateQuestion_Id);
            
            CreateTable(
                "dbo.CheckQuestionTestPaperInfo",
                c => new
                    {
                        CheckQuestion_Id = c.Guid(nullable: false),
                        TestPaperInfo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CheckQuestion_Id, t.TestPaperInfo_Id })
                .ForeignKey("dbo.CheckQuestion", t => t.CheckQuestion_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestPaperInfo", t => t.TestPaperInfo_Id, cascadeDelete: true)
                .Index(t => t.CheckQuestion_Id)
                .Index(t => t.TestPaperInfo_Id);
            
            CreateTable(
                "dbo.ChoiceQuestionTestPaperInfo",
                c => new
                    {
                        ChoiceQuestion_Id = c.Guid(nullable: false),
                        TestPaperInfo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChoiceQuestion_Id, t.TestPaperInfo_Id })
                .ForeignKey("dbo.ChoiceQuestion", t => t.ChoiceQuestion_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestPaperInfo", t => t.TestPaperInfo_Id, cascadeDelete: true)
                .Index(t => t.ChoiceQuestion_Id)
                .Index(t => t.TestPaperInfo_Id);
            
            CreateTable(
                "dbo.FillQuestionTestPaperInfo",
                c => new
                    {
                        FillQuestion_Id = c.Guid(nullable: false),
                        TestPaperInfo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FillQuestion_Id, t.TestPaperInfo_Id })
                .ForeignKey("dbo.FillQuestion", t => t.FillQuestion_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestPaperInfo", t => t.TestPaperInfo_Id, cascadeDelete: true)
                .Index(t => t.FillQuestion_Id)
                .Index(t => t.TestPaperInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FillQuestionTestPaperInfo", "TestPaperInfo_Id", "dbo.TestPaperInfo");
            DropForeignKey("dbo.FillQuestionTestPaperInfo", "FillQuestion_Id", "dbo.FillQuestion");
            DropForeignKey("dbo.ChoiceQuestionTestPaperInfo", "TestPaperInfo_Id", "dbo.TestPaperInfo");
            DropForeignKey("dbo.ChoiceQuestionTestPaperInfo", "ChoiceQuestion_Id", "dbo.ChoiceQuestion");
            DropForeignKey("dbo.CheckQuestionTestPaperInfo", "TestPaperInfo_Id", "dbo.TestPaperInfo");
            DropForeignKey("dbo.CheckQuestionTestPaperInfo", "CheckQuestion_Id", "dbo.CheckQuestion");
            DropForeignKey("dbo.TestPaperInfoCalculateQuestion", "CalculateQuestion_Id", "dbo.CalculateQuestion");
            DropForeignKey("dbo.TestPaperInfoCalculateQuestion", "TestPaperInfo_Id", "dbo.TestPaperInfo");
            DropIndex("dbo.FillQuestionTestPaperInfo", new[] { "TestPaperInfo_Id" });
            DropIndex("dbo.FillQuestionTestPaperInfo", new[] { "FillQuestion_Id" });
            DropIndex("dbo.ChoiceQuestionTestPaperInfo", new[] { "TestPaperInfo_Id" });
            DropIndex("dbo.ChoiceQuestionTestPaperInfo", new[] { "ChoiceQuestion_Id" });
            DropIndex("dbo.CheckQuestionTestPaperInfo", new[] { "TestPaperInfo_Id" });
            DropIndex("dbo.CheckQuestionTestPaperInfo", new[] { "CheckQuestion_Id" });
            DropIndex("dbo.TestPaperInfoCalculateQuestion", new[] { "CalculateQuestion_Id" });
            DropIndex("dbo.TestPaperInfoCalculateQuestion", new[] { "TestPaperInfo_Id" });
            DropTable("dbo.FillQuestionTestPaperInfo");
            DropTable("dbo.ChoiceQuestionTestPaperInfo");
            DropTable("dbo.CheckQuestionTestPaperInfo");
            DropTable("dbo.TestPaperInfoCalculateQuestion");
            DropTable("dbo.FillQuestion");
            DropTable("dbo.ChoiceQuestion");
            DropTable("dbo.CheckQuestion");
            DropTable("dbo.TestPaperInfo");
            DropTable("dbo.CalculateQuestion");
        }
    }
}
