using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CA2.Players;
    
namespace CA2.Teams
{
    internal class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team() { }
        public Team(string name)
        {
            Name = name;
        }
        public Team(string name, List<Player> players)
        {
            Name = name;
            Players = players;
        }
    }
}
