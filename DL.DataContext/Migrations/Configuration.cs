using System.Collections.Generic;
using DL.DataContext.Model;

namespace DL.DataContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DL.DataContext.Model.FootBallTeamsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DL.DataContext.Model.FootBallTeamsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Teams.AddOrUpdate(p => p.TeamId,
                new Team() { Name = "Barcelona", Score = "9" },
                new Team() { Name = "Real Madrid", Score = "9" },
                new Team() { Name = "Atletico de Madrid", Score = "12" },
                new Team() { Name = "Parma", Score = "21" },
                new Team() { Name = "Juventus", Score = "6" },
                new Team() { Name = "Manchester UD", Score = "12" },
                new Team() { Name = "Manchester City", Score = "0" },
                new Team() { Name = "Tothenham", Score = "3" }
                );
            context.SaveChanges();

            context.Tournaments.AddOrUpdate(p => p.TournamentId,
                new Tournament()
                {
                    Teams = new List<Team>() {
                        context.Teams.First(x => x.Name.Contains("Barcelona")) ,
                        context.Teams.First(x => x.Name.Contains("Real Madrid")),
                        context.Teams.First(x => x.Name.Contains("Atletico de Madrid"))
                    },
                    Name = "Copa del Rey"
                },
                new Tournament()
                {
                    Teams = new List<Team>() {
                        context.Teams.First(x => x.Name.Contains("Real Madrid")),
                        context.Teams.First(x => x.Name.Contains("Atletico de Madrid"))
                    },
                    Name = "Super Liga"
                },
                new Tournament()
                {
                    Teams = new List<Team>() {
                        context.Teams.First(x => x.Name.Contains("Real Madrid")),
                        context.Teams.First(x => x.Name.Contains("Atletico de Madrid")),
                        context.Teams.First(x => x.Name.Contains("Parma")),
                        context.Teams.First(x => x.Name.Contains("Juventus")),
                        context.Teams.First(x => x.Name.Contains("Manchester UD")),
                        context.Teams.First(x => x.Name.Contains("Manchester City")),
                        context.Teams.First(x => x.Name.Contains("Tothenham"))
                    },
                    Name = "Champions"
                }
                );
            context.SaveChanges();
        }
    }
}
