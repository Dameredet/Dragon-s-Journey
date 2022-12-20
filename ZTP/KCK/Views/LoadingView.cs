using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KCK.Views
{
    interface ILoadingView
    {
        void Load();
    }
    class LoadingView : ILoadingView
    {
        public void Load()
        {
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
        public void Load()
        {
           
        }
    }
}
