/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        //Creates a dictionary to store the total points for each player (player ID (key), total points (value)
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            //if player alredy exists in the dictionary, add points to their total
            if (players.ContainsKey(playerId))
                players[playerId] += points;

            else
                //if not, add new entry for the player with their points
                players[playerId] = points;
        }
        //After reading data, convert the dict. to an array and sort it
        var topPlayers = players.ToArray();
        //Sorts array (highest first)
        Array.Sort(topPlayers, (p1, p2) => p2.Value - p1.Value);

        Console.WriteLine();
        for (var i = 0; i < 10; i++)
        {
            //Prints the top the players with highest scores
            Console.WriteLine(topPlayers[i]);
        }
        
    }
}