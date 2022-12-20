﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using KCK.Views;

namespace KCK.Controllers
{
    public class GameController
    {
        private static GameController instance;

        private GameController() { }

        public static GameController GetInstance()
        {
            if (instance == null) instance = new GameController();
            return instance;
        }


        //Game 
        private bool Win = false;

        private int CrashCount = 0;

        public int BasePointsBonus = 50;
        public int FinishPoints = 100;
        public int CollectedCoins = 0;
        public int NegativeMovePoints = 0;
        public int HeartsLeft = 2;

        // Typ ruchu, ilość powtórzeń
        public int[,] ListOfMoves = new int[19, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        public int LastMoveIndex = 0;

        public int[,] Blocks = new int[20, 10];
        public int PlayerPositionBlockRow;
        public int PlayerPositionBlockColumn;

        public string DragonsState = "right-calm";

        //Editor
        public int CurrentWinnableCollumn = 0;
        public int CurrentWinnableRow = 0;

        public int CurrentPlayerCollumn = 0;
        public int CurrentPlayerRow = 0;

        public bool IsWinnable = false;
        public bool IsPlayable = false;


        public void Game(string levelname)
        {
            Win = false;
            DragonsState = "right-calm";
            LastMoveIndex = 0;
            HeartsLeft = 2;
            Array.Clear(ListOfMoves,0,ListOfMoves.Length);
            Array.Clear(Blocks, 0, Blocks.Length);

            var loadingView = GraphicMode.GetInstance();
            loadingView.Load();

            LevelCreator(levelname,true);

            Plan();
            Play();
            End();
            
        }

        private void Plan()
        {
            var MusicManager = new Muzyka();

            int PreviousMove = 0;
            int CurrentMove = 0;
            ConsoleKeyInfo playerAction;
            bool Finished = false;
            while (Finished == false)
            {
                playerAction = Console.ReadKey();
                
                if (ConsoleKey.UpArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    PreviousMove = CurrentMove;
                    CurrentMove = 1;
                    AddMove(PreviousMove, CurrentMove);
                }
                else if (ConsoleKey.DownArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    PreviousMove = CurrentMove;
                    CurrentMove = 2;
                    AddMove(PreviousMove, CurrentMove);
                }
                else if (ConsoleKey.RightArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    PreviousMove = CurrentMove;
                    CurrentMove = 3;
                    AddMove(PreviousMove, CurrentMove);
                }
                else if (ConsoleKey.LeftArrow == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    PreviousMove = CurrentMove;
                    CurrentMove = 4;
                    AddMove(PreviousMove, CurrentMove);
                }
                else if (ConsoleKey.Spacebar == playerAction.Key)
                {
                    MusicManager.ClickMusic();
                    PreviousMove = CurrentMove;
                    CurrentMove = 5;
                    AddMove(PreviousMove, CurrentMove);
                }
                else if (ConsoleKey.Backspace == playerAction.Key)
                {
                    RemoveMove();
                }
                else if (ConsoleKey.Enter == playerAction.Key)
                {
                    Finished = true;
                }
            } 
            
        }

        private void Play()
        {
            var gameView = GraphicMode.GetInstance(); 
            var MusicManager = new Muzyka();

            int CurrenAction = 0;
            int WhatsAhead = 0;

            
                for (int i = 0; i < 19; i++) {
                
                    CurrenAction = ListOfMoves[i, 0];
                    if (CurrenAction != 5) {
                        for (int j = 1; j <= ListOfMoves[i, 1]; j++)
                        {
                        gameView.DrawMove(ListOfMoves[i, 0], ListOfMoves[i, 1], i, true);
                        WhatsAhead = Check(CurrenAction);
                        switch (WhatsAhead)
                            {
                                case 1:
                                    MusicManager.CrashMusic();
                                    Crash();
                                    break;
                                case 4:
                                    MusicManager.HitMusic();
                                    TakeDamage();
                                    break;
                                case 2:
                                    Tips("YOU GOT A COIN! YAY!", "tips");
                                    CollectedCoins++;
                                    MusicManager.FlyMusic();
                                    MakeAMove(CurrenAction);
                                    MusicManager.CoinMusic();
                                    break;
                                case 5:
                                    MusicManager.FlyMusic();
                                    MakeAMove(CurrenAction);
                                    MusicManager.HeartMusic();
                                    Tips("YOU GOT A HEART! YAY!", "tips");
                                    if (HeartsLeft < 3) HeartsLeft++;
                                    gameView.DrawLives(HeartsLeft);
                                    break;
                                case 6:
                                    MusicManager.FlyMusic();
                                    MakeAMove(CurrenAction);
                                    Win = true;
                                    break;
                                case 0:
                                default:
                                    MusicManager.FlyMusic();
                                    MakeAMove(CurrenAction);
                                    break;

                            }
                        gameView.DrawMove(ListOfMoves[i, 0], ListOfMoves[i, 1], i);
                    }
                    }
                    else
                    {
                        MusicManager.FireMusic();
                        Fire();
                    }

                }  
        }

        private void End()
        {
            var MusicManager = new Muzyka();
            if (Win)
            {
                MusicManager.IntroMusic();
                System.Threading.Thread.Sleep(2000);
                var lostView = GraphicMode.GetInstance();
                lostView.YouWin();
                ConsoleKeyInfo playerAction;
                playerAction = Console.ReadKey();
                var pointsView = GraphicMode.GetInstance();
                NegativeMovePoints = CalculateMovesUsed();
                pointsView.ShowPoints(FinishPoints, CollectedCoins * 5, BasePointsBonus, NegativeMovePoints, HeartsLeft * 100);
                playerAction = Console.ReadKey();
                var bestController = BestController.GetInstance();
                bestController.CompareScores(FinishPoints+ CollectedCoins * 5+ BasePointsBonus- NegativeMovePoints+ HeartsLeft * 100);
                var menuController = MenuController.GetInstance();
                menuController.Menu();

            }
            else
            {
                MusicManager.LoseMusic();
                var lostView = GraphicMode.GetInstance();
                lostView.YouLose();
                ConsoleKeyInfo playerAction;
                playerAction = Console.ReadKey();
                var menuController = MenuController.GetInstance();
                menuController.Menu();
            }
           
        }


        private void TakeDamage()
        {
            var gameView = GraphicMode.GetInstance();

            for (int i = 0; i < 3; i++)
            {
                gameView.ClearBlock(PlayerPositionBlockColumn,PlayerPositionBlockRow);
                Sleep(300);
                if (DragonsState == "right-calm") gameView.DrawDragonRight(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                else gameView.DrawDragonLeft(PlayerPositionBlockColumn, PlayerPositionBlockRow);
            }
            HeartLose();
            Tips("YOU ARE UNDER ATTACK!","WARNING");
        }

        private void Crash()
        {
            var gameView = GraphicMode.GetInstance();
            CrashCount++;

            for (int i = 0; i < 3; i++)
            {
                gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                Sleep(100);
                if (DragonsState == "right-calm") gameView.DrawDragonRight(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                else gameView.DrawDragonLeft(PlayerPositionBlockColumn, PlayerPositionBlockRow);
            }
            if(CrashCount == 3)
            {
                CrashCount = 0;
                HeartLose();
            }
            Tips("YOU HIT A WALL!", "WARNING");
        }

        private void HeartLose()
        {
            var gameView = GraphicMode.GetInstance();
            gameView.ClearHeart(HeartsLeft);
            if (HeartsLeft > 0) HeartsLeft--;
            else HowIsTheHeart();
        }
        private void HowIsTheHeart()
        {
            if(HeartsLeft == 0)
            {
                Win = false;
                End();
            }
        }

        private void MakeAMove(int MoveDirection)
        {
            var gameView = GraphicMode.GetInstance();

            gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);

            switch (MoveDirection)
            {
                case 1:
                    PlayerPositionBlockRow--;
                    gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    gameView.DrawDragonRight(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    DragonsState = "right-calm";
                    break;
                case 2:
                    PlayerPositionBlockRow++;
                    gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    gameView.DrawDragonLeft(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    DragonsState = "left-calm";
                    break;
                case 3:
                    PlayerPositionBlockColumn++;
                    gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    gameView.DrawDragonRight(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    DragonsState = "right-calm";
                    break;
                case 4:
                    PlayerPositionBlockColumn--;
                    gameView.ClearBlock(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    gameView.DrawDragonLeft(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                    DragonsState = "left-calm";
                    break;
            }
        }

        private void Fire()
        {
            var gameView = GraphicMode.GetInstance();

            Tips("BURN!","tip");

            if(DragonsState == "left-calm")
            {
                gameView.DrawDragoLeftFire(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                DragonsState = "left-fire";
            }
            else
            {
                gameView.DrawDragoRightFire(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                DragonsState = "right-fire";
            }
            Sleep(300);
            for (int i = 1; i < 5; i++)
            {
                if (Check(i) == 4)
                {
                    switch (i)
                    {
                        case 1:
                            Burn(PlayerPositionBlockColumn, PlayerPositionBlockRow-1);
                            break;
                        case 2:
                            Burn(PlayerPositionBlockColumn,PlayerPositionBlockRow+1);
                            break;
                        case 3:
                            Burn(PlayerPositionBlockColumn+1, PlayerPositionBlockRow);
                            break;
                        case 4:
                            Burn(PlayerPositionBlockColumn-1,PlayerPositionBlockRow);
                            break;
                    }
                }
            }
            Sleep(300);
            if (DragonsState == "left-fire")
            {
                gameView.DrawDragonLeft(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                DragonsState = "left-calm";
            }
            else
            {
                gameView.DrawDragonRight(PlayerPositionBlockColumn, PlayerPositionBlockRow);
                DragonsState = "right-calm";
            }
        }

        private void Burn(int column, int row)
        {
            var gameView = GraphicMode.GetInstance();

            gameView.ClearBlock(column, row);
            gameView.DrawFire(column, row);
            Blocks[column, row] = 0;
            Sleep(300);
            gameView.ClearBlock(column, row);
        }

        private int Check(int PlannedMove){
            int checkingRow = PlayerPositionBlockRow;
            int checkingColumn = PlayerPositionBlockColumn;

            switch (PlannedMove)
            {
                case 1:
                    if (checkingRow > 0) checkingRow = PlayerPositionBlockRow - 1;
                    else return 1;
                    break;
                case 2:
                    if (checkingRow < 9) checkingRow = PlayerPositionBlockRow + 1;
                    else return 1;
                    break;
                case 3:
                    if(checkingColumn<19)checkingColumn = PlayerPositionBlockColumn + 1;
                    else return 1;
                    break;
                case 4:
                    if(checkingColumn>0)checkingColumn = PlayerPositionBlockColumn - 1;
                    else return 1;
                    break;
            }

            /*
                         * 0 - pusto
                         * 1 - ściana
                         * 2 - coin
                         * 3 - smok
                         * 4 - przeciwnik
                         * 5 - serduszko
                         * 6 - end
                         */
            switch (Blocks[checkingColumn,checkingRow])
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 4:
                    return 4;
                case 5:
                    return 5;
                case 6:
                    return 6;
                default:
                    return 0;
            }
            
        }

        private void RemoveMove()
        {
            var gameView = GraphicMode.GetInstance();
            if (ListOfMoves[0, 0] != 0) {
                if (ListOfMoves[LastMoveIndex, 1] == 1)
                {
                    ListOfMoves[LastMoveIndex, 0] = 0;
                    ListOfMoves[LastMoveIndex, 1] = 0;
                    gameView.ClearMove(LastMoveIndex);
                    if(LastMoveIndex != 0) LastMoveIndex--;

                }
                else if (ListOfMoves[LastMoveIndex, 1] > 1)
                {
                    ListOfMoves[LastMoveIndex, 1] = ListOfMoves[LastMoveIndex, 1] - 1;
                    gameView.DrawMove(ListOfMoves[LastMoveIndex, 0], ListOfMoves[LastMoveIndex, 1], LastMoveIndex);

                }
            }
        }

        private void AddMove(int PreviousMove, int CurrentMove)
        {
            var gameView = GraphicMode.GetInstance();

            if (LastMoveIndex < 18)
            {
                if (ListOfMoves[0, 0] != 0)
                {
                    if (PreviousMove == CurrentMove)
                    {
                        ListOfMoves[LastMoveIndex, 1] = ListOfMoves[LastMoveIndex, 1] + 1;
                        gameView.DrawMove(ListOfMoves[LastMoveIndex, 0], ListOfMoves[LastMoveIndex, 1], LastMoveIndex);
                    }
                    else
                    {
                        LastMoveIndex++;
                        ListOfMoves[LastMoveIndex, 0] = CurrentMove;
                        ListOfMoves[LastMoveIndex, 1] = +1;
                        gameView.DrawMove(ListOfMoves[LastMoveIndex, 0], ListOfMoves[LastMoveIndex, 1], LastMoveIndex);
                    }
                }
                else
                {
                    ListOfMoves[0, 0] = CurrentMove;
                    ListOfMoves[0, 1] = 1;
                    gameView.DrawMove(ListOfMoves[LastMoveIndex, 0], ListOfMoves[LastMoveIndex, 1], LastMoveIndex);
                }
            }
            else
            {
                var MusicManager = new Muzyka();
                MusicManager.ErrorMusic();
                Tips("!!! Too many commands !!!", "WARNING");
            }
        }

        private void Tips(string Message, string type)
        {
            var gameView = GraphicMode.GetInstance();
            gameView.DrawTips(Message,type);
        }
      
        private void LevelCreator(string level, bool forGame, bool newlevel = false)
        {
            var gameView = GraphicMode.GetInstance();

            if (forGame) gameView.SetUpScene();
            else gameView.SetUpEditorScene();

            if(newlevel == false) ReadLevel(level);

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    DrawWhatsInBlock(j,i);
                }
            }
        }

        private void ReadLevel(string level)
        {
            String line;
            try
            {

                StreamReader sr = new StreamReader("C:\\DragonsJourney\\" + level+ ".txt");

                for (int i = 0; i < 10; i++)
                {
                    line = sr.ReadLine();
                    string[] support = line.Split(' ');
                    for (int j = 0; j < 20; j++)
                    {
                        Blocks[j,i] = Int32.Parse(support[j]);
                        if(Blocks[j, i] == 3)
                        {
                            IsPlayable = true;
                            CurrentPlayerCollumn = j;
                            CurrentPlayerRow = i;
                        }
                        if (Blocks[j, i] == 6)
                        {
                            CurrentWinnableCollumn = j;
                            CurrentWinnableRow = i;
                            IsWinnable = true;
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void Editor(string level, bool newlevel = true)
        {
            var MusicManager = new Muzyka();
            var gameView = GraphicMode.GetInstance();

            Array.Clear(Blocks, 0, Blocks.Length);

            LevelCreator(level, false, newlevel);

            bool IsDone = false;

            ConsoleKeyInfo playerAction;

            int CurrentCollumn = 0;
            int CurrentRow = 0;
            gameView.DrawSelection(CurrentCollumn, CurrentRow);

            int PlayerIsSure = 0;

            while (IsDone == false) {
                Console.SetCursorPosition(230,0);
                playerAction = Console.ReadKey();
                Console.SetCursorPosition(230, 0);
                Console.Write(" ");
                
                switch (playerAction.Key)
                {
                    case ConsoleKey.D6 :
                        PlayerIsSure = 0;
                        if (IsWinnable == false) { 
                        IsWinnable = true;
                        }
                        else
                        {
                            gameView.ClearBlock(CurrentWinnableCollumn, CurrentWinnableRow);
                            Blocks[CurrentWinnableCollumn, CurrentWinnableRow] = 0;
                        }

                        CurrentWinnableCollumn = CurrentCollumn;
                        CurrentWinnableRow = CurrentRow;

                        Blocks[CurrentCollumn, CurrentRow] = 6;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);

                        break;
                    case ConsoleKey.D5:
                        PlayerIsSure = 0;
                        Blocks[CurrentCollumn, CurrentRow] = 5;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.D4:
                        PlayerIsSure = 0;
                        Blocks[CurrentCollumn, CurrentRow] = 4;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.D3:
                        PlayerIsSure = 0;
                        if (IsPlayable == false)
                        {
                            IsPlayable = true;
                        }
                        else
                        {
                            gameView.ClearBlock(CurrentPlayerCollumn, CurrentPlayerRow);
                            Blocks[CurrentPlayerCollumn, CurrentPlayerRow] = 0;
                        }

                        CurrentPlayerCollumn = CurrentCollumn;
                        CurrentPlayerRow = CurrentRow;
                        
                        Blocks[CurrentCollumn, CurrentRow] = 3;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.D2:
                        PlayerIsSure = 0;
                        Blocks[CurrentCollumn, CurrentRow] = 2;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.D1:
                        PlayerIsSure = 0;
                        Blocks[CurrentCollumn, CurrentRow] = 1;
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    
                    case ConsoleKey.Backspace:
                        PlayerIsSure = 0;
                        if (Blocks[CurrentCollumn,CurrentRow] == 6)
                        {
                            IsWinnable = false;
                        }
                        if (Blocks[CurrentCollumn, CurrentRow] == 3)
                        {
                            IsPlayable = false;
                        }
                        Blocks[CurrentCollumn, CurrentRow] = 0;
                        gameView.ClearBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.LeftArrow:
                        MusicManager.ClickMusic();
                        PlayerIsSure = 0;
                        if (CurrentCollumn>0)
                        {
                            DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                            CurrentCollumn--;
                        }
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.RightArrow:
                        MusicManager.ClickMusic();
                        PlayerIsSure = 0;
                        if (CurrentCollumn < 19)
                        {
                            DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                            CurrentCollumn++;
                        }
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.DownArrow:
                        MusicManager.ClickMusic();
                        PlayerIsSure = 0;
                        if (CurrentRow < 9)
                        {
                            DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                            CurrentRow++;
                        }
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.UpArrow:
                        MusicManager.ClickMusic();
                        PlayerIsSure = 0;
                        if (CurrentRow > 0)
                        {
                            DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                            CurrentRow--;
                        }
                        DrawWhatsInBlock(CurrentCollumn, CurrentRow);
                        gameView.DrawSelection(CurrentCollumn, CurrentRow);
                        break;
                    case ConsoleKey.Enter:
                        MusicManager.ClickMusic();
                        PlayerIsSure++;
                        if (IsWinnable == true)
                        {
                            if (IsPlayable == true)
                            {
                                if (PlayerIsSure == 2) { 
                                IsDone = true;
                                }
                                else Tips("Are you sure you want to exit and save? Press Enter to confirm.", "WARNING");
                            }
                            else Tips("Add player to the level!", "WARNING");
                        }
                        else Tips("Add the finish point to the level!", "WARNING");
                        break;
                    default:
                        break;
                }
            }

           WriteLevel(level);
           var menuController = MenuController.GetInstance();
           menuController.Menu();
        }

        private void DrawWhatsInBlock(int collumn, int row)
        {
            var gameView = GraphicMode.GetInstance();

            int block = Blocks[collumn, row];
            switch (block)
            {
                case 6:
                    gameView.DrawEnd(collumn, row);
                    break;
                case 5:
                    gameView.DrawHeart(collumn, row);
                    break;
                case 4:
                    gameView.DrawHuman(collumn, row);
                    break;
                case 3:
                    PlayerPositionBlockRow = row;
                    PlayerPositionBlockColumn = collumn;
                    gameView.DrawDragonRight(collumn, row);
                    break;
                case 2:
                    gameView.DrawCoin(collumn, row);
                    break;
                case 1:
                    gameView.DrawWall(collumn, row);
                    break;
                case 0:
                    gameView.ClearBlock(collumn, row);
                    break;
                default:
                    break;
            }
        }

        private void WriteLevel(string level)
        {
            string file = ("C:\\DragonsJourney\\" + level + ".txt");

            StreamWriter sw = new StreamWriter(file);
            for (int i = 0; i < 10; i++)
            {
                string line = Blocks[0, i].ToString();
                for (int j = 1; j < 20; j++)
                {
                    line = line + " ";
                    line = line + Blocks[j, i].ToString();
                }
                sw.WriteLine(line);
            }
            sw.Close();

        }

        private int CalculateMovesUsed()
        {
            int HowManyMoves = 0;
            for (int i = 0; i<=LastMoveIndex;i++)
            {
                HowManyMoves += ListOfMoves[i,1];
            }
            return HowManyMoves;
        }  

        private void Sleep(int number)
        {
            System.Threading.Thread.Sleep(number);
        }

    }
}
