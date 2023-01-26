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
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetWindowSize(213, 50);
            Console.SetBufferSize(237, 56);
            Console.CursorVisible = false;

            var GraphicsManager = GraphicMode.GetInstance();
            GraphicsManager.SetGameView(GameView.GetInstance());
            GraphicsManager.SetPointsView(new PointsView());
            GraphicsManager.SetMenuView(MenuView.GetInstance());
            GraphicsManager.SetBestView(new BestView());
            GraphicsManager.SetLoadingView(new LoadingView());
            GraphicsManager.SetLostView(new LostView());
            GraphicsManager.SetGraphicMode(new NormalMode());

            var menuController = MenuController.GetInstance();
            menuController.LoadLevelNames();
            menuController.Menu();
        }
    }
}
