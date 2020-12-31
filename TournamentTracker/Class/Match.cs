using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    class Match
    {
        public string name { get; set; }
        public Team teamOne { get; set; }
        public Team teamTwo { get; set; }

        public Match ConvertTeamToMatch(Match match, Team one, Team two)
        {                                                             // enter two teams given a match
            match.teamOne = one;                              // can name the match seperately
            match.teamTwo = two;

            return match;
        }

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

        public Match EnterNameMatch(Match match)  // name a specific match between two teams
        {
            Console.WriteLine("Please enter a name for the match");
            string matchName = Console.ReadLine();
            matchName = matchName.ToUpper();
            matchName = ErrorChecking.EnsureEmptyLines(matchName);
            matchName = ErrorChecking.EnsureLength(matchName);
            match.name = matchName;
            return match;
        }


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

        public Team CompareScores(Team one, Team two)
        {
            if (one != null || two != null)
            {
                if (one.score != 0 || two.score != 0)
                {
                    if (one.score > two.score)
                    {
                        two.score = -1;
                        return one;
                    }
                    else if (one.score < two.score)
                    {
                        one.score = -1;
                        return two;
                    }
                    else
                    {
                        Console.WriteLine("tie"); // have a tie, need additional functionality (elimination round) to deal with it
                        return one; // fix later when tie functionality is updated
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
