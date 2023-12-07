using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2.Players
{
    public class Player
    { 
        public string Name {  get; set; }
        public string ResultRecord { get; set; }

        public int _ptsTotal;
        public int ptsTotal
        {
            get
            {
                CalculatePoints();
                return _ptsTotal;
            }
        }

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

        public override string ToString()
        {
            return $"{Name} - {ResultRecord} - {ptsTotal}";
        }

        private void CalculatePoints()
        {
            char[] results = ResultRecord.ToCharArray();
            Console.Write(results);

            _ptsTotal = 0;


            foreach (char c in results)
            {
                
                switch (c)
                {
                    case 'W':
                        _ptsTotal += 3;
                        break;

                    case 'D':
                        _ptsTotal += 1;
                        break;

                    case 'L':
                        _ptsTotal += 0;
                        break;
                }
            }
    
 
        }
    }
}
