using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Views
{
    interface ILoadingView
    {
        void Load();
    }
    class LoadingView : ILoadingView
    {
        public void Load()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            string textToEnter = "█▒▒▒▒▒▒▒▒▒ 10%";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(300);
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            textToEnter = "██▒▒▒▒▒▒▒▒ 20%";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(300);
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            textToEnter = "███▒▒▒▒▒▒▒ 30%";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(300);
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            textToEnter = "████▒▒▒▒▒▒ 40%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(300);
            textToEnter = "█████▒▒▒▒▒ 50%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(600);
            textToEnter = "██████▒▒▒▒ 60%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(200);
            textToEnter = "███████▒▒▒ 70%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(400);
            textToEnter = "████████▒▒ 80%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(300);
            textToEnter = "█████████▒ 90%";
            Console.SetCursorPosition(Console.CursorLeft, Console.WindowHeight / 2);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
            System.Threading.Thread.Sleep(1300);
        }
    }

    class GraphicLoadingView: ILoadingView
    {
        string[] loadingSkull = new string[]{
        ".                                                      .",
        " .n                   .                 .                  n.",
        ".   .dP                  dP                   9b                 9b.    .",
        " 4    qXb         .       dX                     Xb       .        dXp     t",
        "dX.    9Xb      .dXb    __                         __    dXb.     dXP     .Xb",
        "9XXb._       _.dXXXXb dXXXXbo.                 .odXXXXb dXXXXb._       _.dXXP",
        "9XXXXXXXXXXXXXXXXXXXVXXXXXXXXOo.           .oOXXXXXXXXVXXXXXXXXXXXXXXXXXXXP",
        "`9XXXXXXXXXXXXXXXXXXXXX'~   ~`OOO8b   d8OOO'~   ~`XXXXXXXXXXXXXXXXXXXXXP'",
        "`9XXXXXXXXXXXP' `9XX'   DIE    `98v8P'  HUMAN   `XXP' `9XXXXXXXXXXXP'",
        "~~~~~~~       9X.          .db|db.          .XP       ~~~~~~~",
        ")b.  .dbo.dP'`v'`9b.odb.  .dX(",
        ",dXXXXXXXXXXXb     dXXXXXXXXXXXb.",
        "dXXXXXXXXXXXP'   .   `9XXXXXXXXXXXb",
        "dXXXXXXXXXXXXb   d|b   dXXXXXXXXXXXXb",
        "9XXb'   `XXXXXb.dX|Xb.dXXXXX'   `dXXP",
        "`'      9XXXXXX(   )XXXXXXP      `'",
        "XXXX X.`v'.X XXXX",
        "XP^X'`b   d'`X^XX",
        "X. 9  `   '  P )X",
        "`b  `       '  d'",
        "`             '" };

        public void Load()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for(int i = loadingSkull.Length-1; i > 0 ; i--)
            {
                Console.SetCursorPosition(Console.CursorLeft, 10);

                Console.ForegroundColor = ConsoleColor.White;
                for (int black = 0; black < i; black++)
                {
                    PrintCentred(loadingSkull[black]);
                    System.Threading.Thread.Sleep(10);
                }

                Console.ForegroundColor = ConsoleColor.Red;
                for (int white = i; white < loadingSkull.Length - 1; white++)
                {
                    PrintCentred(loadingSkull[white]);
                    System.Threading.Thread.Sleep(10);
                }

            }
        }

        private void PrintCentred(string text)
        {

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));


        }
    }
}
