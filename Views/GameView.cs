using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_KCK.Views
{
    interface IGameView
    {
        void SetUpScene();
        void DrawLives(int number);
        void DrawFire(int column, int row, bool fix = true);
        void DrawWall(int column, int row, bool fix = true);
        void DrawHeart(int column, int row, bool fix = true);
        void DrawCoin(int column, int row, bool fix = true);
        void DrawEnd(int column, int row, bool fix = true);
        void DrawHuman(int column, int row, bool fix = true);
        void DrawDragonRight(int column, int row, bool fix = true);
        void DrawDragonLeft(int column, int row);
        void DrawDragoRightFire(int column, int row);
        void DrawDragoLeftFire(int column, int row);
        void DrawMove(int movetype, int ammonut, int row, bool InCyan = false);
        void DrawTips(string message, string type);
        void SetUpEditorScene();
        void DrawSelection(int collumn, int row, bool IsGreen = false, bool AdjustmentNeeded = true);
        void ClearBlock(int column, int row);
        void ClearMove(int lastMoveIndex);
        void ClearHeart(int heartsLeft);
 
    }
    class GameView : IGameView
    {
        private static GameView instance;

        private GameView() { }

        public static GameView GetInstance()
        {
            if (instance == null) instance = new GameView();
            return instance;
        }

        // Linie: rząd 5, kolumna 200
        // Serca: po 20 kolumn, po 4 rzędy
        // Przeciwnicy: po 5 rzędów, po 10 kolumn
        // Smok: 5 rzędów, 10 kolumn


        protected static int origRow;
        protected static int origCol;


        protected int[] HeartsPlacement = new int[4] { 0, 0, 15, 30 };
        protected int[] MovesPlacement = new int[19] { 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60 };


        private int AdjustmentRow(int RowNumber)
        {
            int RowAdress = RowNumber * 5 + 6;
            return RowAdress;
        }
        private int AdjustmentCollumn(int CollumnNumber)
        {
            int CollumnAdress = CollumnNumber * 10;
            return CollumnAdress;
        }

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        private void ClearSpace(int StartRow, int StartColumn, int EndRow, int EndColumn)
        {
            for(int i = StartColumn; i<=EndColumn;i++)
            {
                for(int j = StartRow; j <= EndRow; j++) WriteAt(" ", i, j);
            }
        }
        public void ClearMove(int row)
        {
            ClearSpace(MovesPlacement[row], 201,MovesPlacement[row]+2,234);
        }
        public void ClearHeart(int number)
        {
            ClearSpace(0, HeartsPlacement[number],  3, HeartsPlacement[number]+14);
        }
        public void ClearBlock( int column,int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);
            ClearSpace(row,column,row+4,column+9);
        }


        public void SetUpScene()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            DrawTheLines();
            WriteMoves();
            DrawLives(1);
            DrawLives(2);
        }
        private void DrawTheLines()
        {
            Console.Clear();

            //237, 63 - wymiary okna
            for(int i = 0; i<200;i++) WriteAt("-",i,5);
            for (int i = 0; i < 63; i++) WriteAt("|",200,i);
            for (int i = 0; i < 200; i++) WriteAt("-", i, 56);
            WriteAt("+", 200, 5);
            WriteAt("+", 200, 56);
        }

        private void WriteMoves()
        {
            WriteAt("████████████████████████████████", 203, 0);
            WriteAt("█▄─▀█▀─▄█─▄▄─█▄─█─▄█▄─▄▄─█─▄▄▄▄█", 203, 1);
            WriteAt("██─█▄█─██─██─██▄▀▄███─▄█▀█▄▄▄▄─█", 203, 2);
            WriteAt("▀▄▄▄▀▄▄▄▀▄▄▄▄▀▀▀▄▀▀▀▄▄▄▄▄▀▄▄▄▄▄▀", 203, 3);
        }
        public void DrawLives(int number)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt(" .-^-,-^-.", HeartsPlacement[number], 0);
            WriteAt("(         )", HeartsPlacement[number], 1);
            WriteAt(" \\.     ./", HeartsPlacement[number], 2);
            WriteAt("   \\._./", HeartsPlacement[number], 3);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawFire(int column, int row, bool fix = true)
        {
            if(fix == true) {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int j = 0; j < 5; j++){ 
                 for (int i = 0; i < 10; i++){ 
                    if(j==3) Console.ForegroundColor = ConsoleColor.Red;
                    WriteAt("|", column + i, row + j);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawWall(int column, int row, bool fix = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 5; j++)
                    WriteAt("▒", column + i, row + j);
        }
        public void DrawHeart(int column, int row, bool fix = true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            WriteAt(" .-^-,-^-.", column, row);
            WriteAt(" (       )", column, row+1);
            WriteAt(" \\.     ./", column, row+2);
            WriteAt("  \\     / ", column, row+3);
            WriteAt("   \\._./  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawCoin(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteAt("   ____   ", column, row);
            WriteAt("  / __ \\  ", column, row + 1);
            WriteAt(" / /  \\ \\ ", column, row + 2);
            WriteAt(" \\ \\__/ / ", column, row + 3);
            WriteAt("  \\____/  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DrawEnd(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteAt("          ", column, row);
            WriteAt("    THE   ", column, row + 1);
            WriteAt("          ", column, row + 2);
            WriteAt("    END   ", column, row + 3);
            WriteAt("          ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            DrawSelection(column, row, true, false);
        }
        public void DrawHuman(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("          ", column, row);
            WriteAt("     _    ", column, row + 1);
            WriteAt("  \\/'-'\\/ ", column, row + 2);
            WriteAt("   \\_;_/  ", column, row + 3);
            WriteAt("    / \\   ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;

            
        }

        public void DrawDragonRight(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(" /\\_./o__ ", column, row + 2);
            WriteAt("(/^/(_^^' ", column, row + 3);
            WriteAt("<=(_.)_   ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            // /\_./o__        
            //(/^/(_^^'        
            //<=(_.)_   
        }

        public void DrawDragonLeft(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("        ", column, row);
            WriteAt("        ", column, row + 1);
            WriteAt(" __o\\._ /\\", column, row + 2);
            WriteAt(" '^^_)\\^\\)", column, row + 3);
            WriteAt("  _(._).=>", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            //   __o\._ /\
            //   '^^_)\^\)
            //   _(._).=>
        }

        public void DrawDragoRightFire(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(" /\\_./o_<", column, row + 2);
            WriteAt("(/^/(_^^' ", column, row + 3);
            WriteAt("<=(_.)_  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            // /\_./o_<        
            //(/^/(_^^'        
            //<=(_.)_   
        }
        public void DrawDragoLeftFire(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Green;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(">_o\\._ /\\", column, row + 2);
            WriteAt("'^^_)\\^\\)", column, row + 3);
            WriteAt(" _(._).=>", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            //   >_o\._ /\
            //   '^^_)\^\)
            //   _(._).=>
        }


        public void DrawMove(int movetype, int ammonut, int row, bool InCyan = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (InCyan) Console.ForegroundColor = ConsoleColor.Cyan;

            if (movetype == 1) {
                WriteAt("█░█ █▀█", 201,MovesPlacement[row]);
                WriteAt("█▄█ █▀▀", 201, MovesPlacement[row]+1);
            }
            if (movetype == 2)
            {
                WriteAt("█▀▄ █▀█ █░█░█ █▄░█", 201, MovesPlacement[row]);
                WriteAt("█▄▀ █▄█ ▀▄▀▄▀ █░▀█", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 3)
            {
                WriteAt("█▀█ █ █▀▀ █░█ ▀█▀", 201, MovesPlacement[row]);
                WriteAt("█▀▄ █ █▄█ █▀█ ░█░", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 4)
            {
                WriteAt("█░░ █▀▀ █▀▀ ▀█▀", 201, MovesPlacement[row]);
                WriteAt("█▄▄ ██▄ █▀░ ░█░", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 5)
            {
                WriteAt("█▀▀ █ █▀█ █▀▀", 201, MovesPlacement[row]);
                WriteAt("█▀░ █ █▀▄ ██ ", 201, MovesPlacement[row] + 1);
            }

            WriteAt("x"+ammonut,230, MovesPlacement[row] + 1);

            WriteAt("----------------------------------", 201, MovesPlacement[row] + 2);
        }
        
        public void DrawTips(string message, string type)
        {
            WriteAt("                                                                     ", 0, 60);
            if (type == "WARNING")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if(type == "tip")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            WriteAt(message,0,60);
        }

        public void SetUpEditorScene()
        {
            DrawTheLines();
            DrawEditor();
            DrawInstruction();
        }

        private void DrawEditor()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            WriteAt("█▄─▄▄─█▄─▄▄▀█▄─▄█─▄─▄─█─▄▄─█▄─▄▄▀█", 0, 1);
            WriteAt("██─▄█▀██─██─██─████─███─██─██─▄─▄█", 0, 2);
            WriteAt("▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▀▀▄▄▄▀▀▄▄▄▄▀▄▄▀▄▄▀", 0, 3);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DrawInstruction()
        {
            DrawWall(203, AdjustmentRow(0), false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 1.", 218, AdjustmentRow(0)+4);
            DrawCoin(203, AdjustmentRow(1)+1, false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 2.", 218, AdjustmentRow(1)+1 + 4);
            DrawDragonRight(203, AdjustmentRow(2) + 2, false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 3.", 218, AdjustmentRow(2)+2 + 4);
            DrawHuman(203, AdjustmentRow(3)+3, false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 4.", 218, AdjustmentRow(3)+3 + 4);
            DrawHeart(203, AdjustmentRow(4)+4, false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 5.", 218, AdjustmentRow(4)+4 + 4);
            DrawEnd(203, AdjustmentRow(5)+5, false);
            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("press 6.", 218, AdjustmentRow(5)+5 + 4);

            WriteAt("To clear press BACKSPACE.", 203, AdjustmentRow(6)+6);
            WriteAt("To exit and save press ENTER.", 203, AdjustmentRow(6) + 8);
        }

        public void DrawSelection(int collumn, int row, bool IsGreen = false, bool AdjustmentNeeded = true)
        {
            if (AdjustmentNeeded) { 
            row = AdjustmentRow(row);
            collumn = AdjustmentCollumn(collumn);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            if(IsGreen) Console.ForegroundColor = ConsoleColor.DarkGreen;
            WriteAt("+--------+",collumn,row);
            WriteAt("|", collumn, row+1);
            WriteAt("|", collumn+9, row + 1);
            WriteAt("|", collumn, row + 2);
            WriteAt("|", collumn + 9, row + 2);
            WriteAt("|", collumn, row + 3);
            WriteAt("|", collumn + 9, row + 3);
            WriteAt("+--------+", collumn, row + 4);
        }

    }

    class DoomAndGloomGameView : IGameView
    {
        private static DoomAndGloomGameView instance;

        private DoomAndGloomGameView() { }

        public static DoomAndGloomGameView GetInstance()
        {
            if (instance == null) instance = new DoomAndGloomGameView();
            return instance;
        }


        protected static int origRow;
        protected static int origCol;


        protected int[] HeartsPlacement = new int[4] { 0, 0, 15, 30 };
        protected int[] MovesPlacement = new int[19] { 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60 };


        private int AdjustmentRow(int RowNumber)
        {
            int RowAdress = RowNumber * 5 + 6;
            return RowAdress;
        }
        private int AdjustmentCollumn(int CollumnNumber)
        {
            int CollumnAdress = CollumnNumber * 10;
            return CollumnAdress;
        }

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void DrawCoin(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("   ____   ", column, row);
            WriteAt("  / __ \\  ", column, row + 1);
            WriteAt(" / /  \\ \\ ", column, row + 2);
            WriteAt(" \\ \\__/ / ", column, row + 3);
            WriteAt("  \\____/  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawDragoLeftFire(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(">_~\\._ /\\", column, row + 2);
            WriteAt("'^^_)\\^\\)", column, row + 3);
            WriteAt(" _(._).=>", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawDragonLeft(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("        ", column, row);
            WriteAt("        ", column, row + 1);
            WriteAt(" __~\\._ /\\", column, row + 2);
            WriteAt(" '^^_)\\^\\)", column, row + 3);
            WriteAt("  _(._).=>", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawDragonRight(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(" /\\_./~__ ", column, row + 2);
            WriteAt("(/^/(_^^' ", column, row + 3);
            WriteAt("<=(_.)_   ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawDragoRightFire(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("          ", column, row);
            WriteAt("          ", column, row + 1);
            WriteAt(" /\\_./~_<", column, row + 2);
            WriteAt("(/^/(_^^' ", column, row + 3);
            WriteAt("<=(_.)_  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawEnd(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("          ", column, row);
            WriteAt(" WELLCOME ", column, row + 1);
            WriteAt("    TO    ", column, row + 2);
            WriteAt("   HELL   ", column, row + 3);
            WriteAt("          ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
            DrawSelection(column, row, true, false);
        }

        public void DrawFire(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (j == 3) Console.ForegroundColor = ConsoleColor.Red;
                    WriteAt("|", column + i, row + j);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawHeart(int column, int row, bool fix = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            WriteAt(" .-^-,-^-.", column, row);
            WriteAt(" (       )", column, row + 1);
            WriteAt(" \\.     ./", column, row + 2);
            WriteAt("  \\     / ", column, row + 3);
            WriteAt("   \\._./  ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawHuman(int column, int row, bool fix = true)
        {
            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            Console.ForegroundColor = ConsoleColor.White;
            WriteAt("     .    ", column, row);
            WriteAt("    o|    ", column, row + 1);
            WriteAt("  <7O|=   ", column, row + 2);
            WriteAt("  (<( }-. ", column, row + 3);
            WriteAt("  ||//    ", column, row + 4);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawLives(int number)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("    .-.   ", HeartsPlacement[number], 0);
            WriteAt("   (0.0)  ", HeartsPlacement[number], 1);
            WriteAt(" '=.|m|.='", HeartsPlacement[number], 2);
            WriteAt(".='`''``=.", HeartsPlacement[number], 3);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawMove(int movetype, int ammonut, int row, bool InRed = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (InRed) Console.ForegroundColor = ConsoleColor.Red;

            if (movetype == 1)
            {
                WriteAt("█░█ █▀█", 201, MovesPlacement[row]);
                WriteAt("█▄█ █▀▀", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 2)
            {
                WriteAt("█▀▄ █▀█ █░█░█ █▄░█", 201, MovesPlacement[row]);
                WriteAt("█▄▀ █▄█ ▀▄▀▄▀ █░▀█", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 3)
            {
                WriteAt("█▀█ █ █▀▀ █░█ ▀█▀", 201, MovesPlacement[row]);
                WriteAt("█▀▄ █ █▄█ █▀█ ░█░", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 4)
            {
                WriteAt("█░░ █▀▀ █▀▀ ▀█▀", 201, MovesPlacement[row]);
                WriteAt("█▄▄ ██▄ █▀░ ░█░", 201, MovesPlacement[row] + 1);
            }
            if (movetype == 5)
            {
                WriteAt("█▀▀ █ █▀█ █▀▀", 201, MovesPlacement[row]);
                WriteAt("█▀░ █ █▀▄ ██ ", 201, MovesPlacement[row] + 1);
            }

            WriteAt("x" + ammonut, 230, MovesPlacement[row] + 1);

            WriteAt("----------------------------------", 201, MovesPlacement[row] + 2);
        }

        public void DrawSelection(int collumn, int row, bool IsGreen = false, bool AdjustmentNeeded = true)
        {
            if (AdjustmentNeeded)
            {
                row = AdjustmentRow(row);
                collumn = AdjustmentCollumn(collumn);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            WriteAt("x--------x", collumn, row);
            WriteAt("|", collumn, row + 1);
            WriteAt("|", collumn + 9, row + 1);
            WriteAt("|", collumn, row + 2);
            WriteAt("|", collumn + 9, row + 2);
            WriteAt("|", collumn, row + 3);
            WriteAt("|", collumn + 9, row + 3);
            WriteAt("x--------x", collumn, row + 4);
        
    }

        public void DrawTips(string message, string type)
        {
            //nothing, no tips
        }

        public void DrawWall(int column, int row, bool fix = true)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            if (fix == true)
            {
                row = AdjustmentRow(row);
                column = AdjustmentCollumn(column);
            }

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 5; j++)
                    WriteAt("▒", column + i, row + j);
        }

        public void SetUpEditorScene()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteAt("█▄─▄▄─█▄─▄▄▀█▄─▄█─▄─▄─█─▄▄─█▄─▄▄▀█", 0, 1);
            WriteAt("██─▄█▀██─██─██─████─███─██─██─▄─▄█", 0, 2);
            WriteAt("▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▀▀▄▄▄▀▀▄▄▄▄▀▄▄▀▄▄▀", 0, 3);

            WriteAt("INSTRUCTIONS ARE FOR SUCKERS",203, AdjustmentRow(0));
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void SetUpScene()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteAt("████████████████████████████████", 203, 0);
            WriteAt("█▄─▀█▀─▄█─▄▄─█▄─█─▄█▄─▄▄─█─▄▄▄▄█", 203, 1);
            WriteAt("██─█▄█─██─██─██▄▀▄███─▄█▀█▄▄▄▄─█", 203, 2);
            WriteAt("▀▄▄▄▀▄▄▄▀▄▄▄▄▀▀▀▄▀▀▀▄▄▄▄▄▀▄▄▄▄▄▀", 203, 3);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ClearSpace(int StartRow, int StartColumn, int EndRow, int EndColumn)
        {
            for (int i = StartColumn; i <= EndColumn; i++)
            {
                for (int j = StartRow; j <= EndRow; j++) WriteAt(" ", i, j);
            }
        }
        public void ClearMove(int row)
        {
            ClearSpace(MovesPlacement[row], 201, MovesPlacement[row] + 2, 234);
        }
        public void ClearHeart(int number)
        {
            ClearSpace(0, HeartsPlacement[number], 3, HeartsPlacement[number] + 14);
        }
        public void ClearBlock(int column, int row)
        {
            row = AdjustmentRow(row);
            column = AdjustmentCollumn(column);
            ClearSpace(row, column, row + 4, column + 9);
        }
    }
}
