using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2.Players
{
    internal class Player
    { 
        string Name {  get; set; }
        string ResultRecord { get; set; }

        public Player() { }

        public Player(string name)
        { 
            Name = name;
        }

        public Player(string name, string resultRecord)
        {
            Name = name;
            ResultRecord = resultRecord;
        }
    }
}
