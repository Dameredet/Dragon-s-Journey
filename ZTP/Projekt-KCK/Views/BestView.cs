﻿using System;
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
            for (int i = 0; i < 6; i++)
            {
                string Message = HighscoreName[i];
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            }
        }

        public void AskForBestName()
        {
            Console.Clear();
            Console.WriteLine();
            string Message = "You got highscore! How do you want to be remembered?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.SetCursorPosition((Console.WindowWidth / 2) - 20, 4);
        }

    }

    class GraphicBestView : IBestView
    {
        public void SetSceneForBests()
        {
             
        }
        public void Print(string name, int score, int where)
        {
 
        }

        private void PrintHighscore()
        {

        }

        public void AskForBestName()
        {

        }

    }
}