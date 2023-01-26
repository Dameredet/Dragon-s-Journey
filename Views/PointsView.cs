using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Views
{
    interface IPointsView
    {
        void ShowPoints(int Finish, int Coins, int BaseBonus, int MovesUsed, int HeartBonus);
    }
    class PointsView : IPointsView
    {

        public void ShowPoints(int Finish, int Coins, int BaseBonus, int MovesUsed, int HeartBonus)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            string text = "How many points did you get?";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
            Console.WriteLine();

            PrintCentred("Finish", Finish, ".");
            PrintCentred("Coins", Coins, "+");
            PrintCentred("Base Bous", BaseBonus, "+");
            PrintCentred("Moves Used", MovesUsed, "-");
            PrintCentred("Hearts Bous", HeartBonus, "+");


            Console.WriteLine(); 
            text = "TOTAL SCORE: " + (Finish+Coins+BaseBonus-MovesUsed+HeartBonus);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            text = "(Press any key to continue.)";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private void PrintCentred(string PointsName, int PointsValue, string Znak)
        {

            for (int i = 0; i < (20 -1 - PointsName.Length - PointsValue.ToString().Length); i++) //15 znaków na rządek
            {
                PointsName += ".";
            }
            PointsName += Znak;
            PointsName += PointsValue.ToString();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (PointsName.Length / 2)) + "}", PointsName));
            

        }

    }

    class DoomAndGloomPointsView : IPointsView
    {
        public void ShowPoints(int Finish, int Coins, int BaseBonus, int MovesUsed, int HeartBonus)
        {
            string text = " ";
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            PrintCentred("You met the end", Finish, ".");
            PrintCentred("You stole the gold", Coins, "+");
            PrintCentred("You are not a loser", BaseBonus, "+");
            PrintCentred("You wasted time", MovesUsed, "-");
            PrintCentred("You broke some hearts", HeartBonus, "+");


            Console.WriteLine();
            text = "In the end it doesn't even matter, but whatever: " + (Finish + Coins + BaseBonus - MovesUsed + HeartBonus);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            text = "Just go.";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        private void PrintCentred(string PointsName, int PointsValue, string Znak)
        {

            for (int i = 0; i < (20 - 1 - PointsName.Length - PointsValue.ToString().Length); i++) //15 znaków na rządek
            {
                PointsName += ".";
            }
            PointsName += Znak;
            PointsName += PointsValue.ToString();
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (PointsName.Length / 2)) + "}", PointsName));


        }

    }
}
