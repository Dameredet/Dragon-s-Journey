using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using KCK.Views;
using KCK.Controllers;

namespace KCK
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        
        static void Main()
        {
            var GraphicsManager = GraphicMode.GetInstance();
            GraphicsManager.TurnOnConsoleMode();

            Console.SetWindowSize(237, 63);
            Console.CursorVisible = false;

            var menuController = MenuController.GetInstance();
            menuController.LoadLevelNames();
            menuController.Menu();


        }
    }
}
