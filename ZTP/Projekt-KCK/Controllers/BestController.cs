using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Projekt_KCK.Views;

namespace Projekt_KCK.Controllers
{
    class BestController
    {
        private static BestController instance;

        private BestController() { }

        public static BestController GetInstance()
        {
            if (instance == null) instance = new BestController();
            return instance;
        }

        public string[] BestNames = new string[10];
        public int[] BestScores = new int[10];
        public void Best()
        {
            var bestView = GraphicMode.GetInstance();
            bestView.SetSceneForBests();

            ReadTheScores();
            ShowTheScores();

            ConsoleKeyInfo playerAction;
            playerAction = Console.ReadKey();

            var menuController = MenuController.GetInstance();
            menuController.Menu();

        }
    
        public void CompareScores(int score)
        {
            ReadTheScores();

            for (int i = 0; i < 10; i++)
            {
                if (score > BestScores[i])
                {
                    string newname = "";
                    newname = AskForBestName();
                    ScoresDrop(score, newname, i);
                    ShowTheScores();
                    break;
                }
            }
        }

        private string AskForBestName()
        {
            var bestView = GraphicMode.GetInstance();
            bestView.AskForBestName();
            string bestname;
            bestname = Console.ReadLine();
            return bestname;
        }

        private void ScoresDrop(int score, string name, int position)
        {
            int TempScore = 0;
            string TempName = " ";

            int helpScore = 0;
            string helpName = " ";

            for (int i = position; i < 10; i++)
            {
                if (i == position)
                {
                    TempName = BestNames[i];
                    TempScore = BestScores[i];

                    BestNames[i] = name;
                    BestScores[i] = score;
                }
                else
                {
                    if (i < 9)
                    {
                        helpScore = BestScores[i];
                        helpName = BestNames[i];

                        BestNames[i] = TempName;
                        BestScores[i] = TempScore;

                        TempName = helpName;
                        TempScore = helpScore;
                    }
                    else { 
                        if (i == 9)
                        {
                            BestNames[i] = TempName;
                            BestScores[i] = TempScore;
                        }
                    }
                }
            }

            WriteTheScores();
            var bestController = BestController.GetInstance(); //SCOREBOARD
            bestController.Best();
        }

        private void ShowTheScores()
        {
            var bestView = GraphicMode.GetInstance(); 
            for (int i = 0; i<10; i++)
            {
                bestView.Print(BestNames[i], BestScores[i], i);
            }
            
        }

        private void WriteTheScores()
        {
            string file = ("C:\\DragonsJourney\\scores.txt");

            StreamWriter sw = new StreamWriter(file);

            for (int i = 0; i < 10; i++)
            {
                sw.WriteLine(BestNames[i]);
                sw.WriteLine(BestScores[i]);
            }
            sw.Close();
        }

        private void ReadTheScores()
        {
            String line;
            try
            {

                StreamReader sr = new StreamReader("C:\\DragonsJourney\\scores.txt");

                for(int i = 0; i < 10; i++)
                {
                    line = sr.ReadLine();
                    BestNames[i] = line;
                    
                    line = sr.ReadLine();
                    BestScores[i] = Int32.Parse(line);
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
