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

        public int _totalPoints;
        public int totalPoints
        {
            get
            {
                _totalPoints = 0;

                foreach (var player in Players)
                {
                    _totalPoints += player.ptsTotal;
                }

                return _totalPoints;
            }
            
        }
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

        public int CompareTo(Team other)
        {
            // Compare teams based on total points
            return other.totalPoints.CompareTo(this.totalPoints);
        }

        public override string ToString()
        {
            return $"{Name} - {totalPoints}";
        }

        
    }
}
