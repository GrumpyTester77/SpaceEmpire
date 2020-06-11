namespace SpaceEmpire4XTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostViewModels",
                c => new
                    {
                        CostId = c.Int(nullable: false, identity: true),
                        Cost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CostId);
            
            CreateTable(
                "dbo.TechnologyViewModels",
                c => new
                    {
                        TechId = c.Int(nullable: false, identity: true),
                        TechnologyName = c.String(nullable: false),
                        Level_Id = c.Int(nullable: false),
                        Cost_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TechId);
            
            CreateTable(
                "dbo.TechnologyLevelViewModels",
                c => new
                    {
                        LevelId = c.Int(nullable: false, identity: true),
                        LevelNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LevelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TechnologyLevelViewModels");
            DropTable("dbo.TechnologyViewModels");
            DropTable("dbo.CostViewModels");
        }
    }
}
