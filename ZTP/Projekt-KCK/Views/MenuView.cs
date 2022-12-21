﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projekt_KCK.Views
{
    interface IMenuView
    {
        void Print(bool isFirstTime);
        void SwitchDown(int destination);
        void SwitchUp(int destination);

        void SwitchUpLevels(int destination, string message, string privious);

        void SwitchDownLevels(int destination, string message, string privious);

        void PrintLevels(bool forEditor);

        void PrintAskName();
        void ColorRed(string v);
        void ColorClear(string v);
    }
    class MenuView : IMenuView
    {
        private static MenuView instance;

        private MenuView() { }

        public static MenuView GetInstance()
        {
            if (instance == null) instance = new MenuView();
            return instance;
        }


        protected string[] OptionsNames = new string[] { "PLAY", "LEVEL MAKER", "SCOREBOARD", "SWITCH GRAPHIC MODE", "EXIT" };

        protected string[] GamesName = new string[] { "                                               ______   _______  _______  _______  _______  _        _  _______       _________ _______           _______  _        _______          ", "                                              (  __  \\ (  ____ )(  ___  )(  ____ \\(  ___  )( (    /|( )(  ____ \\      \\__    _/(  ___  )|\\     /|(  ____ )( (    /|(  ____ \\|\\     /|", "                                              | (  \\  )| (    )|| (   ) || (    \\/| (   ) ||  \\  ( ||/ | (    \\/         )  (  | (   ) || )   ( || (    )||  \\  ( || (    \\/( \\   / )", "                                              | |   ) || (____)|| (___) || |      | |   | ||   \\ | |   | (_____          |  |  | |   | || |   | || (____)||   \\ | || (__     \\ (_) / ", "                                              | |   | ||     __)|  ___  || | ____ | |   | || (\\ \\) |   (_____  )         |  |  | |   | || |   | ||     __)| (\\ \\) ||  __)     \\   /  ", "                                              | |   ) || (\\ (   | (   ) || | \\_  )| |   | || | \\   |         ) |         |  |  | |   | || |   | || (\\ (   | | \\   || (         ) (   ", "                                              | (__/  )| ) \\ \\__| )   ( || (___) || (___) || )  \\  |   /\\____) |      |\\_)  )  | (___) || (___) || ) \\ \\__| )  \\  || (____/\\   | |   ", "                                              (______/ |/   \\__/|/     \\|(_______)(_______)|/    )_)   \\_______)      (____/   (_______)(_______)|/   \\__/|/    )_)(_______/   \\_/   " };


        private void IntroPlainPrint()
        {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(GamesName[0]);

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine(GamesName[i]);
                }

            Console.WriteLine();
        }

        private void IntroAnimationPrint()
        {
            
            for (int j = GamesName[0].Length; j > 0; j--)
            {
                Console.SetCursorPosition(0,0);
                for (int i = 0; i < 8; i++)
                {
                    string substracted = GamesName[i].Substring(j);
                    Console.WriteLine(substracted);
                }
                System.Threading.Thread.Sleep(8);
            }
            Console.WriteLine();
        }

        public void ColorRed(string Message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.ResetColor();
        }
        public void ColorClear(string Message)
        {
            Console.ResetColor();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.ResetColor();
        }
        public void Print(bool isFirstTime)
        {
            Console.Clear();
            if (isFirstTime)
            {
                IntroAnimationPrint();
                System.Threading.Thread.Sleep(3500);
            }
            else IntroPlainPrint();

            ColorRed(OptionsNames[0]);
            ColorClear(OptionsNames[1]);
            ColorClear(OptionsNames[2]);
            ColorClear(OptionsNames[3]);
            ColorClear(OptionsNames[4]);

        }

        public void SwitchDown(int destination)
        {

            Console.SetCursorPosition(0, 8 + destination);
            ColorClear(OptionsNames[destination - 1]);
            Console.SetCursorPosition(0, 9 + destination);
            ColorRed(OptionsNames[destination]);
        }
        public void SwitchUp(int destination)
        {

            Console.SetCursorPosition(0, 10 + destination);
            ColorClear(OptionsNames[destination + 1]);
            Console.SetCursorPosition(0, 9 + destination);
            ColorRed(OptionsNames[destination]);
        }

        public void SwitchUpLevels(int destination, string message, string privious)
        {

            Console.SetCursorPosition(0, destination+4);
            ColorClear(privious);
            Console.SetCursorPosition(0, destination+3);
            ColorRed(message);
        }

        public void SwitchDownLevels(int destination, string message, string privious)
        {

            Console.SetCursorPosition(0, destination+2);
            ColorClear(privious);
            Console.SetCursorPosition(0, destination+3);
            ColorRed(message);
        }

        
        public void PrintLevels(bool forEditor)
        {
            Console.Clear();

            Console.SetCursorPosition(0,0);
            string Message; //0

            if (forEditor) Message = "CHOSE LEVEL TO EDIT:";
            else Message = "CHOSE LEVEL TO PLAY:";

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));
            Console.WriteLine(); //1
            
        }

        public void PrintAskName()
        {
            Console.Clear();
            string text = "How do you want to name your level?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
            Console.SetCursorPosition((Console.WindowWidth / 2)-20, 4);
        }
        

    }

    class GraphicMenuView : IMenuView
    {
        private static GraphicMenuView instance;

        private GraphicMenuView() { }

        public static GraphicMenuView GetInstance()
        {
            if (instance == null) instance = new GraphicMenuView();
            return instance;
        }
        public void Print(bool isFirstTime) { }
        public void SwitchDown(int destination) { }
        public  void SwitchUp(int destination) { }

        public  void SwitchUpLevels(int destination, string message, string privious) { }

        public  void SwitchDownLevels(int destination, string message, string privious) { }

        public void PrintLevels(bool forEditor) { }

        public void PrintAskName() { }

        public void ColorRed(string v)
        {
            throw new NotImplementedException();
        }

        public void ColorClear(string v)
        {
            throw new NotImplementedException();
        }
    }
}