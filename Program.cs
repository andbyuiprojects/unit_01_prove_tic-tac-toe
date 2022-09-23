//This is a tic-tac-toe game that uses if/then statements, while loops, more then one function and those functions
//called in main. Andrew Olson is the author.

using System;
using System.Collections.Generic;

namespace unit_01_prove_tictactoe
{
    internal class Program
    {
        //Main, runs the whole program.
        static void Main(string[] args)
        {
            List<string> board = NewBoard();
            string playerOne = "x";

            while (!GameOver(board))
            {
                DisplayBoard(board);

                int choice = PlayerMove(playerOne);
                MakeMove(board, choice, playerOne);

                playerOne = NextPlayer(playerOne);
            }

            DisplayBoard(board);
            Console.WriteLine("\nWell Played!\n");


        }

        //Creates a new board.
        static List<string> NewBoard()
        {
            List<string> board = new List<string> ();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        //Displays the board.
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($"\n{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        //Gets the spot of where the user wants to go.
        static int PlayerMove(string playerOne)
        {
            Console.Write($"\n{playerOne}'s turn to pick a location (1-9)\n> ");
            string convertString = Console.ReadLine();

            int choice = int.Parse(convertString);

            return choice;
        }

        //Determines who the next player is.
        static string NextPlayer(string playerOne)
        {
            string nextPlayer = "x";

            if (playerOne == "x")
            {
                nextPlayer = "o";
            }
            
            return nextPlayer;
        }


        //Determines fi the game is over.
        static bool GameOver(List<string> board)
        {
            bool gameOver = false;

            if (PlayerWin(board, "x") || PlayerWin(board, "o"))
            {
                gameOver = true;
            }

            return gameOver;
        }

        static void MakeMove(List<string> board, int choice, string playerOne)
        {
            int indexSpot = choice - 1; 

            board[indexSpot] = playerOne;
        }

        //Checks to see if there is a winner. (see modularization design tic-tac-toe, converted to C# basically)
        static bool PlayerWin(List<string> board, string player)
        {
           bool playerWin = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                playerWin = true;
            }

            return playerWin; 
        }
    }
}