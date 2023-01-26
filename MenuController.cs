using System;
using System.Collections.Generic;
using System.Text;
using Projekt_KCK.Views;
using Projekt_KCK.Controllers;
using System.IO;

namespace Projekt_KCK.Controllers
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
            menuView.Print(FirstTime);

            

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
                        menuView.SwitchUp(choice);
                    }
                }
                else if (ConsoleKey.DownArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    if (choice < 4)
                    {
                        choice++;
                        menuView.SwitchDown(choice);
                    }
                }
                else if (ConsoleKey.Enter == playerAction.Key) {
                   
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
                    GraphicsManager.SwitchGraphicMode();
                    Menu();
                    break;
                case 104:
                    System.Environment.Exit(3); //EXIT
                    break;
            }


        }

        private void LevelChoice(bool forEditor)
        {
            

            var menuView = GraphicMode.GetInstance();
            var MusicManager = new Muzyka();
            ConsoleKeyInfo playerAction;

            
            menuView.PrintLevels(forEditor);

            if (forEditor) {
                if (LevelsNames[ActualNumberOfLevels - 1] != "NEW LEVEL" && LevelsNames[ActualNumberOfLevels] != "Generate Random")
                {
                    LevelsNames[ActualNumberOfLevels] = "NEW LEVEL";
                    ActualNumberOfLevels++;
                    LevelsNames[ActualNumberOfLevels] = "Generate Random";
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
                        if (LevelName == "Generate Random") gameController.GenerateRandomLevel();
                        else
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
            string newlevelname = Console.ReadLine();
            LevelsNames[ActualNumberOfLevels - 1] = newlevelname;
            AddToLevelNames(newlevelname);
            var gameController = GameController.GetInstance();
            gameController.Editor(newlevelname, true);
        }

        public void AddToLevelNames(string newlevelname)
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
