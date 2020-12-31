using System;

namespace TournamentTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter how many teams there are, only enter an even number");

            string sizeTeams = Console.ReadLine();
            sizeTeams = Class.ErrorChecking.EnsureDigit(sizeTeams);   // class ErrorChecking is from ErrorChecking.cs
            sizeTeams = Class.ErrorChecking.EnsureLength(sizeTeams);
            int numberTeams = Int32.Parse(sizeTeams);
            numberTeams = Class.ErrorChecking.EnsureEven(numberTeams);

            int originalNumber = numberTeams;
            int leftOutAmount = 0;
            int counter = 0;
            bool cannotCompete = false;

            // ************ Calculates number of tournament rounds based on how many teams is entered
            // start
            
            while (numberTeams > 1)
            {
                int numberOneLess = numberTeams - 1;

                if (numberTeams % 2 == 0)
                {
                    numberTeams = numberTeams / 2;
                    counter++;
                }
                else if ((numberOneLess) % 2 == 0)
                {
                    numberOneLess = numberOneLess / 2;
                    counter++;
                    leftOutAmount++;
                    cannotCompete = true;       // if there is one team left over because odd number of teams: so cannot com
                    numberTeams = numberOneLess;
                }
            }
            if (leftOutAmount % 2 == 0) // add it to the counter amount
            {
                counter = counter + leftOutAmount; // this leads to wrong solutions
                leftOutAmount = 0;
                cannotCompete = false;

            }
            else if (leftOutAmount > 2) // set odd number 3 or greater to add matching teams to counter with one being left over
            {
                leftOutAmount = leftOutAmount - 1;
            }
            if (cannotCompete == true)
            {
                Console.WriteLine($"you entered {originalNumber} teams, in the course of the game play, you will have {leftOutAmount} team(s) left out,");
                Console.WriteLine("at least one team will have to play an extra time to account for this");
            }
            Console.WriteLine();
            Console.WriteLine($"With {originalNumber} teams, you can play {counter} rounds");
            // end

            int numberRounds = counter;

// *************** storage for program *******************************************************
            Class.Team[] originalTeams = new Class.Team[originalNumber];

            for (int i = 0; i < originalTeams.Length; i++)
            {
                originalTeams[i] = new Class.Team();
            }

            int numberOfMatch = originalNumber / 2;
            Class.Match[] originalMatch = new Class.Match[numberOfMatch];
            for (int i = 0; i < originalMatch.Length; i++)
            {
                originalMatch[i] = new Class.Match();
            }

            int numberOfWinners = numberOfMatch;
            Class.Team[] originalWinners = new Class.Team[numberOfWinners];
            for (int i = 0; i < originalWinners.Length; i++)
            {
                originalWinners[i] = new Class.Team();
            }

            string input = "";
            while (input != "J")
            {
                Class.Menu.TestDisplayMainMenu();
                input = Console.ReadLine();
                input = input.ToUpper();
                input = Class.ErrorChecking.EnsureEmptyLines(input);
                input = Class.ErrorChecking.EnsureLength(input);

                if (input == "A") // enter team names
                {
                    for (int i = 0; i < originalTeams.Length; i++)
                    {
                        originalTeams[i] = originalTeams[i].EnterTeamName(originalTeams[i]);
                    }
                }
                else if (input == "B") //name team Match
                {
                    for (int i = 0; i < originalMatch.Length; i++)
                    {
                        originalMatch[i] = originalMatch[i].EnterNameMatch(originalMatch[i]);
                    }
                }
                else if (input == "C") //enter team Match
                {
                    // ***** Match two teams together into a match or play********************************************************
                    //start
                    for (int i = 0; i < originalMatch.Length; i++)
                    {

                        Class.Match inputMatch = new Class.Match();

                        Console.WriteLine("Please enter name of match you want to put teams into");
                        Console.WriteLine("Select from the following:");
                        for (int x = 0; x < originalMatch.Length; x++)
                        {
                            Console.WriteLine(originalMatch[x].name);
                        }
                        Console.WriteLine();
                        string matchInput = Console.ReadLine();
                        matchInput = matchInput.ToUpper();
                        matchInput = Class.ErrorChecking.EnsureEmptyLines(matchInput);
                        matchInput = Class.ErrorChecking.EnsureLength(matchInput);

                        inputMatch = inputMatch.SearchForMatch(matchInput, originalMatch);

                        Class.Team inputOneTeam = new Class.Team();
                        Console.WriteLine("Enter two teams you want to match");
                        Console.WriteLine("Please select from the following");
                        for (int x = 0; x < originalTeams.Length; x++)
                        {
                            Console.WriteLine(originalTeams[x].name);
                        }
                        Console.WriteLine();
                        string teamOneInput = Console.ReadLine();
                        teamOneInput = teamOneInput.ToUpper();
                        teamOneInput = Class.ErrorChecking.EnsureEmptyLines(teamOneInput);
                        teamOneInput = Class.ErrorChecking.EnsureLength(teamOneInput);

                        inputOneTeam = inputOneTeam.SearchForTeam(teamOneInput, originalTeams);

                        Class.Team inputTwoTeam = new Class.Team();
                        Console.WriteLine("enter second team");
                        string teamTwoInput = Console.ReadLine();
                        teamTwoInput = teamTwoInput.ToUpper();
                        teamTwoInput = Class.ErrorChecking.EnsureEmptyLines(teamTwoInput);
                        teamTwoInput = Class.ErrorChecking.EnsureLength(teamTwoInput);

                        inputTwoTeam = inputTwoTeam.SearchForTeam(teamTwoInput, originalTeams);

                        inputMatch = inputMatch.ConvertTeamToMatch(inputMatch, inputOneTeam, inputTwoTeam);

                        originalMatch[i] = inputMatch;
                        // end
                    }


                }
                else if (input == "D") // enter scores
                {
                    Console.WriteLine("Please enter scores by match");
                    for (int i = 0; i < originalMatch.Length; i++)
                    {
                        originalMatch[i] = originalMatch[i].EnterScoreOfTeamsbyMatch(originalMatch[i]);
                    }
                    
                }
                else if (input == "E") // calculate winner
                {
                    if (numberRounds > 0)   // only calculates winners when rounds are left
                    {
                        for (int i = 0; i < originalMatch.Length; i++)
                        {
                            originalWinners[i] = originalMatch[i].CompareScores(originalMatch[i].teamOne, originalMatch[i].teamTwo);
                        }
                        numberRounds--;
                    }
                    else
                    {
                        Console.WriteLine("you have zero rounds left to play");
                    }

                }
                else if (input == "F") // display
                {
                    string displayInput = "";
                    while (displayInput != "4")
                    {
                        Console.WriteLine("1. Display Teams. 2. Display Match. 3. Display Winners. 4. Exit");
                        displayInput = Console.ReadLine();
                        displayInput = Class.ErrorChecking.EnsureEmptyLines(displayInput);
                        displayInput = Class.ErrorChecking.EnsureLength(displayInput);
                        displayInput = Class.ErrorChecking.EnsureDigit(displayInput);

                        if (displayInput == "1")
                        {
                            for (int i = 0; i < originalTeams.Length; i++)
                            {
                                originalTeams[i].DisplayTeam(originalTeams[i]);
                            }
                        }
                        else if (displayInput == "2")
                        {
                            for (int i = 0; i < originalMatch.Length; i++)
                            {
                                originalMatch[i].DisplayMatch(originalMatch[i]);
                            }
                        }
                        else if (displayInput == "3")
                        {
                            for (int i = 0; i < originalWinners.Length; i++)
                            {
                                originalWinners[i].DisplayTeam(originalWinners[i]);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Please enter one of the options");
                        }
                    }
                }
            }
        }
    }
    
}
