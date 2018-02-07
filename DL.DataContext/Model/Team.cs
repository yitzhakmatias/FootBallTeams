using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.DataContext.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }

        public int?  TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
