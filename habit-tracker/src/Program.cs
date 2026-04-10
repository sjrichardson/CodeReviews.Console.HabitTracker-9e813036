using System;
using habit_tracker.src.DB;
using habit_tracker.src;
using Microsoft.Data.Sqlite;
namespace habit_tracker
{
    class Program
    {
        static void Main(string[] args)
        {
           var database = new Database(@"habit-Tracker.db");
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("MAIN MENU");
                Console.WriteLine("\nWhat would you like to do");
            }
        }
    }
}