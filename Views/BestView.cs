using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Views
{
    interface IBestView
    {
        void SetSceneForBests();
        void Print(string name, int score, int where);
        void AskForBestName();
    }
    class BestView : IBestView
    {



        protected string[] HighscoreName = new string[] { "██╗░░██╗██╗░██████╗░██╗░░██╗░██████╗░█████╗░░█████╗░██████╗░███████╗░██████╗", "██║░░██║██║██╔════╝░██║░░██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝", "███████║██║██║░░██╗░███████║╚█████╗░██║░░╚═╝██║░░██║██████╔╝█████╗░░╚█████╗░", "██╔══██║██║██║░░╚██╗██╔══██║░╚═══██╗██║░░██╗██║░░██║██╔══██╗██╔══╝░░░╚═══██╗", "██║░░██║██║╚██████╔╝██║░░██║██████╔╝╚█████╔╝╚█████╔╝██║░░██║███████╗██████╔╝", "╚═╝░░╚═╝╚═╝░╚═════╝░╚═╝░░╚═╝╚═════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═════╝░" };
        protected int[] ScoresPositions = new int[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };

        public void SetSceneForBests()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();//1

            PrintHighscore(); //7
            Console.WriteLine();//8

            for (int i = 0; i<10;i++) Console.WriteLine(); //18

            Console.WriteLine(); //18
            string Message = "(Press any key to return to main menu.)";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
        }
        public void Print(string name, int score, int where)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, ScoresPositions[where]);
            if (name == null) name = " ";
            string Message = name;
            for(int i = 0; i < (40 - name.Length); i++)
            {
                Message += ".";
            }
            Message += score.ToString();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
        }

        private void PrintHighscore()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < 6; i++)
            {
                string Message = HighscoreName[i];
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            }
        }

        public void AskForBestName()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            string Message = "You got highscore! How do you want to be remembered?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 4);
        }

    }

    class DoomAndGloomBestView : IBestView
    {
        protected string[] HighscoreName = new string[] { "██╗░░██╗██╗░██████╗░██╗░░██╗░██████╗░█████╗░░█████╗░██████╗░███████╗░██████╗", "██║░░██║██║██╔════╝░██║░░██║██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔════╝", "███████║██║██║░░██╗░███████║╚█████╗░██║░░╚═╝██║░░██║██████╔╝█████╗░░╚█████╗░", "██╔══██║██║██║░░╚██╗██╔══██║░╚═══██╗██║░░██╗██║░░██║██╔══██╗██╔══╝░░░╚═══██╗", "██║░░██║██║╚██████╔╝██║░░██║██████╔╝╚█████╔╝╚█████╔╝██║░░██║███████╗██████╔╝", "╚═╝░░╚═╝╚═╝░╚═════╝░╚═╝░░╚═╝╚═════╝░░╚════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚═════╝░" };
        protected int[] ScoresPositions = new int[] { 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28 };
        public void SetSceneForBests()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();//1

            PrintHighscore(); //7

        }
        public void Print(string name, int score, int where)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, ScoresPositions[where]);
            if (name == null) name = " ";
            string Message = name;
            for (int i = 0; i < (40 - name.Length); i++)
            {
                Message += ".";
            }
            Message += score.ToString();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
        }

        private void PrintHighscore()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 6; i++)
            {
                string Message = HighscoreName[i];
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void AskForBestName()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine();
            string Message = "What do we call you now, that you're no longer a loser?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 4);
        }

    }
}
