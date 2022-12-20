using System;
using System.Collections.Generic;
using System.Text;

namespace KCK.Views
{
    interface ILostView{
        void YouLose();
        void YouWin();
        }
    class LostView : ILostView
    {
        protected static void WriteAt(string s, int origCol, int origRow)
        {
            try
            {
                Console.SetCursorPosition(origCol, origRow);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        public void YouLose()
        {
            for(int j = 0; j < 63; j++)
            {
                for(int i = 0; i < 237; i++)
                {
                    WriteAt(" ", i, j);
                }
            }


            Console.ForegroundColor = ConsoleColor.Red;
            string textToEnter = "██╗░░░██╗░█████╗░██╗░░░██╗  ██╗░░░░░░█████╗░░██████╗███████╗";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)),30);
            textToEnter = "╚██╗░██╔╝██╔══██╗██║░░░██║  ██║░░░░░██╔══██╗██╔════╝██╔════╝";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 31);
            textToEnter = "░╚████╔╝░██║░░██║██║░░░██║  ██║░░░░░██║░░██║╚█████╗░█████╗░░";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 32);
            textToEnter = "░░╚██╔╝░░██║░░██║██║░░░██║  ██║░░░░░██║░░██║░╚═══██╗██╔══╝░░";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 33);
            textToEnter = "░░░██║░░░╚█████╔╝╚██████╔╝  ███████╗╚█████╔╝██████╔╝███████╗";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 34);
            textToEnter = "░░░╚═╝░░░░╚════╝░░╚═════╝░  ╚══════╝░╚════╝░╚═════╝░╚══════╝";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 35);
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            textToEnter = "   Press any key to return to menu.   ";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 37);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void YouWin()
        {
            for (int j = 0; j < 63; j++)
            {
                for (int i = 0; i < 237; i++)
                {
                    WriteAt(" ", i, j);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            string textToEnter = "██╗░░░██╗░█████╗░██╗░░░██╗  ░██╗░░░░░░░██╗██╗███╗░░██╗";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 30);
            textToEnter = "╚██╗░██╔╝██╔══██╗██║░░░██║  ░██║░░██╗░░██║██║████╗░██║";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 31);
            textToEnter = "░╚████╔╝░██║░░██║██║░░░██║  ░╚██╗████╗██╔╝██║██╔██╗██║";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 32);
            textToEnter = "░░╚██╔╝░░██║░░██║██║░░░██║  ░░████╔═████║░██║██║╚████║";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 33);
            textToEnter = "░░░██║░░░╚█████╔╝╚██████╔╝  ░░╚██╔╝░╚██╔╝░██║██║░╚███║";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 34);
            textToEnter = "░░░╚═╝░░░░╚════╝░░╚═════╝░  ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚══╝";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 35);


            Console.ForegroundColor = ConsoleColor.Yellow;
            textToEnter = "   Press any key to see your score.   ";
            WriteAt(textToEnter, ((Console.WindowWidth / 2) - (textToEnter.Length / 2)), 37);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class GraphicLostView : ILostView
    {
        
        public void YouLose()
        {
            
        }

        public void YouWin()
        {
            
        }
    }
}
