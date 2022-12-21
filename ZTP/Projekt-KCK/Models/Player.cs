using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Models
{
    public class Player
    {
        public int CollectedCoins;
        public int NegativeMovePoints;
        public int HeartsLeft;
        public int CurrentPlayerCollumn;
        public int CurrentPlayerRow;
        public int PlayerPositionBlockRow;
        public int PlayerPositionBlockColumn;
        public int CrashCount;

        public Player() 
        {
            this.CollectedCoins = 0;
            this.NegativeMovePoints = 0;
            this.HeartsLeft = 2;
            this.CurrentPlayerCollumn = 0;
            this.CurrentPlayerRow = 0;
            this.CrashCount = 0;
        }
    }
}
