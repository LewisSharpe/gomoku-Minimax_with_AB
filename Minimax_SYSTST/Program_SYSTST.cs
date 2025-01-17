﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace Minimax_SYSTST
{
    // STATIC CONSTANTS USED TO INFORM GAMEPLAY
    static class Consts
    {
        public const int MAX_SCORE = 1001;
        public const int MIN_SCORE = -1001;
        public const int NO_OF_DIRS = 3;
        public static readonly int[] DIRECTIONS = { 1, 9, 10 };
    }

    // COUNTER TYPES - ABLE TO PLACE OF BOARD
    public enum counters
    {
        O,
        X,
        BORDER,
        e
    }

    // MAIN EXECUTION
    class Program
    {
        public static void Main()
        {
            // MENU CHOICE PROMPT
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
      

            DisplayMenu();
            int menuChoice  = 2;  // HWL: hard-wire input so that you can redirect output to a file
	    /*
            while (!(int.TryParse(Console.ReadKey().KeyChar.ToString(), out menuChoice) && (menuChoice >= 1 && menuChoice <= 4)))
                Console.Write("\nInvalid input. Try again: ");
            Console.WriteLine();
	    */
	    
            // SELECTION 1 HUMAN V AI
            if (menuChoice == 1)
            {
                Console.Write("\nEnter your name: ");
                string name = Console.ReadLine();
                Console.Write("Would you like to be X or O? ");
                counters counter;
                char new_counter;
                while (!(char.TryParse(Console.ReadKey().KeyChar.ToString().ToUpper(), out new_counter) && (new_counter == 'X' || new_counter == 'O')))
                    Console.Write("\nInvalid counter. Enter 'X' or 'O': ");
                if (new_counter == 'X')
                {
                    counter = counters.X;
                }
                else if (new_counter == 'O')
                {
                    counter = counters.O;
                }
                else
                {
                    counter = counters.e;
                }

                Player_SYSTST player = new HumanPlayer_SYSTST(name, counter);
                Player_SYSTST computer = new AIPlayer_SYSTST(player.otherCounter);
                Game_SYSTST game;
                if (counter == counters.X)
                    game = new Game_SYSTST(player, computer);
                else
                    game = new Game_SYSTST(computer, player);
            }
            // SELECTION 2 AI V AI
            if (menuChoice == 2)
            {
                counters counter;
                counter = counters.X;
                Player_SYSTST player = new AIPlayer_SYSTST(counter);
                Player_SYSTST computer = new AIPlayer_SYSTST(player.otherCounter);
                Game_SYSTST game;
                if (counter == counters.X)
                    game = new Game_SYSTST(player, computer);
                else
                    game = new Game_SYSTST(computer, player);
            }
            // SELECTION 3 HUMAN V HUMAN
            if (menuChoice == 3)
            {
                Console.Write("\nEnter name for X: ");
                string xName = Console.ReadLine();
                Console.Write("Enter name for O: ");
                string oName = Console.ReadLine();
                Player_SYSTST xplayer = new HumanPlayer_SYSTST(xName, counters.X);
                Player_SYSTST oplayer = new HumanPlayer_SYSTST(oName, counters.O);
                Game_SYSTST game = new Game_SYSTST(xplayer, oplayer); // play game execution
            }
            // SELECTION 4 EXIT
            Environment.Exit(0);
        }

        // DISPLAY MENU OPTIONS TO USER
        static void DisplayMenu()
        {
            // menu centered
            Console.Clear();
            /*
            string welcome = "Welcome to Tic Tac Toe! HWL TEST VERSION";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            string menu = "Menu:";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (menu.Length / 2)) + "}", menu));
            string o1 = "1.Play against the computer";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (o1.Length / 2)) + "}", o1));
            string o2 = "2. Play AI against itself";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (o2.Length / 2)) + "}", o2));
            string o3 = "3. Play against another player";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (o3.Length / 2)) + "}", o3));
            string o4 = "4. Exit";
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (o4.Length / 2)) + "}", o4));
            */
       }
    }
}