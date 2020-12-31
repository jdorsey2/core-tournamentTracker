using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    /// <summary>
    /// Describes two teams that are matched with each other to compete. Contains any two objects
    /// of type Team and a name of the match.
    /// </summary>
    class Match
    {
        public string name { get; set; }
        public Team teamOne { get; set; }
        public Team teamTwo { get; set; }

        /// <summary>
        /// Takes two objects of type Team and places them in a Match object. Reorganizes any two
        /// teams as having a matching (playing) relationship.
        /// </summary>
        /// <param name="match">An object of type Match</param>
        /// <param name="teamOne">first object of type Team</param>
        /// <param name="teamTwo">second object of type Team</param>
        /// <returns>an object of type Match</returns>
        public Match ConvertTeamToMatch(Match match, Team teamOne, Team teamTwo)
        {                                                             
            match.teamOne = teamOne;                              
            match.teamTwo = teamTwo;

            return match;
        }

        /// <summary>
        /// Searches an collection of matches for the name of a match. 
        /// </summary>
        /// <param name="name">any string that is a name for a match</param>
        /// <param name="matches">an array of objects of type Match</param>
        /// <returns>an object of type Match that contains the name of the match, if no name is 
        /// found it returns a null match.</returns>
        public Match SearchForMatch(string name, Match[] matches)
        {
            Match match = new Match();

            for (int i = 0; i < matches.Length; i++)
            {
                if (name == matches[i].name)
                {
                    match = matches[i];
                }
            }
            return match;
        }

        /// <summary>
        /// Give a match a name. Checks for empty input and that the length is under 25 characters.
        /// </summary>
        /// <param name="match">An object of type Match.</param>
        /// <returns>An object of type Match with the given name.</returns>
        public Match EnterNameMatch(Match match) 
        {
            Console.WriteLine("Please enter a name for the match");
            string matchName = Console.ReadLine();
            matchName = matchName.ToUpper();
            matchName = ErrorChecking.EnsureEmptyLines(matchName);
            matchName = ErrorChecking.EnsureLength(matchName);
            match.name = matchName;
            return match;
        }

        /// <summary>
        /// Enter the score of the teams that are matched up together. Contains checks for empty input,
        /// that it is under 25 characters and that it is a digit.
        /// </summary>
        /// <param name="match">An object of type Match</param>
        /// <returns>An object of type Match</returns>
        public Match EnterScoreOfTeamsbyMatch(Match match)
        {
            Console.WriteLine("Please enter score");
            Console.WriteLine($"Name: {match.teamOne.name}");
            string ScoreInt = Console.ReadLine();
            ScoreInt = ErrorChecking.EnsureEmptyLines(ScoreInt);
            ScoreInt = ErrorChecking.EnsureLength(ScoreInt);
            ScoreInt = ErrorChecking.EnsureDigit(ScoreInt);
            match.teamOne.score = Int32.Parse(ScoreInt);

            Console.WriteLine("Please enter score");
            Console.WriteLine($"Name: {match.teamTwo.name}");
            string Score = Console.ReadLine();
            Score = ErrorChecking.EnsureEmptyLines(Score);
            Score = ErrorChecking.EnsureLength(Score);
            Score = ErrorChecking.EnsureDigit(Score);
            match.teamTwo.score = Int32.Parse(Score);

            return match;
        }

        /// <summary>
        /// Displays the name and score of the teams in a match, and which teams are paired up.
        /// </summary>
        /// <param name="match">An object of type Match</param>
        public void DisplayMatch(Match match)
        {
            Console.WriteLine();
            Console.WriteLine("Match between:");
            Console.WriteLine(match.teamOne.name);
            Console.WriteLine(match.teamOne.score);
            Console.WriteLine("and");
            Console.WriteLine(match.teamTwo.name);
            Console.WriteLine(match.teamTwo.score);
        }

        /// <summary>
        /// Calculates the winner of a match between two teams.
        /// </summary>
        /// <param name="teamOne">An object of type Team.</param>
        /// <param name="teamtwo">An object of type Team</param>
        /// <returns>the winner, if a team is null or has zero as a score will return 
        /// a null team.</returns>
        public Team CompareScores(Team teamOne, Team teamtwo)
        {
            if (teamOne != null || teamTwo != null)
            {
                if (teamOne.score != 0 || teamTwo.score != 0)
                {
                    if (teamOne.score > teamTwo.score)
                    {
                        teamTwo.score = -1;
                        return teamOne;
                    }
                    else if (teamOne.score < teamTwo.score)
                    {
                        teamOne.score = -1;
                        return teamTwo;
                    }
                    else
                    {
                        Console.WriteLine("tie"); // have a tie, need additional functionality (elimination round) to deal with it
                        return teamOne; // fix later when tie functionality is updated
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a score");
                    return new Team();
                }
            }
            else
            {
                Console.WriteLine("Please enter a team name first");
                return new Team();
            }
        }
    }
}
