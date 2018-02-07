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
        public FootBallTeamsContext() : base("name=FootBallTeamsContext")
        {

        }

        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }

        public ObjectResult<TEntity> SpObjectResult<TEntity>() where TEntity : class
        {
            return null;
        }
    }
}
