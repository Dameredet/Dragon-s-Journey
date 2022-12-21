using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Design;

namespace Projekt_KCK.Views
{
    class GraphicMode
    {
        public ILostView _LostView;
        public ILoadingView _LoadingView;
        public IBestView _BestView;
        public IMenuView _MenuView;
        public IPointsView _PointsView;
        public IGameView _GameView;

        public bool graphicstype = false;

        private static GraphicMode instance;

        private GraphicMode() { }

        public static GraphicMode GetInstance()
        {
            if (instance == null) instance = new GraphicMode();
            return instance;
        }

        private void SetLostView(ILostView strategy)
        {
            _LostView = strategy;
        }
        private void SetLoadingView(ILoadingView strategy)
        {
            _LoadingView = strategy;
        }
        private void SetBestView(IBestView strategy)
        {
            _BestView = strategy;
        }
        private void SetMenuView(IMenuView strategy)
        {
            _MenuView = strategy;
        }
        private void SetPointsView(IPointsView strategy)
        {
            _PointsView = strategy;
        }
        private void SetGameView(IGameView strategy)
        {
            _GameView = strategy;
        }

        public void TurnOnGraphicMode()
        {
            //InitializeDoomAndGloomMode();
            SetGameView(DoomAndGloomGameView.GetInstance());
            SetPointsView(new DoomAndGloomPointsView());
            SetMenuView(DoomAndGloomMenuView.GetInstance());
            SetBestView(new DoomAndGloomBestView());
            SetLoadingView(new GraphicLoadingView());
            SetLostView(new GraphicLostView());
        }

        public void TurnOnConsoleMode()
        {
            SetGameView(GameView.GetInstance());
            SetPointsView(new PointsView());
            SetMenuView(MenuView.GetInstance());
            SetBestView(new BestView());
            SetLoadingView(new LoadingView());
            SetLostView(new LostView());
        }

        private void InitializeDoomAndGloomMode()
        {
            using Bitmap bmp = new Bitmap(600, 400);
            using Graphics gfx = Graphics.FromImage(bmp);

            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            
        }

        public void YouLose()
        {
            _LostView.YouLose();
        }
        public void YouWin()
        {
            _LostView.YouWin();
        }
        public void SetSceneForBests()
        {
            _BestView.SetSceneForBests();
        }
        public void Print(string name, int score, int where) 
        {
            _BestView.Print( name, score, where);
        }
        public void AskForBestName()
        {
            _BestView.AskForBestName();
        }
        public void Load()
        {
            _LoadingView.Load();
        }
        public void Print(bool isFirstTime)
        {
            _MenuView.Print(isFirstTime);

        }
        public void SwitchDown(int destination)
        {
            _MenuView.SwitchDown(destination);
        }
        public void SwitchUp(int destination)
        {
            _MenuView.SwitchUp(destination);
        }
        public void SwitchUpLevels(int destination, string message, string privious)
        {
            _MenuView.SwitchUpLevels(destination, message, privious);
        }
        public void SwitchDownLevels(int destination, string message, string privious)
        {
            _MenuView.SwitchDownLevels(destination, message, privious);
        }
        public void PrintLevels(bool forEditor)
        {
            _MenuView.PrintLevels(forEditor);
        }
        public void PrintAskName()
        {
            _MenuView.PrintAskName();
        }
        public void ColorRed(string Message)
        {
            _MenuView.ColorRed(Message);
        }
        public void ColorClear(string Message)
        {
            _MenuView.ColorClear(Message);
        }
        public void ShowPoints(int Finish, int Coins, int BaseBonus, int MovesUsed, int HeartBonus)
        {
            _PointsView.ShowPoints(Finish, Coins, BaseBonus, MovesUsed, HeartBonus);
        }
        public void SetUpScene()
        {
            _GameView.SetUpScene();
        }
        public void DrawLives(int number)
        {
            _GameView.DrawLives(number);
        }
        public void DrawFire(int column, int row, bool fix = true)
        {
            _GameView.DrawFire( column,  row,  fix);
        }
        public void DrawWall(int column, int row, bool fix = true)
        {
            _GameView.DrawWall( column,  row, fix);
        }
        public void DrawHeart(int column, int row, bool fix = true)
        {
            _GameView.DrawHeart( column, row,  fix );
        }
        public void DrawCoin(int column, int row, bool fix = true)
        {
            _GameView.DrawCoin( column,  row,  fix );
        }
        public void DrawEnd(int column, int row, bool fix = true)
        {
            _GameView.DrawEnd(column, row,  fix);
        }
        public void DrawHuman(int column, int row, bool fix = true)
        {
            _GameView.DrawHuman(column, row, fix );
        }
        public void DrawDragonRight(int column, int row, bool fix = true)
        {
            _GameView.DrawDragonRight( column,  row, fix);
        }
        public void DrawDragonLeft(int column, int row)
        {
            _GameView.DrawDragonLeft( column,  row);
        }
        public void DrawDragoRightFire(int column, int row)
        {
            _GameView.DrawDragoRightFire( column,  row);
        }
        public void DrawDragoLeftFire(int column, int row)
        {
            _GameView.DrawDragoLeftFire( column,  row);
        }
        public void DrawMove(int movetype, int ammonut, int row, bool InCyan = false)
        {
            _GameView.DrawMove( movetype, ammonut, row,  InCyan);
        }
        public void DrawTips(string message, string type)
        {
            _GameView.DrawTips(message, type);
        }
        public void SetUpEditorScene()
        {
           _GameView.SetUpEditorScene();
        }
        public void DrawSelection(int collumn, int row, bool IsGreen = false, bool AdjustmentNeeded = true)
        {
            _GameView.DrawSelection( collumn,  row, IsGreen, AdjustmentNeeded );
        }
        public void ClearBlock(int column, int row)
        {
            _GameView.ClearBlock(column, row);
        }
        public void ClearMove(int lastMoveIndex)
        {
            _GameView.ClearMove(lastMoveIndex);
        }
        public void ClearHeart(int heartsLeft)
        {
            _GameView.ClearHeart(heartsLeft);
        }
    }
}
