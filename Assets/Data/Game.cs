using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Data
{
    public class Game
    {
        public int lifeCount;
        public int gainedOranges;

        public Game() 
        {
            lifeCount = 3;
            gainedOranges= 0;
        }
    }
}
