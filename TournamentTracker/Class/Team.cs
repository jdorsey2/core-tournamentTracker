using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    /// <summary>
    /// Stores a name and a score for a team. Contains methods for I/O operations and searching a Team array for a specific name.
    /// </summary>
    class Team
    {
        public string name { get; set; }
        public int score { get; set; }

        public Team()
        {
            name = "";
            score = 0;
        }

        /// <summary>
        /// Search for a given name within a collection of teams
        /// </summary>
        /// <param name="name">a string describing a name of a team to search for</param>
        /// <param name="teams">an array of Team which is searched</param>
        /// <returns></returns>
        public Team SearchForTeam(string name, Team[] teams)
        {
            Team team = new Team();
            for (int i = 0; i < teams.Length; i++)
            {
                if (name == teams[i].name)
                {
                    team = teams[i];
                }
            }
            return team;
        }

        /// <summary>
        /// Prompts user for a name of a team that is stored in a Team object, which is verified to not be empty and under 25 characters
        /// </summary>
        /// <param name="team">a blank object of type Team</param>
        /// <returns>name of a team as a Team object</returns>
        public Team EnterTeamName(Team team)    // passes a Team and returns a team
        {
            Console.WriteLine("Please enter a name");
            string teamName = Console.ReadLine();
            teamName = teamName.ToUpper();
            teamName = ErrorChecking.EnsureEmptyLines(teamName);
            teamName = ErrorChecking.EnsureLength(teamName);
            team.name = teamName;
            return team;
        }

        /// <summary>
        /// Given a Team object, it will display the name and the score.
        /// </summary>
        /// <param name="team">any object of class Team is accepted</param>
        public void DisplayTeam(Team team)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {team.name}");
            Console.WriteLine($"Score: {team.score}");
            Console.WriteLine();
        }
    }
}
