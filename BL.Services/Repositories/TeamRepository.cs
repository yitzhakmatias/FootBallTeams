using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.CORE;
using DL.DataContext.Model;

namespace BL.Services.Repositories
{
    public class TeamRepository : EntityRepository<Team, FootBallTeamsContext>, ITeamRepository
    {
        public TeamRepository(IDataContextFactory<FootBallTeamsContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}
