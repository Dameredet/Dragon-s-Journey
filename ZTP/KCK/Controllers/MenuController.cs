﻿using System;
using System.Collections.Generic;
using System.Text;
using KCK.Views;
using KCK.Controllers;
using System.IO;

namespace KCK.Controllers
{
    public class MenuController
    {
        private static bool FirstTime = true;
        public string[] LevelsNames = new string[60];
        public int ActualNumberOfLevels = 0;

        private static MenuController instance;

        private MenuController() { }

        public static MenuController GetInstance()
        {
            if (instance == null)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                instance = new MenuController();
                
            }
            else
            {
                FirstTime = false;
            }

            return instance;
        }
        

        public void Menu()
        {
            

            var MusicManager = new Muzyka();
            if(FirstTime == true) MusicManager.IntroMusic();

            var menuView = GraphicMode.GetInstance();
            menuView.PrintMenu(FirstTime);

            

            ConsoleKeyInfo playerAction;


            int choice = 0;

            while(choice < 100)   //podświetlanie
            {
                playerAction = Console.ReadKey();
                
                if (ConsoleKey.UpArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    if (choice > 0)
                    {
                        choice--;
                        menuView.Switch(choice+1,choice);
                    }
                    else
                    {
                        menuView.Switch(choice, 4);
                        choice = 4;
                    }
                }
                else if (ConsoleKey.DownArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    if (choice < 4)
                    {
                        choice++;
                        menuView.Switch(choice-1,choice);
                    }
                    else
                    {
                        menuView.Switch(choice, 0);
                        choice = 0;
                    }
                }
                else if (ConsoleKey.Enter == playerAction.Key) {   //POPRAWKA - tu zmienić przy projekcie z grafiką
                   
                    MusicManager.ClickMusic();
                    //if (choice != 3) 
                        choice += 100; 
                   // else MusicManager.ErrorMusic();
                }
               
            }

           switch (choice) //wybranie akcji
            {
                case 100:
                    LevelChoice(false);//GAME - LEVEL CHOICE
                    break;
                case 101:
                    LevelChoice(true); //LEVEL MAKER
                    break;
                case 102:
                    var bestController = BestController.GetInstance(); //SCOREBOARD
                    bestController.Best();
                    break;
                case 103: //TRYB GRAFICZNY
                    var GraphicsManager = GraphicMode.GetInstance();
                    if (GraphicsManager.graphicstype == false)
                    {
                        GraphicsManager.TurnOnGraphicMode();
                        GraphicsManager.graphicstype = true;
                    }
                    else
                    {
                        GraphicsManager.TurnOnConsoleMode();
                        GraphicsManager.graphicstype = false;
                    }
                    menuView.PrintMenu(FirstTime);
                    break;
                case 104:
                    System.Environment.Exit(3); //EXIT
                    break;
            }


        }

        public void LevelChoice(bool forEditor)
        {
            

            var menuView = GraphicMode.GetInstance();
            var MusicManager = new Muzyka();
            

            
            menuView.PrintLevels(forEditor);

            if (forEditor) {
                if (LevelsNames[ActualNumberOfLevels - 1] != "NEW LEVEL")
                {
                    LevelsNames[ActualNumberOfLevels] = "NEW LEVEL";
                    ActualNumberOfLevels++;
                }
                }
            else
            {
                if(LevelsNames[ActualNumberOfLevels-1] == "NEW LEVEL")
                {
                    LevelsNames[ActualNumberOfLevels-1] = null;
                    ActualNumberOfLevels--;
                    
                }
            }

            string LevelName = LevelsNames[0];
            Console.SetCursorPosition(0, 0 + 3);
            menuView.ColorRed(LevelsNames[0]);
            for (int i = 1; i<ActualNumberOfLevels;i++)
            {
                Console.SetCursorPosition(0, i + 3);
                menuView.ColorClear(LevelsNames[i]);

            }

            Console.WriteLine();
            string Message = "(Press ESC to return to menu.)";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (Message.Length / 2)) + "}", Message));

            int choice = 0;
            ConsoleKeyInfo playerAction;
            while (choice < 100)   //podświetlanie
            {
                playerAction = Console.ReadKey();

                if (ConsoleKey.UpArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();

                    if (choice > 0)
                    {
                        choice--;
                        menuView.SwitchUpLevels(choice, LevelsNames[choice], LevelsNames[choice+1]);
                    }
                }
                else if (ConsoleKey.DownArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    if (choice < ActualNumberOfLevels-1)
                    {
                        choice++;
                        menuView.SwitchDownLevels(choice, LevelsNames[choice], LevelsNames[choice-1]);
                    }
                }
                else if (ConsoleKey.Enter == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    choice += 100;
                }
                else if (ConsoleKey.Escape == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    choice += 200;
                }
            }

            if (choice < 200)
            {
                LevelName = LevelsNames[choice - 100];
                if (forEditor)
                {
                    if (LevelName == "NEW LEVEL") AskForName();
                    else
                    {
                        var gameController = GameController.GetInstance();
                        gameController.Editor(LevelName);
                    }
                }
                else
                {
                    var gameController = GameController.GetInstance();
                    gameController.Game(LevelName);
                }
            }
            else
            {
                var menuController = MenuController.GetInstance();
                menuController.Menu();
            }
            
        }

        private void AskForName()
        {
            var menuView = GraphicMode.GetInstance();
            menuView.PrintAskName();
            string newlevelname = menuView.GetName();
            LevelsNames[ActualNumberOfLevels - 1] = newlevelname;
            AddToLevelNames(newlevelname);
            var gameController = GameController.GetInstance();
            gameController.Editor(newlevelname, true);
        }

        private void AddToLevelNames(string newlevelname)
        {
            
                string file = ("C:\\DragonsJourney\\levels.txt");

                StreamWriter sw = new StreamWriter(file);
                
            for(int i = 0; i < ActualNumberOfLevels; i++)
            {
                sw.WriteLine(LevelsNames[i]);
            }
                sw.Close();

        }

        public void LoadLevelNames()
        {
            Array.Clear(LevelsNames, 0, 60);

            String line;
            try
            {

                StreamReader sr = new StreamReader("C:\\DragonsJourney\\levels.txt");

                while ((line = sr.ReadLine()) != null)
                {
                    
                    LevelsNames[ActualNumberOfLevels] = line;
                    ActualNumberOfLevels++;
                   
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
