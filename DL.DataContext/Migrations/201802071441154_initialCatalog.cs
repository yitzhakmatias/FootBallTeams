namespace DL.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCatalog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.String(),
                        TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "TournamentId", "dbo.Tournaments");
            DropIndex("dbo.Teams", new[] { "TournamentId" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Teams");
        }
    }
}
