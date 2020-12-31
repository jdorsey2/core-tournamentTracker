using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentTracker.Class
{
    class Team
    {
        public string name { get; set; }
        public int score { get; set; }

        public Team()
        {
            name = "";
            score = 0;
        }

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

        public void DisplayTeam(Team team)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {team.name}");
            Console.WriteLine($"Score: {team.score}");
            Console.WriteLine();
        }
    }
}
