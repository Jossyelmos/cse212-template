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
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row 
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
                // highestPoint = 
            } else {
                players.Add(playerId, points);
            }
        }
        var playerArray = players.ToArray();
        Array.Sort(playerArray, (x, y) => y.Value.CompareTo(x.Value));

        // Console.WriteLine($"Players: {{{string.Join(", ", playerArray)}}}");

        var topPlayers = new string[10];

        for (int index = 0; index < 10; index++) {
            topPlayers[index] = $"{playerArray[index].Key} - {playerArray[index].Value}";
        }

        Console.WriteLine(string.Join("\n", topPlayers));
    }
}