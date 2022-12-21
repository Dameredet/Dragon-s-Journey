using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Projekt_KCK;
using Projekt_KCK.Controllers;
using Projekt_KCK.Views;


namespace Projekt_KCK
{
    class Program
    {

        public static void Main()
        {
            Console.SetWindowSize(213, 50);
            Console.SetBufferSize(237, 63);
            Console.CursorVisible = false;

            var GraphicsManager = GraphicMode.GetInstance();
            GraphicsManager.TurnOnConsoleMode();

            var menuController = MenuController.GetInstance();
            menuController.LoadLevelNames();
            menuController.Menu();
        }
    }
}
