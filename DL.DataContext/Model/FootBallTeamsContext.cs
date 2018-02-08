using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.CORE;

namespace DL.DataContext.Model
{
    public class FootBallTeamsContext : DbContext, IDbContext
    {
        public FootBallTeamsContext()
        {
            this.Database.Connection.ConnectionString = 
                @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=DL.DataContext.Model.FootBallTeamsContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return null;
        }
    }
}
