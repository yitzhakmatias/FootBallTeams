using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.CORE;
using DL.DataContext.Model;

namespace BL.Services.Repositories
{
    public class TournamentRepository : EntityRepository<Tournament, FootBallTeamsContext>, ITournamentRepository
    {
        public TournamentRepository(IDataContextFactory<FootBallTeamsContext> databaseFactory) : base(databaseFactory)
        {
        }
    }
}
