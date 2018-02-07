using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DataContext.Model
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; }

    }
}
