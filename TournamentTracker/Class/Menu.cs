using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    class Menu
    {
        public static void WelcomeMenu()
        {
            Console.WriteLine("Welcome to Tournament Tracker");
            Console.WriteLine();
            Console.WriteLine("Please select an option to continue: ");
            Console.WriteLine("A. To Create a new Tracker");
            Console.WriteLine("B. To load a previous Tracker");
            Console.WriteLine("C. To Exit program");
            Console.WriteLine("D. For a Tutorial on how to use Tournament Tracker");
        }

        public static void TestDisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("#####################");
            Console.WriteLine("##### Main Menu: ####");
            Console.WriteLine("#####################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option:");
            Console.WriteLine("*************************************************************************************************");

            Console.WriteLine("A. enter team names");
            Console.WriteLine("B. name team matches");
            Console.WriteLine("C. enter team matches");
            Console.WriteLine("D. enter scores");
            Console.WriteLine("E. calculate winner");
            Console.WriteLine("F. display");
            Console.WriteLine("G. enter team matches");
            Console.WriteLine("H. enter scores");
            Console.WriteLine("I. calculate winner");
            Console.WriteLine("J. Exit program");
            Console.WriteLine("**************************************************************************************************");
            Console.WriteLine();
        }
        public static void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("#####################");
            Console.WriteLine("##### Main Menu: ####");
            Console.WriteLine("#####################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option:");
            Console.WriteLine("*************************************************************************************************");

            Console.WriteLine("A. Playing the First Round");
            Console.WriteLine("B. Managing successive rounds");
            Console.WriteLine("C. Find Name/Team");
            Console.WriteLine("D. Graphical Display");
            Console.WriteLine("E. Update/Delete teams");
            Console.WriteLine("F. To Save");
            Console.WriteLine("G. To Exit this Program");
            Console.WriteLine("H. Set Up Tips and Help");
            Console.WriteLine("**************************************************************************************************");
            Console.WriteLine();
        }

        public static void UpdateMenu()
        {
            Console.WriteLine("#######################################");
            Console.WriteLine("#### Sub-Menu: Update/Delete teams ####");
            Console.WriteLine("#######################################");
            Console.WriteLine();
            Console.WriteLine("Please select an operation to perform");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. To Update a team");
            Console.WriteLine("2. To Delete a team");
            Console.WriteLine("3. To Go back to the Main Menu");
            Console.WriteLine("****************************************");
            Console.WriteLine();
        }


        public static void PlayingFirstRoundSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################");
            Console.WriteLine("##### Sub-Menu: Playing the First Round Options ####");
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. Enter Team names");
            Console.WriteLine("2. Match Teams Together");
            Console.WriteLine("3. Enter Scores");
            Console.WriteLine("4. Calculate Winner");
            Console.WriteLine("5. Display, teams, matches and winner");
            Console.WriteLine("7. continue to next round");
            Console.WriteLine("6. Exit to Main Menu");
            Console.WriteLine("***************************************");
        }

        public static void successiveRoundsSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("##############################################");
            Console.WriteLine("##### Sub-Menu: Successive Rounds Options ####");
            Console.WriteLine("##############################################");
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("***************************************");
            Console.WriteLine("1. Match the Winners together for a new round");
            Console.WriteLine("2. Enter Scores");
            Console.WriteLine("3. Calculate Winner");
            Console.WriteLine("4. Display, teams, matches and winners");
            Console.WriteLine("5. Exit to Main Menu");
            Console.WriteLine("***************************************");
        }
    }
}
